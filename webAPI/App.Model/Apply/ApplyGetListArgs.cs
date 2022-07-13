using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Model
{
    public class ApplyGetListArgs : RequestBase
    {

         public string queryName { get; set; }

        
         public string queryDept { get; set; }


        public DateTime? startYear { get; set; }
        public DateTime? endYear { get; set; }

    }

}
