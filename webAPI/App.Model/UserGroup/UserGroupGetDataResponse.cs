using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class UserGroupGetDataResponse
    {
        public int? CId { get; set; }

        public string CName { get; set; }

        public List<UserGroupGetDataFunctionLv1> FunctionLv1 { get; set; }
    }

    public class UserGroupGetDataFunctionLv1
    {
        public int CId { get; set; }

        public string CName { get; set; }

        public List<UserGroupGetDataFunctionLv2> FunctionLv2 { get; set; }
    }

    public class UserGroupGetDataFunctionLv2
    {
        public int CId { get; set; }

        public string CName { get; set; }

        public List<UserGroupGetDataAuthority> Authority { get; set; }

    }

    public class UserGroupGetDataAuthority
    {
        public int CId { get; set; }

        public string CName { get; set; }

        public bool IsChecked { get; set; }

    }
}
