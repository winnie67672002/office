using System;
using System.Collections.Generic;

namespace App.EF.EF.dbofficeApi
{
    public partial class TblApply
    {
        public int CId { get; set; }
        public string CFormNo { get; set; }
        public string CApplyEmpName { get; set; }
        public string CApplyDept { get; set; }
        public DateTime CApplyDate { get; set; }
        public string CCostingNo { get; set; }
        public string CFile { get; set; }
        public string CRemark { get; set; }
    }
}
