using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class UserGetListArgs : RequestBase
    {
        public string CUserName { get; set; }
        public int CStatus { get; set; }
    }
}
