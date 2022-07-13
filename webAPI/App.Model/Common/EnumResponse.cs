using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class EnumResponse
    {
        public object Id { get; set; }

        public string Name { get; set; }
    }

    public class EnumArgs
    {
        public int TypeID { get; set; } = 0;
    }
}
