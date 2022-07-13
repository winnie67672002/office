using App.EF.EF.dbofficeApi;
using App.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace App.BLL
{
    public interface IAuthService
    {
        Task<ResponseBase<bool>> CheckAuth(UserAuthArgs Args, JWTPayload jwtPayload);
    }
}
