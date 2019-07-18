using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models.STIS
{
    public class PlayListDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayListDetailID { get; set; }
        public int Sequence { get; set; }
        public PlayMedia Media { get; set; }
    }
}