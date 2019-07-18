using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity
{
    /// <summary>
    /// Summary description for SSEHandler
    /// </summary>
    public class SSEHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse Response = context.Response;
            DateTime startDate = DateTime.Now;
            Response.ContentType = "text/event-stream";
            while (startDate.AddMinutes(10) > DateTime.Now) {
                
                Response.Write(string.Format("data: {0},{1}\n\n", new Random().Next(1, 4), new Random().Next(1, 3))); Response.Flush(); System.Threading.Thread.Sleep(5000);
            }
            Response.Close();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}