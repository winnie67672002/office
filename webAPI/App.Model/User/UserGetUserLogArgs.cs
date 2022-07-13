using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class UserGetUserLogArgs : RequestBase
    {
        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        /// <summary>
        /// -1全部
        /// </summary>
        public int FunctionId { get; set; } 
    }
}
