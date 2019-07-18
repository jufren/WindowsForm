using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models.STIS
{
    public class PlayMedia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayMediaID { get; set; }
        public MediaType MediaType { get; set; }
        public string FilePath { get; set; }
        public int Duration { get; set; }
    }
    public enum MediaType
    {
        Picture=1, Video=2, Music=3
    }
}