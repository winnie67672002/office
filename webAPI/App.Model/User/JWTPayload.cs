using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class JWTPayload
    {
        public string BuId { get; set; }
        public string UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 保存期限(UTC+0)
        /// </summary>
        public DateTime? ExpTime { get; set; }
        /// <summary>
        /// 登入帳號
        /// </summary>
        public string LoginId { get; set; }
        /// <summary>
        /// 是否限制權限(報表隱藏欄位)
        /// </summary>
        public bool? IsLimit { get; set; } = false;
    }
}
