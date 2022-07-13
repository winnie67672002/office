using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BLL;
using App.Common;
using App.EF.EF.dbofficeApi;
using App.Model;
using Jose;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        private IUser _service;

        public UserController(IUser service, IHttpContextAccessor accessor)
        {
            this._service = service;
            this._accessor = accessor;
        }
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="request">參數</param>
        /// <returns></returns>
        [Route("UserLogin")]
        [HttpPost]
        public async Task<ResponseBase<string>> UserLogin([FromBody]UserLoginRequest request)
        {
            var clientIP = IpHelper.GetClinetIPAddress(_accessor.HttpContext);
            return await _service.UserLogin(request,  clientIP);
        }

        /// <summary>
        /// 選單
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [Route("GetMenu")]
        [HttpPost]
        [AuthorizationFilter]
        public async Task<ResponseBase<GetMenuResponse>> GetMenu([FromBody] GetMenuArgs args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.GetMenu(args, jwtPayload);
        }


        /// <summary>
        /// 取得使用者列表
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("GetList")]
        [HttpPost]
        [AuthorizationFilter(Enum.Functions.user_management_view)]
        public async Task<ResponseBase<List<UserGetListResponse>>> GetList([FromBody] UserGetListArgs Args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.GetList(Args, jwtPayload);
        }

        /// <summary>
        /// 取得使用者資料
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("GetData")]
        [HttpPost]
        [AuthorizationFilter(Enum.Functions.user_management_view)]
        public async Task<ResponseBase<UserGetDataResponse>> GetData([FromBody] UserGetDataArgs Args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.GetData(Args, jwtPayload);
        }

        /// <summary>
        /// 使用者新增
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("AddData")]
        [HttpPost]
        [AuthorizationFilter(Enum.Functions.user_management_add)]
        public async Task<ResponseBase<UserSaveDataResponse>> AddData([FromBody] UserSaveDataArgs Args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.SaveData(Args, jwtPayload);
        }

        /// <summary>
        /// 使用者存檔
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("SaveData")]
        [HttpPost]
        [AuthorizationFilter(Enum.Functions.user_management_edit)]
        public async Task<ResponseBase<UserSaveDataResponse>> SaveData([FromBody] UserSaveDataArgs Args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.SaveData(Args, jwtPayload);
        }

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("RemoveData")]
        [HttpPost]
        [AuthorizationFilter(Enum.Functions.user_management_delete)]
        public async Task<ResponseBase<UserRemoveDataResponse>> RemoveData([FromBody] UserRemoveDataArgs Args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.RemoveData(Args, jwtPayload);
        }


        /// <summary>
        /// 取得操作記錄
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("GetUserLog")]
        [HttpPost]
        [AuthorizationFilter(Enum.Functions.logs_management_view)]
        public async Task<ResponseBase<List<UserGetUserLogResponse>>> GetUserLog([FromBody] UserGetUserLogArgs Args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.GetUserLog(Args, jwtPayload);
        }

    }
}
