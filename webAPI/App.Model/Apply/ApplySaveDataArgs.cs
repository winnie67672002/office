using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Model
{
    public class ApplySaveDataArgs 
    {
         [DisplayName(" ")]
         public int cId { get; set; }

         [StringLength(50 ,ErrorMessage ="{0}長度需小於20")]
         [DisplayName(" ")]
         public string cFormNo { get; set; }

         [StringLength(50 ,ErrorMessage ="{0}長度需小於20")]
         [DisplayName(" ")]
         public string cApplyEmpName { get; set; }

         [StringLength(50 ,ErrorMessage ="{0}長度需小於20")]
         [DisplayName(" ")]
         public string cApplyDept { get; set; }

         [DisplayName(" ")]
         public DateTime cApplyDate { get; set; }

         [StringLength(50 ,ErrorMessage ="{0}長度需小於20")]
         [DisplayName(" ")]
         public string cCostingNo { get; set; }

         [StringLength(50 ,ErrorMessage ="{0}長度需小於50")]
         [DisplayName(" ")]
         public string cFile { get; set; }

         [StringLength(50 ,ErrorMessage ="{0}長度需小於500")]
         [DisplayName(" ")]
         public string cRemark { get; set; }

        public IFormFile UploadFile { get; set; }

        public List<Detail> Detail { get; set; } = new List<Detail>();
        public string? items { get; set; }

    }
    public class Detail

    {
        public int Id { get; set; }


        public string? Name { get; set; } = null!;

        public int Count { get; set; }
    }

}
