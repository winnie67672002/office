using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class UserGroupGetListArgs : RequestBase
    {
        public string CName { get; set; }
        public int? CStatus { get; set; }
    }
}
