using System;
using System.Collections.Generic;

namespace App.Model
{
    public class FunctionDTO
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public int? CParentId { get; set; }
        public string CPageUrl { get; set; }
        public bool? CIsMenu { get; set; }
        public int? CMenuIndex { get; set; }
        public string CCssStyle { get; set; }
        public int? CStatus { get; set; }
        public bool? CIsDelete { get; set; }
        public byte? CCompetenceType { get; set; }
        public int CFlowId { get; set; }

        public List<FunctionDTO> Child { get; set; } = new List<FunctionDTO>();
    }
}
