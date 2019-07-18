using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.ModelHelper;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ContosoUniversity.Hubs
{
    [HubName("studenthub")]
    public class StudentHub : Hub
    {
        internal NotifierEntity NotifierEntity { get; private set; }

        public void DispatchToClient()
        {
            
            Clients.All.broadcastMessage("Refresh");
        }
        String value = "";
        public void Initialize(String value)
        {
            this.value = value;
            NotifierEntity = NotifierEntity.FromJson(value);
            if (NotifierEntity == null)
                return;
            Action<String> dispatcher = (t) => { DispatchToClient(); };
            PushSqlDependency.Instance(NotifierEntity, dispatcher);
        }
    }
}