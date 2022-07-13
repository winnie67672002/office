using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BLL;
using App.Common;
using App.Model;
using App.Model.Common;
using Jose;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    public class ApplyController : ControllerBase
        {
            private IApply _service;

            public ApplyController(IApply service)
            {
                this._service = service;
            }
            
                    /// <summary>
        /// GetList
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("GetList")]
        [HttpPost]
        [AuthorizationFilter]
        public async Task<ResponseBase<List<ApplyGetListResponse>>> GetList([FromBody] ApplyGetListArgs Args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.GetList(Args, jwtPayload);
        }
        /// <summary>
        /// GetData
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("GetData")]
        [HttpPost]
        [AuthorizationFilter]
        public async Task<ResponseBase<ApplyGetDataResponse>> GetData([FromBody] ApplyGetDataArgs Args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.GetData(Args, jwtPayload);
        }
        /// <summary>
        /// SaveData
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("SaveData")]
        [HttpPost]
        //[AuthorizationFilter]
        public async Task<ResponseBase<ApplySaveDataResponse>> SaveData([FromForm] ApplySaveDataArgs Args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.SaveData(Args, jwtPayload);
        }
        /// <summary>
        /// RemoveData
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("RemoveData")]
        [HttpPost]
        [AuthorizationFilter]
        public async Task<ResponseBase<ApplyRemoveDataResponse>> RemoveData([FromBody] ApplyRemoveDataArgs Args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.RemoveData(Args, jwtPayload);
        }
        }
    }
