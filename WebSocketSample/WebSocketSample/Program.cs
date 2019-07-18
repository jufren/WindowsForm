using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
//using WebSocketSharp;
using WebSocket4Net;
namespace WebSocketSample
{
    class Program : SC8131MessageEventHandler
    {
        static void Main(string[] args)
        {
            //RootObject data = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(System.IO.File.ReadAllText(@"D:\\temp\json.txt"));
            Program p = new Program();
            //SC8131WebSocket socket = new SC8131WebSocket(p);
            //TcpClient client = new TcpClient("2.80.4.31",888);
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    bool r = tcpClient.ConnectAsync("2.80.4.31", 888).Wait(3000);

                    //return r;
                }
                catch (Exception ex)
                {
                    //LogHelperObject.WriteEventLog(ex.ToString(), applicationId);
                    //Console.WriteLine("Port closed");
                }
            }
            //WebSocket websocket = new WebSocket("ws://2.80.4.31:888/",null,CreateAuthorizationHeader("root","vivo1234"),null,null,null,WebSocketVersion.None,null,System.Security.Authentication.SslProtocols.None,0);
            
            //websocket.Opened += new EventHandler(websocket_Opened);
            //websocket.Error += new EventHandler<ErrorEventArgs>(websocket_Error);
           // websocket.Closed += new EventHandler(websocket_Closed);
            //websocket.MessageReceived += OnMessageReceived;
            //websocket.MessageReceived += this.OnMessageReceived;
            //websocket.Open();
            //InOutStatistic inout=socket.GetInitialData();
            //System.Net.WebSockets.ClientWebSocket cws = new System.Net.WebSockets.ClientWebSocket();
            
            //Console.WriteLine("totalIn:" + inout.In + ",totalOut:" + inout.Out + ",zoneIn:" + inout.ZoneInside);
            //socket.OpenConnection("ws://2.80.4.44:777");
            Console.ReadLine();
        }
        public static KeyValuePair<string, string>
              CreateAuthorizationHeader(string userID, string password)
        {
            NetworkCredential networkCredential = new NetworkCredential(userID, password);

            string userName = networkCredential.UserName;
            string userPassword = networkCredential.Password;

            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));

            return new KeyValuePair<string, string>("Authorization", "Basic " + authInfo);
        }
        public void OnMessageReceived(object sender, EventArgs e)
        {
           // Console.WriteLine("totalIn:" + totalIn + ",totalOut:" + totalOut + ",zoneIn:" + zoneTotalIn);

        }
        public void OnEventMessageReceived(int totalIn, int totalOut, int zoneTotalIn)
        {
            Console.WriteLine("totalIn:" + totalIn + ",totalOut:" + totalOut + ",zoneIn:" + zoneTotalIn);

        }
    }
}
