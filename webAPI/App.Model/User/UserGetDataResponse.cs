using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class UserGetDataResponse
    {
        public string CUserId { get; set; }
        public string CAccount { get; set; }
        public string CName { get; set; }
        public int CStatus { get; set; }

        public List<int> ListUserGroup { get; set; } = new List<int>();
    }

}
