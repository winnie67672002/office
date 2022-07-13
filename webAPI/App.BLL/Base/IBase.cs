using App.EF.EF.dbofficeApi;
using App.Model;
using App.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.BLL
{
    public interface IBase
    {
        ResponseBase<List<EnumResponse>> GetEnumList<T>(int Type = 0);

        ResponseBase<List<EnumResponse>> GetFunction(int Type = 0);
    }
}