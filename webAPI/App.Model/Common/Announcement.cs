using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Model.Common
{
    public class Announcement
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Subject { get; set; }

        public string Filler { get; set; }
        public string[] Files { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
