using App.EF.EF.dbofficeApi;
using App.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.BLL
{
    public interface ISample
    {
        Task<ResponseBase<List<SampleGetListResponse>>> GetList(SampleGetListArgs Args, JWTPayload jwtPayload);
        Task<ResponseBase<SampleGetDataResponse>> GetData(SampleGetDataArgs Args, JWTPayload jwtPayload);
        Task<ResponseBase<SampleSaveDataResponse>> SaveData(SampleSaveDataArgs Args, JWTPayload jwtPayload);
        Task<ResponseBase<SampleRemoveDataResponse>> RemoveData(SampleRemoveDataArgs Args, JWTPayload jwtPayload);
    }
}