using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;
namespace WebSocketSample
{
    public class SC8131WebSocket 
    {
        WebSocket ws;
        SC8131MessageEventHandler eventHandler;
        public InOutStatistic statistics { get; set; }
        public SC8131WebSocket(SC8131MessageEventHandler eventHandler)
        {
            this.eventHandler = eventHandler;
            statistics = new InOutStatistic();
        }
        public RootObject responseData { get; set; }
        public void OpenConnection(string url)
        {
            ws = new WebSocket(url, "stereo-tracker-protocol");         
          
            //ws.SetCredentials("root","vivo1234",true);
            ws.SetCredentials("root", "root", true);
            
            ws.OnMessage += OnMessage;
            ws.Connect();
           
            //ws.OnOpen += OnOpen;
            //ws.OnError +=OnError;
           
            //ws.OnOpen += OnOpen;
        }
        private void OnError(object sender, EventArgs e)
        {
            string jSonData = e.ToString();
            Console.WriteLine("Connected");
            throw new NotImplementedException();
        }
        private void OnOpen(object sender, EventArgs e)
        {
            string jSonData = e.ToString();
            Console.WriteLine("Connected");
            throw new NotImplementedException();
        }
        public InOutStatistic GetInitialData()
        {
            //statistics = GetCount();
           
            //if (statistics.In <= 0 || statistics.Out <= 0)
            //{
            ClearStatFile();
            statistics=WriteReportData();
            //}
            return statistics;
        }

