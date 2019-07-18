using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models.STIS
{
    public class TimeSlot
    {
        [Key]
        public string TimeSlotID { get; set; }
        public List<TimeSlotDetail> TimeSlotDetails { get; set; }
    }
}