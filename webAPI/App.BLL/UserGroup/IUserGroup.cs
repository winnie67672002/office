using App.EF.EF.dbofficeApi;
using App.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.BLL
{
    public interface IUserGroup
    {
        Task<ResponseBase<List<UserGroupGetListResponse>>> GetList(UserGroupGetListArgs Args, JWTPayload jwtPayload);

        Task<ResponseBase<UserGroupGetDataResponse>> GetData(UserGroupGetDataArgs Args, JWTPayload jwtPayload);

        Task<ResponseBase<UserGroupSaveDataResponse>> SaveData(UserGroupSaveDataArgs Args, JWTPayload jwtPayload);

        Task<ResponseBase<UserGroupRemoveDataResponse>> RemoveData(UserGroupRemoveDataArgs Args, JWTPayload jwtPayload);

    }
}