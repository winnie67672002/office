using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class UserGroupGetListResponse
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public int? CStatus { get; set; }
        public string CBuid { get; set; }

        public DateTime? CUpdateDt { get; set; }
    }
}
