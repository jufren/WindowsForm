using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models.STIS
{
    public class Schedule
    {
        [Key]
        public string ScheduleID { get; set; }
        public TimeSlot SelectedTimeSlot { get; set; }
        public List<ScheduleDetail> ScheduleDetail { get; set; }
    }
}