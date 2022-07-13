using App.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jose;
using App.Common;
using Mapster;

namespace App.BLL
{
    public class Base : ServiceBase, IBase
    {
        /// <summary>
        /// 取得列舉陣列
        /// </summary>
        /// <typeparam name="T">列舉</typeparam>
        /// <param name="Type">1:全选 2:请选择 Other:None</param>
        /// <returns></returns>
        public ResponseBase<List<EnumResponse>> GetEnumList<T>(int Type = 0)
        {

            var response = new ResponseBase<List<EnumResponse>>()
            {
                Entries = new List<EnumResponse>(),
            };

            var objList = new List<EnumResponse>();

            try
            {
                var v = EnumHelper.GetEnumList<T>();

                EnumResponse Gr;

                if (Type == 1)
                {
                    Gr = new EnumResponse();
                    Gr.Id = -1;
                    Gr.Name = "全选";
                    objList.Add(Gr);
                }

                if (Type == 2)
                {
                    Gr = new EnumResponse();
                    Gr.Id = -1;
                    Gr.Name = "请选择";
                    objList.Add(Gr);
                }

                foreach (var item in v)
                {
                    Gr = new EnumResponse();
                    Gr.Id = item.Key;
                    Gr.Name = item.Value;
                    objList.Add(Gr);
                }

                response.Entries = objList;

            }
            catch (Exception ex)
            {
                response.StatusCode = EnumStatusCode.Fail;
                response.Message = ex.Message;
                _logger.Error(string.Format("SearchIp EX Utc Now:{0}\n EX:{1}", DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss"), ex.ToString()));
            }

            return response;
        }

        public ResponseBase<List<EnumResponse>> GetFunction(int Type = 0)
        {
            var response = new ResponseBase<List<EnumResponse>>()
            {
                Entries = new List<EnumResponse>(),
            };

            var objList = new List<EnumResponse>();

            try
            {

                EnumResponse Gr;

                if (Type == 1)
                {
                    Gr = new EnumResponse();
                    Gr.Id = -1;
                    Gr.Name = "全选";
                    objList.Add(Gr);
                }

                if (Type == 2)
                {
                    Gr = new EnumResponse();
                    Gr.Id = -1;
                    Gr.Name = "请选择";
                    objList.Add(Gr);
                }

                using (var context = base.dbTemplate(Enum.ConnectionMode.Slave))
                {

                    //TODO 補權限
                    var Function = (from tblFunction in context.TblFunction
                                     select new EnumResponse
                                     {
                                        Id = tblFunction.CId,
                                        Name = tblFunction.CName,
                                     });
                    objList.AddRange(Function);
                }

                response.Entries = objList;

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
