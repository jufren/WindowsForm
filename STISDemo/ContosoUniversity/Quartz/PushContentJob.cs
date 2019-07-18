using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR.Client;

namespace ContosoUniversity.Quartz
{
    public class PushContentJob : IJob
    {
        

        Task IJob.Execute(IJobExecutionContext context)
        {
            IHubProxy _hub;
            string url = @"~/signalr";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("ATSHub");
            connection.Start().Wait();
            string line = null;
            //isStop = false;
            //while ((line = System.Console.ReadLine()) != null)
            //{

            while (true)
            {
                Random r = new Random();
                string t1 = r.Next(1, 5).ToString();
                string t2 = r.Next(1, 7).ToString();
                string t3 = r.Next(1, 5).ToString();
                string t4 = r.Next(1, 7).ToString();
                //textBox1.Text = t1;
                //textBox2.Text = t2;
                _hub.Invoke("PushATSInfo", "LINE1:" + t1 + "," + t2 + ";LINE2:" + t3 + "," + t4).Wait();
                //throw new NotImplementedException();
            }
            return Task.CompletedTask;
        }
    }
}