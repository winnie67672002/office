using System;
using System.Collections.Generic;

namespace App.EF.EF.dbofficeApi
{
    public partial class TblSample
    {
        public int CId { get; set; }
        public string CTitle { get; set; }
        public string CDescription { get; set; }
        public string CType { get; set; }
        public DateTime CStartDate { get; set; }
        public string CQueryBox { get; set; }
        public string CType2 { get; set; }
    }
}
