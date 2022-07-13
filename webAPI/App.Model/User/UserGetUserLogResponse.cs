using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class UserGetUserLogResponse
    {
        public int CId { get; set; }
        public string CAccount { get; set; }
        public string CName { get; set; }
        public DateTime DateCreate { get; set; }



        public int FunctionId { get; set; }
        public string FunctionName { get; set; }

        public string Ip { get; set; }
    }
}