        public string GetFilePath()
        {
            return @"D:\PIDS\" + DateTime.Today.ToString("ddMMyyyy") + ".txt";
        }
        private void OnMessage(object sender, MessageEventArgs e) 
        {
            //OnMessageReceived(sender, e);
            string jSonData=e.Data;
            //string s=e.RawData.ToString();
            int countingIndex=jSonData.IndexOf("Counting1");
            int zoneIndex = jSonData.IndexOf("\"Zone1\"");
            int eventCheck = jSonData.IndexOf("\"Tag\":\"Event\"");
            Console.WriteLine(jSonData);
            if(eventCheck!=-1)
            {
                if(countingIndex!=-1)
                {
                    //alert(s);
				  	    int countIn=0,countOut=0;
				  	    int inIndex=jSonData.IndexOf("In\":")+4;
				  	    int outIndex=jSonData.IndexOf("Out\":")+5;

				  	    countIn=Int32.Parse(jSonData.Substring(inIndex,jSonData.IndexOf(",",inIndex)-inIndex));
				  	    countOut=Int32.Parse(jSonData.Substring(outIndex,jSonData.IndexOf(",",outIndex)-outIndex));
                        statistics.In+=countIn;statistics.Out+=countOut;
                        Console.WriteLine("Statistics.in:" + statistics.In);
                        Console.WriteLine("Statistics.out:" + statistics.Out);
                }
                if (zoneIndex != -1)
                {
                    //LogHelperObject.WriteEventLog("tst_cnt=" + tst_cnt++ + "," + "jSonData:" + jSonData, "TrainMovement");
                    //Console.WriteLine("tst_cnt=" + tst_cnt++ + "," + "jSonData:" + jSonData);
                    //alert(s);
                    int countInside = 0;
                    int inIndex = jSonData.IndexOf("Inside\":") + 8;

                    countInside = Int32.Parse(jSonData.Substring(inIndex, jSonData.IndexOf(",", inIndex) - inIndex));

                    statistics.ZoneInside = countInside;
                    //LogHelperObject.WriteEventLog("Statistics.ZoneInside:" + statistics.ZoneInside, "TrainMovement");
                    //eventHandler.OnZoneMessageReceived(statistics.ZoneInside);
                }
            }
            /*responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(jSonData);
            if (responseData.Tag.ToUpper().Equals("EVENT"))
            {
                //Console.WriteLine("RuleType:{0}", responseData.Data[0].RuleType);
                string ruleType = responseData.Data[0].RuleType;
                if (ruleType.ToUpper().Equals("COUNTING"))
                {
                    Console.WriteLine("COUNTING DATA");
                    //Console.WriteLine("Time:{0},In:{1},Out:{2}", responseData.Data[0].CountingInfo[0].Time, responseData.Data[0].CountingInfo[0].In, responseData.Data[0].CountingInfo[0].Out);
                    CountingInfo cinfo = responseData.Data[0].CountingInfo.Where(x => x.RuleName.ToUpper().Equals("COUNTING1")).FirstOrDefault();
                    if (cinfo != null)
                    {
                        statistics.In += cinfo.In;
                        statistics.Out += cinfo.Out;
                        Console.WriteLine("In:" + statistics.In);
                        Console.WriteLine("Out:" + statistics.Out);
                        //WriteCount(statistics);
                    }
                }
                else if (ruleType.ToUpper().Equals("ZONEDETECTION"))
                {
                    //GetReportData();
                }
                    //Console.WriteLine("Time:{0},Inside:{1},RuleType:{2}", responseData.Data[0].ZoneInfo[0].Time, responseData.Data[0].ZoneInfo[0].Inside, responseData.Data[0].ZoneInfo[0].RuleName);
                
                
            }*/
        }
        public InOutStatistic WriteReportData()
        {
            string url = "http://2.80.4.31/Stereo-Counting/cgi-bin/report_pull.cgi?starttime={starttime}&endtime={endtime}&aggregation=86400&format=json&lite=0&localtime=0";
            string starttime = DateTime.Now.ToString("yyyy-MM-ddT") + "00:00:00";
            string endtime = DateTime.Now.ToString("yyyy-MM-ddT") + "23:59:59";
            url = url.Replace("{starttime}", starttime.UrlEncode());
            url = url.Replace("{endtime}", endtime.UrlEncode());
            WebRequest request = WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            NetworkCredential networkCredential = new NetworkCredential("root", "vivo1234"); // logon in format "domain\username"
            CredentialCache myCredentialCache = new CredentialCache { { new Uri(url), "Basic", networkCredential } };
            request.PreAuthenticate = true;
            request.Credentials = myCredentialCache;
            string responseFromServer = "";
            InOutStatistic inout = new InOutStatistic();
            using (WebResponse response = request.GetResponse())
            {
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        responseFromServer = reader.ReadToEnd();
                        responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(responseFromServer);
                        CountingInfo cinfo=responseData.Data[0].CountingInfo.Where(x=>x.RuleName.ToUpper().Equals("COUNTING1")).First();
                        //ZoneInfo zinfo = responseData.Data.Where(x => x.RuleType.ToUpper().Equals("ZONEDETECTION")).First().ZoneInfo[0];
                                               
                        inout.In= cinfo.In;
                        inout.Out= cinfo.Out;
                        inout.ZoneInside = 0;
                        WriteCount(inout);
                        
                    }
                }
            }
            return inout;
        }   
        
        public void CloseConnection()
        {
            ws.CloseAsync();
        }
        public void ClearStatFile()
        {
            string filePath = GetFilePath();
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
        public InOutStatistic GetCount()
        {
            InOutStatistic inouts = new InOutStatistic();
            string filename=GetFilePath();
            if(System.IO.File.Exists(filename))
            {    string inout = System.IO.File.ReadAllText(filename);
                if (inout.Length > 0)
                {
                    inouts.In = Int32.Parse(inout.Split(',')[0]);
                    inouts.Out = Int32.Parse(inout.Split(',')[1]);
                    inouts.ZoneInside = Int32.Parse(inout.Split(',')[2]);
                }
                else
                {
                    inouts.In = inouts.Out = inouts.ZoneInside=0;
                }
            }   
            return inouts;
        }
        public void WriteCount(InOutStatistic inout)
        {
            System.IO.File.WriteAllText(@"D:\PIDS\" + DateTime.Today.ToString("ddMMyyyy") + ".txt", inout.In + "," + inout.Out + "," + inout.ZoneInside);
        }
       
    }
    public class InOutStatistic
    {
        public int In { get; set; }
        public int Out { get; set; }
        public int ZoneInside { get; set; }
    }
}
