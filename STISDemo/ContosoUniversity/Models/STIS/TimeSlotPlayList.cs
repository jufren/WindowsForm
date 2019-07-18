using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models.STIS
{
    public class TimeSlotPlayList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeSlotPlayListID { get; set; }
        public int TimeSlotDetailID { get; set; }
        public PlayList PlayList { get; set; }
    }
}