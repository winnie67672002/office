using System;
using System.Collections.Generic;

namespace App.EF.EF.dbofficeApi
{
    public partial class TblLoginLog
    {
        public int CId { get; set; }
        public string CUserId { get; set; }
        public string CUserToken { get; set; }
        public string CIp { get; set; }
        public DateTime? CCreateDt { get; set; }
        public string CCreator { get; set; }
        public DateTime? CUpdateDt { get; set; }
        public string CUpdator { get; set; }
    }
}
