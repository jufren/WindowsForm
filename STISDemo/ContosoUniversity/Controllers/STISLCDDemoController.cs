using ContosoUniversity.DAL;
using ContosoUniversity.Models.STIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class STISLCDDemoController : Controller
    {
        SchoolContext sc = new SchoolContext();
        // GET: STISLCDDemo
        public ActionResult Index()
        {
            ViewBag.PidPlayList = Json(RetrievePlayListContent());
            return View();
        }

        // GET: STISLCDDemo/RetrievePlayListInfo
        public JsonResult RetrievePlayListInfo()
        {
             
            return Json(RetrievePlayListContent(), JsonRequestBehavior.AllowGet);
        }

        public PIDPlayListInfo RetrievePlayListContent()
        {
            MonthPlan mpl = sc.MonthPlan.Include("MonthPlanDetails").First();
            List<MonthPlanDetail> mplndtls = mpl.MonthPlanDetails;
            PIDPlayListInfo PidPlayList = new PIDPlayListInfo();
            PIDPlayListInfoDetail pidplayinfo = null;
            PidPlayList.PIDPlayListInfoDetail = new List<PIDPlayListInfoDetail>();
            foreach (MonthPlanDetail detail in mplndtls)
            {
                sc.Entry(detail).Reference("Schedule").Load();
                Schedule schd = detail.Schedule;
                sc.Entry(schd).Collection("ScheduleDetail").Load();
                foreach (ScheduleDetail scdetail in schd.ScheduleDetail)
                {

                    sc.Entry(scdetail).Collection("TimeSlotPlayList").Load();
                    foreach (TimeSlotPlayList tspl in scdetail.TimeSlotPlayList)
                    {
                        string ActualStartTime = sc.TimeSlotDetail.Where(x => x.TimeSlotDetailID.Equals(tspl.TimeSlotDetailID)).First().ActualStartTime;
                        string ActualEndTime = sc.TimeSlotDetail.Where(x => x.TimeSlotDetailID.Equals(tspl.TimeSlotDetailID)).First().ActualEndTime;
                        sc.Entry(tspl).Reference("PlayList").Load();

                        PlayList pl = tspl.PlayList;
                        // foreach (PlayList pl in tspl.PlayList)
                        // {
                        sc.Entry(pl).Collection("PlayListDetails").Load();
                        foreach (PlayListDetail pld in pl.PlayListDetails)
                        {
                            TimeSpan ts=DateTime.Now.TimeOfDay;
                            TimeSpan tsstart = TimeSpan.Parse(ActualStartTime);
                            TimeSpan tsend = TimeSpan.Parse(ActualEndTime);
                            pidplayinfo = new PIDPlayListInfoDetail();
                            sc.Entry(pld).Reference("Media").Load();
                            pidplayinfo.PlayMedia = pld.Media;
                            pidplayinfo.Sequence = pld.Sequence;
                            pidplayinfo.ActualStartTime = ActualStartTime;
                            pidplayinfo.ActualEndTime = ActualEndTime;
                            if (ts >= tsstart && ts <= tsend)
                            {
                                PidPlayList.PIDPlayListInfoDetail.Add(pidplayinfo);
                            }
                        }
                        //}
                    }



                }
            }
            return PidPlayList;
        }

    }
}