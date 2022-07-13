using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Model
{
    public class SampleSaveDataArgs 
    {
         [DisplayName("Key")]
         public int cId { get; set; }

                 [StringLength(50 ,ErrorMessage ="{0}長度需小於50")]
         [DisplayName("文字框範例")]
         public string cTitle { get; set; }

                 [Required(ErrorMessage = "{0}為必填")]
         [StringLength(50 ,ErrorMessage ="{0}長度需小於500")]
         [DisplayName("必填範例")]
         public string cDescription { get; set; }

                 [Required(ErrorMessage = "{0}為必填")]
         [StringLength(50 ,ErrorMessage ="{0}長度需小於10")]
         [DisplayName("下拉範例")]
         public string cType { get; set; }

                 [DisplayName("日期範例")]
         public DateTime cStartDate { get; set; }

                 [StringLength(50 ,ErrorMessage ="{0}長度需小於100")]
         [DisplayName("查詢範例")]
         public string cQueryBox { get; set; }

                 [Required(ErrorMessage = "{0}為必填")]
         [StringLength(50 ,ErrorMessage ="{0}長度需小於100")]
         [DisplayName("下拉範例2")]
         public string cType2 { get; set; }

    }

}
