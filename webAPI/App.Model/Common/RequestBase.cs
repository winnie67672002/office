using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class RequestBase
    {
        //public string ColumnName { get; set; }
        //public string OrderByMode { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
