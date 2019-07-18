using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ContosoUniversity.Hubs
{
    public class ATSHub : Hub
    {
        
        public void Hello()
        {
            Clients.All.hello();
        }
        public void PushATSInfo(string s)
        {
            Clients.All.getatsinfo(s);

        }
        public void PushMessage(string s)
        {
            Clients.All.getmessage(s);

        }

    }
}