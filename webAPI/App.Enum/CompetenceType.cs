using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Enum
{
    public enum CompetenceType
    {

        [Display(Name = "檢視")]
        View = 1,

        [Display(Name = "新增")]
        Add = 2,

        [Display(Name = "修改")]
        Edit = 3,

        [Display(Name = "刪除")]
        Remove = 4,

        [Display(Name = "Excel匯入")]
        ExcelImport = 5,

        [Display(Name = "Excel匯出")]
        ExcelExport = 6,

    }
}
