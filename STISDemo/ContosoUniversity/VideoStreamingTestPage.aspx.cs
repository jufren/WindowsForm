using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContosoUniversity
{
    public partial class VideoStreamingTestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnInit(EventArgs e)
        {
            //var source = false;

            string source = this.Request.QueryString["Source"];

            
            /*
            if (string.IsNullOrEmpty(source))
            {
                this.video.Style[HtmlTextWriterStyle.Display] = "none";
            }
            else
            {
                this.video.Src = source;
                
                //this.video.StreamingMode = VideoStreamingMode.None;
            }*/

            base.OnInit(e);
        }
    }
}