using App.BLL;
using App.Common;
using App.Model;
using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace App.Api
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        public string Permission { get; set; }
        public bool AccessLog { get; set; } = false;

        public int EnumFunctionId { get; set; }


        public AuthorizationFilter(Enum.Functions enumFunction = Enum.Functions.none)
        {
            this.EnumFunctionId = (int)enumFunction;
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {

            var secret = AppSettingHelper.GetSection("TokenSecret").Value; //加密字串

            string Authorization = actionContext.HttpContext.Request.Headers["Authorization"];

            if (Authorization != null && Authorization.StartsWith("Bearer"))
            {
                try
                {
                    //get service
                    var authService = actionContext.HttpContext.RequestServices.GetService<IAuthService>();
                    //get client ip 
                    var iP = IpHelper.GetClinetIPAddress(actionContext.HttpContext);

                    var jwtToken = Authorization.Substring("Bearer ".Length).Trim();
                    var jwtObject = Jose.JWT.Decode<JWTPayload>(
                            jwtToken,
                            Encoding.UTF8.GetBytes(secret),
                            JwsAlgorithm.HS256);

                    // TODO 驗證是否存在
                    //var taskCheckJWTLive = _service.CheckJWTLive(jwtObject.UserId, jwtToken);
                    //taskCheckJWTLive.Wait();
                    var isLive = true;

                    if (isLive)
                    {
                        //actionContext.HttpContext.Items.Add("jwtPayload", jwtObject);
                        //驗權限
                        var isRoleResult = authService.CheckAuth(new UserAuthArgs() { FunctionId = this.EnumFunctionId, Ip = iP }, jwtObject).Result;
                        var isRole = isRoleResult.Entries;

                        if (isRole)
                            actionContext.HttpContext.Items.Add("jwtPayload", jwtObject);
                        else // 沒權限
                            actionContext.Result = new CustomForbiddenResult("權限不足");
                    }
                    else // 過期
                        actionContext.Result = new UnauthorizedResult();


                }
                catch (Exception ex)
                {
                    actionContext.Result = new UnauthorizedResult();
                }
            }
            else
            {
                actionContext.Result = new UnauthorizedResult();
            }

            base.OnActionExecuting(actionContext);
        }
    }


    public class CustomForbiddenResult : JsonResult
    {
        public CustomForbiddenResult(string message)
            : base(new CustomError(message))
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }
    }

    public class CustomError
    {
        public string Error { get; }

        public CustomError(string message)
        {
            Error = message;
        }
    }



}
