using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models.STIS
{
    public class PIDPlayListInfoDetail
    {
        public string ActualStartTime { get; set; }
        public string ActualEndTime { get; set; }
        public int Sequence { get; set; }
        public PlayMedia PlayMedia { get;set;}
    }
}