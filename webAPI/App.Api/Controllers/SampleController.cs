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
    public class SampleController : ControllerBase
        {
            private ISample _service;

            public SampleController(ISample service)
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
        public async Task<ResponseBase<List<SampleGetListResponse>>> GetList([FromBody] SampleGetListArgs Args)
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
        public async Task<ResponseBase<SampleGetDataResponse>> GetData([FromBody] SampleGetDataArgs Args)
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
        [AuthorizationFilter]
        public async Task<ResponseBase<SampleSaveDataResponse>> SaveData([FromBody] SampleSaveDataArgs Args)
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
        public async Task<ResponseBase<SampleRemoveDataResponse>> RemoveData([FromBody] SampleRemoveDataArgs Args)
        {
            JWTPayload jwtPayload = (JWTPayload)HttpContext.Items["jwtPayload"];
            return await _service.RemoveData(Args, jwtPayload);
        }
        }
    }
