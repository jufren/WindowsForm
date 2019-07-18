using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models.STIS
{
    public class PlayList
    {
        [Key]
        public string PlayListID { get; set; }
        public string TemplateID { get; set; }
        public List<PlayListDetail> PlayListDetails { get; set; }
        public int Duration { get; set; }
    }
}