using App.EF.EF.dbofficeApi;
using App.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL
{
    public class AuthService : ServiceBase, IAuthService
    {
        private IUser _service;

        public AuthService(IUser service)
        {
            this._service = service;
        }

        public async Task<ResponseBase<bool>> CheckAuth(UserAuthArgs Args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<bool>()
            {
                Entries = false,
            };

            try
            {
                if (Args.FunctionId != (int)Enum.Functions.none)
                {
                    //要檢查
                    using (var context = base.dbTemplate(Enum.ConnectionMode.Slave))
                    {
                        var isRole = await (from uong in context.TblUserOnGroup
                                            join fong in context.TblFunctionOnGroup on uong.CUserGroupId equals fong.CUserGroupId
                                            join f in context.TblFunction on new { CFunctionId = fong.CFunctionId } equals new { CFunctionId = f.CId }
                                            where uong.CUserId == jwtPayload.UserId
                                            && uong.CStatus == true
                                            && f.CStatus == (int)Enum.Status.Enable
                                            && Args.FunctionId == f.CId
                                            select f).AnyAsync();

                        if (isRole)
                        {
                           await _service.SetUserLog(new UserSetUserLogArgs() { FunctionId = Args.FunctionId, Ip = Args.Ip }, jwtPayload);
                        }

                        response.Entries = isRole;
                    }
                }
                else
                {
                    //不檢查 直接通過
                    response.Entries = true;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = EnumStatusCode.Fail;
                response.Message = ex.Message;
                _logger.Error(string.Format("SearchIp EX Utc Now:{0}\n EX:{1}", DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss"), ex.ToString()));
            }
            return response;
        }
    }
}
