using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Enum
{
    [Flags]
    public enum Functions
    {
        /// <summary>
        /// 無
        /// </summary>  
        [Display(Name = "無")]
        none = 0,
        /// <summary>
        /// 系統登入
        /// </summary>  
        [Display(Name = "系統登入")]
        login = 1,
        /// <summary>
        /// 系統登出
        /// </summary>  
        [Display(Name = "系統登出")]
        logout = 2,
        /// <summary>
        /// 系統管理
        /// </summary>  
        [Display(Name = "系統管理")]
        sys_management = 3,
        /// <summary>
        /// 使用者管理
        /// </summary>  
        [Display(Name = "使用者管理")]
        user_management = 4,
        /// <summary>
        /// 角色權限管理
        /// </summary>  
        [Display(Name = "角色權限管理")]
        role_management = 5,
        /// <summary>
        /// 操作紀錄查詢
        /// </summary>  
        [Display(Name = "操作紀錄查詢")]
        logs_management = 6,
        /// <summary>
        /// 使用者管理[檢視]
        /// </summary>  
        [Display(Name = "使用者管理")]
        user_management_view = 7,
        /// <summary>
        /// 使用者管理[新增]
        /// </summary>  
        [Display(Name = "使用者管理[新增]")]
        user_management_add = 8,
        /// <summary>
        /// 使用者管理[修改]
        /// </summary>  
        [Display(Name = "使用者管理[修改]")]
        user_management_edit = 9,
        /// <summary>
        /// 使用者管理[刪除]
        /// </summary>  
        [Display(Name = "使用者管理[刪除]")]
        user_management_delete = 10,
        /// <summary>
        /// 角色權限管理[檢視]
        /// </summary>  
        [Display(Name = "角色權限管理[檢視]")]
        role_management_view = 11,
        /// <summary>
        /// 角色權限管理[新增]
        /// </summary>  
        [Display(Name = "角色權限管理[新增]")]
        role_management_add = 12,
        /// <summary>
        /// 角色權限管理[修改]
        /// </summary>  
        [Display(Name = "角色權限管理[修改]")]
        role_management_edit = 13,
        /// <summary>
        /// 角色權限管理[刪除]
        /// </summary>  
        [Display(Name = "角色權限管理[刪除]")]
        role_management_delete = 14,
        /// <summary>
        /// 操作紀錄查詢[檢視]
        /// </summary>  
        [Display(Name = "操作紀錄查詢[檢視]")]
        logs_management_view = 15,
        /// <summary>
        /// 資料管理
        /// </summary>  
        [Display(Name = "資料管理")]
        datas_management = 16,
        /// <summary>
        /// 標籤集管理
        /// </summary>  
        [Display(Name = "標籤集管理")]
        tags_management = 17,
        /// <summary>
        /// 標籤集管理[檢視]
        /// </summary>  
        [Display(Name = "標籤集管理[檢視]")]
        tags_management_view = 18,
        /// <summary>
        /// 標籤集管理[新增]
        /// </summary>  
        [Display(Name = "標籤集管理[新增]")]
        tags_management_add = 19,
        /// <summary>
        /// 標籤集管理[修改]
        /// </summary>  
        [Display(Name = "標籤集管理[修改]")]
        tags_management_edit = 20,
        /// <summary>
        /// 標籤集管理[刪除]
        /// </summary>  
        [Display(Name = "標籤集管理[刪除]")]
        tags_management_delete = 21,
        /// <summary>
        /// 資料集管理
        /// </summary>  
        [Display(Name = "資料集管理")]
        data_management = 22,
        /// <summary>
        /// 資料集管理[檢視]
        /// </summary>  
        [Display(Name = "資料集管理[檢視]")]
        data_management_view = 23,
        /// <summary>
        /// 資料集管理[新增]
        /// </summary>  
        [Display(Name = "資料集管理[新增]")]
        data_management_add = 24,
        /// <summary>
        /// 資料集管理[修改]
        /// </summary>  
        [Display(Name = "資料集管理[修改]")]
        data_management_edit = 25,
        /// <summary>
        /// 資料集管理[刪除]
        /// </summary>  
        [Display(Name = "資料集管理[刪除]")]
        data_management_delete = 26,
        /// <summary>
        /// 資料集管理[匯入]
        /// </summary>  
        [Display(Name = "資料集管理[匯入]")]
        data_management_import = 27,
        /// <summary>
        /// 資料集活動管理
        /// </summary>  
        [Display(Name = "資料集活動管理")]
        data_event_management = 28,
        /// <summary>
        /// 資料集活動管理[檢視]
        /// </summary>  
        [Display(Name = "資料集活動管理[檢視]")]
        data_event_management_view = 29,
        /// <summary>
        /// 資料集活動管理[新增]
        /// </summary>  
        [Display(Name = "資料集活動管理[新增]")]
        data_event_management_add = 30,
        /// <summary>
        /// 資料集活動管理[修改]
        /// </summary>  
        [Display(Name = "資料集活動管理[修改]")]
        data_event_management_edit = 31,
        /// <summary>
        /// 資料集活動管理[刪除]
        /// </summary>  
        [Display(Name = "資料集活動管理[刪除]")]
        data_event_management_delete = 32,
        /// <summary>
        /// 資料集活動管理[匯入]
        /// </summary>  
        [Display(Name = "資料集活動管理[匯入]")]
        data_event_management_import = 33,
        /// <summary>
        /// 會員標籤管理
        /// </summary>  
        [Display(Name = "會員標籤管理")]
        member_tag_management = 34,
        /// <summary>
        /// 會員標籤管理[檢視]
        /// </summary>  
        [Display(Name = "會員標籤管理[檢視]")]
        member_tag_management_view = 35,
        /// <summary>
        /// 會員標籤管理[新增]
        /// </summary>  
        [Display(Name = "會員標籤管理[新增]")]
        member_tag_management_add = 36,
        /// <summary>
        /// 會員標籤管理[修改]
        /// </summary>  
        [Display(Name = "會員標籤管理[修改]")]
        member_tag_management_edit = 37,
        /// <summary>
        /// 會員標籤管理[刪除]
        /// </summary>  
        [Display(Name = "會員標籤管理[刪除]")]
        member_tag_management_delete = 38,
        /// <summary>
        /// 標籤會員管理
        /// </summary>  
        [Display(Name = "標籤會員管理")]
        tag_management = 39,
        /// <summary>
        /// 標籤會員管理[檢視]
        /// </summary>  
        [Display(Name = "標籤會員管理[檢視]")]
        tag_management_view = 40,
        /// <summary>
        /// 標籤會員管理[新增]
        /// </summary>  
        [Display(Name = "標籤會員管理[新增]")]
        tag_management_add = 41,
        /// <summary>
        /// 標籤會員管理[修改]
        /// </summary>  
        [Display(Name = "標籤會員管理[修改]")]
        tag_management_edit = 42,
        /// <summary>
        /// 標籤會員管理[刪除]
        /// </summary>  
        [Display(Name = "標籤會員管理[刪除]")]
        tag_management_delete = 43,
        /// <summary>
        /// 報表
        /// </summary>  
        [Display(Name = "報表")]
        report = 44,
        /// <summary>
        /// 人營銷售漏斗分析
        /// </summary>  
        [Display(Name = "人營銷售漏斗分析")]
        report_sales_funnel = 46,
        /// <summary>
        /// 人營銷售漏斗分析[檢視]
        /// </summary>  
        [Display(Name = "人營銷售漏斗分析[檢視]")]
        report_sales_funnel_view = 59,
        /// <summary>
        /// 人群特徵分析
        /// </summary>  
        [Display(Name = "人群特徵分析")]
        report_pop_feature = 48,
        /// <summary>
        /// 人群特徵分析[檢視]
        /// </summary>  
        [Display(Name = "人群特徵分析[檢視]")]
        report_pop_feature_view = 60,
        /// <summary>
        /// 廣告效果分析
        /// </summary>  
        [Display(Name = "廣告效果分析")]
        report_advertision_effect = 49,
        /// <summary>
        /// 廣告效果分析[檢視]
        /// </summary>  
        [Display(Name = "廣告效果分析[檢視]")]
        report_advertision_effect_view = 61,
        /// <summary>
        /// 渠道訂單分析
        /// </summary>  
        [Display(Name = "渠道訂單分析")]
        report_channel_order = 50,
        /// <summary>
        /// 渠道訂單分析[檢視]
        /// </summary>  
        [Display(Name = "渠道訂單分析[檢視]")]
        report_channel_order_view = 62,
        /// <summary>
        /// 獨特性及受眾數分布圖
        /// </summary>  
        [Display(Name = "獨特性及受眾數分布圖")]
        report_unique_respondent = 51,
        /// <summary>
        /// 獨特性及受眾數分布圖[檢視]
        /// </summary>  
        [Display(Name = "獨特性及受眾數分布圖[檢視]")]
        report_unique_respondent_view = 63,
        /// <summary>
        /// 資料集活動管理[匯出]
        /// </summary>  
        [Display(Name = "資料集活動管理[匯出]")]
        data_event_management_export = 64,




        /// <summary>
        /// 測試權限
        /// </summary>  
        [Display(Name = "測試權限")]
        role_test = 9999,
    }
}
