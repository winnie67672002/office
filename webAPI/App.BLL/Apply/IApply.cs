using App.EF.EF.dbofficeApi;
using App.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.BLL
{
    public interface IApply
    {
        Task<ResponseBase<List<ApplyGetListResponse>>> GetList(ApplyGetListArgs Args, JWTPayload jwtPayload);
        Task<ResponseBase<ApplyGetDataResponse>> GetData(ApplyGetDataArgs Args, JWTPayload jwtPayload);
        Task<ResponseBase<ApplySaveDataResponse>> SaveData(ApplySaveDataArgs Args, JWTPayload jwtPayload);
        Task<ResponseBase<ApplyRemoveDataResponse>> RemoveData(ApplyRemoveDataArgs Args, JWTPayload jwtPayload);
    }
}