using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Model
{
    public class SampleGetListResponse 
    {
public int cId { get; set; }
        public string cTitle { get; set; }
        public string cDescription { get; set; }
        public string cType { get; set; }
        public DateTime cStartDate { get; set; }
        public string cQueryBox { get; set; }
        public string cType2 { get; set; }
    }

}
