using System;
using System.Collections.Generic;

namespace App.EF.EF.dbofficeApi
{
    public partial class TblUserOnGroup
    {
        public string CUserId { get; set; }
        public int CUserGroupId { get; set; }
        public bool? CStatus { get; set; }
    }
}
