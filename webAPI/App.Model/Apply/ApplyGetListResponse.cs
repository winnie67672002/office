using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Model
{
    public class ApplyGetListResponse 
    {
        public int cId { get; set; }
        public string cFormNo { get; set; }
        public string cApplyEmpName { get; set; }
        public string cApplyDept { get; set; }
        public DateTime cApplyDate { get; set; }
        public string cCostingNo { get; set; }
        public string cFile { get; set; }
        public string cRemark { get; set; }
        public string cGoodName { get; set; }
    }

}
