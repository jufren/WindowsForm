using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models.STIS
{
    public class MonthPlan
    {
        [Key]
        public string MonthPlanID { get; set; }
        public string MonthOf { get; set; }
        public List<MonthPlanDetail> MonthPlanDetails { get; set; }
    }
}