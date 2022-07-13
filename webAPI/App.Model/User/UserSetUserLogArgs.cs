using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class UserSetUserLogArgs 
    {
        public int FunctionId { get; set; }        
        public string ActionName { get; set; }
        public string APIName { get; set; }
        public string Request { get; set; }
        public string Url { get; set; }
        public string Remark { get; set; }
        public string Ip { get; set; }
    }
}
