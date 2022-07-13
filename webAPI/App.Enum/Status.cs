using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Enum
{
    [Flags]
    public enum Status
    {
        [Display(Name = "停用")]
        Disable = 0,

        [Display(Name = "启用")]
        Enable = 1,

        [Display(Name = "作废")]
        Obsolete = 2,

        [Display(Name = "锁定")]
        Locked = 3,

        [Display(Name = "刪除")]
        Delete = 9
    }
}
