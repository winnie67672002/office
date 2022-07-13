using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BLL;
using App.Common;
using App.EF.EF.dbofficeApi;
using App.Enum;
using App.Model;
using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private IBase _service;

        public BaseController(IBase service)
        {
            this._service = service;
        }

        /// <summary>
        /// 狀態
        /// </summary>
        /// <param name="TypeID">1:全选 2:请选择 Other:None</param>
        /// <returns></returns>
        [Route("GetStatus")]
        [HttpPost]
        public ResponseBase<List<EnumResponse>> GetStatus([FromBody] EnumArgs args)
        {
            return _service.GetEnumList<Status>(args.TypeID);
        }

        /// <summary>
        /// Function
        /// </summary>
        /// <param name="TypeID">1:全选 2:请选择 Other:None</param>
        /// <returns></returns>
        [Route("GetFunction")]
        [HttpPost]
        public ResponseBase<List<EnumResponse>> GetFunction([FromBody] EnumArgs args)
        {
            return _service.GetFunction(args.TypeID);
        }
    }
}
