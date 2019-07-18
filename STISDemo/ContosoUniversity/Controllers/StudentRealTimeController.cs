using ContosoUniversity.DAL;
using ContosoUniversity.ModelHelper;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class StudentRealTimeController : Controller
    {
        private SchoolContext db = new SchoolContext();
        public ActionResult Index()
        {
            var collection = db.Students;
            ViewBag.NotifierEntity = db.GetNotifierEntity<Person>(collection).ToJson();            

            return View(db.Students.ToList());
        }
        public ActionResult IndexPartial()
        {
            var collection = db.Students;
            ViewBag.NotifierEntity = db.GetNotifierEntity<Person>(collection).ToJson();            
            return PartialView(collection.ToList());
        }
        // GET: StudentIR/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentIR/Create
        public ActionResult Create()
        {
            return View();
        }

        
    }
}
