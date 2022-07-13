using System;
using System.Collections.Generic;

namespace App.EF.EF.dbofficeApi
{
    public partial class TblUserGroup
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public int? CStatus { get; set; }
        public string CCreator { get; set; }
        public DateTime? CCreateDt { get; set; }
        public string CUpdator { get; set; }
        public DateTime? CUpdateDt { get; set; }
        public string CBuid { get; set; }
    }
}
