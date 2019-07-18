using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalRClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isStop = false;
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            await Task.Run(() => SendATSInfo());
        }
        private async Task SendATSInfo()
        {
            IHubProxy _hub;
            string url = @"http://localhost:12810/signalr";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("ATSHub");
            connection.Start().Wait();
            string line = null;
            isStop = false;
            //while ((line = System.Console.ReadLine()) != null)
            //{

            while (!isStop)
            {
                Random r = new Random();
                string t1 = r.Next(1, 5).ToString();
                string t2 = r.Next(1, 7).ToString();
                string t3 = r.Next(1, 5).ToString();
                string t4 = r.Next(1, 7).ToString();
                
                textBox1.Invoke(new Action(() =>
                {
                    textBox1.Text = t1;
                }));
                textBox2.Invoke(new Action(() =>
                {
                    textBox2.Text = t2;
                }));
                _hub.Invoke("PushATSInfo", "LINE1:" + t1 + "," + t2 + ";LINE2:" + t3 + "," + t4).Wait();
                Thread.Sleep(5000);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            isStop = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IHubProxy _hub;
            string url = @"http://localhost:12810/signalr";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("ATSHub");
            connection.Start().Wait();
            string line = null;
            isStop = false;
            //while ((line = System.Console.ReadLine()) != null)
            //{

            //while (!isStop)
            //{
                Random r = new Random();
                string t1 = r.Next(1, 5).ToString();
                string t2 = r.Next(1, 7).ToString();
                string t3 = r.Next(1, 5).ToString();
                string t4 = r.Next(1, 7).ToString();
                textBox1.Text = t1;
                textBox2.Text = t2;
                _hub.Invoke("PushATSInfo", "LINE1:" + t1 + "," + t2 + ";LINE2:" + t3 + "," + t4).Wait();
                //Thread.Sleep(5000);
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IHubProxy _hub;
            string url = @"http://localhost:12810/signalr";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("ATSHub");
            connection.Start().Wait();
            string line = null;
            isStop = false;
            //while ((line = System.Console.ReadLine()) != null)
            //{

            //while (!isStop)
            //{
           
            _hub.Invoke("PushMessage", textBox3.Text).Wait();
            //Thread.Sleep(5000);
        }
    }
}
