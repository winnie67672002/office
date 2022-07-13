using System;
using System.Collections.Generic;

namespace App.EF.EF.dbofficeApi
{
    public partial class TblBusinessUnit
    {
        public string CId { get; set; }
        public string CBucode { get; set; }
        public string CName { get; set; }
        public string CDescription { get; set; }
        public DateTime? CCreateDt { get; set; }
        public string CCreator { get; set; }
        public DateTime? CUpdateDt { get; set; }
        public string CUpdator { get; set; }
        public int? CStatus { get; set; }
        public string CRemark { get; set; }
        public int? CUserLimit { get; set; }
        public bool? CPlatformIsSupport { get; set; }
        public int? CType { get; set; }
    }
}
