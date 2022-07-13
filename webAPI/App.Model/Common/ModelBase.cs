using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.Common
{
    public class ModelBase<T>
    {
        public List<T> List { get; set; }
        public T Data { get; set; }

        public bool IsNew { get; set; }
        public bool CanEdit { get; set; }
    }
}
