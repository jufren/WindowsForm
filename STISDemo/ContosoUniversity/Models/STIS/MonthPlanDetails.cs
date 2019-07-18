using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models.STIS
{
    public class MonthPlanDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MonthPlanDetailID { get; set; }
        public DateTime Date { get; set; }
        public Schedule Schedule { get; set; }
    }
}