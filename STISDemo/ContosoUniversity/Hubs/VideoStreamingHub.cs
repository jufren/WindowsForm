using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ContosoUniversity.Hubs
{
    [HubName("videoStreamingHub")]
    public class VideoStreamingHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public void Send(String imageUrl, Int32 imageWidth, Int32 imageHeight)
        {
            this.Clients.All.Send(imageUrl, imageWidth, imageHeight);
        }
    }
}