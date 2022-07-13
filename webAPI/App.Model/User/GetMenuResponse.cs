using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class GetMenuResponse
    {
        public List<FunctionDTO> Menu { get; set; } = new List<FunctionDTO>();
    }
}
