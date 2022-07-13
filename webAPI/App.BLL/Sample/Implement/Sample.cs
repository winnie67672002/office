using App.EF.EF.dbofficeApi;
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
using App.Enum;

namespace App.BLL
{
    public class Sample : ServiceBase, ISample
    {
        public async Task<ResponseBase<List<SampleGetListResponse>>> GetList(SampleGetListArgs Args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<List<SampleGetListResponse>>()
            {
                Entries = new List<SampleGetListResponse>(),
            };

            try
            {
                await using (var context = base.dbTemplate(Enum.ConnectionMode.Slave))
                {
                    
                     var result = context.TblSample.Select(x => new SampleGetListResponse
                    {
                        cId = x.CId,
                        cTitle = x.CTitle,
                        cDescription = x.CDescription,
                        cType = x.CType,
                        cStartDate = x.CStartDate,
                        cQueryBox = x.CQueryBox,
                        cType2 = x.CType2,
                    });

                    if (!string.IsNullOrEmpty(Args.cType))
                    {
                        result = result.Where(x => x.cType.Contains(Args.cType));
                    }
if (!string.IsNullOrEmpty(Args.cQueryBox))
                    {
                        result = result.Where(x => x.cQueryBox.Contains(Args.cQueryBox));
                    }
if (!string.IsNullOrEmpty(Args.cType2))
                    {
                        result = result.Where(x => x.cType2.Contains(Args.cType2));
                    }

                    response.TotalItems = result.Count();
                    response.Entries = result.Skip((Args.PageIndex - 1) * Args.PageSize).Take(Args.PageSize).ToList();
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
        public async Task<ResponseBase<SampleGetDataResponse>> GetData(SampleGetDataArgs Args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<SampleGetDataResponse>()
            {
                Entries = new SampleGetDataResponse(),
            };

            try
            {
                await using (var context = base.dbTemplate(Enum.ConnectionMode.Slave))
                {
                    var result = context.TblSample.Where(x => x.CId == Args.cId).FirstOrDefault();

                    response.Entries = new SampleGetDataResponse()
                    {
                        cId = result.CId,
                        cTitle = result?.CTitle,
                        cDescription = result?.CDescription,
                        cType = result?.CType,
                        cStartDate = result.CStartDate,
                        cQueryBox = result?.CQueryBox,
                        cType2 = result?.CType2,
                    };
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
        public async Task<ResponseBase<SampleSaveDataResponse>> SaveData(SampleSaveDataArgs Args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<SampleSaveDataResponse>()
            {
                Entries = new SampleSaveDataResponse(),
            };

            try
            {
                await using (var context = base.dbTemplate(Enum.ConnectionMode.Master))
                {
                    //新增編輯主檔
                    //新增編輯主檔
                    var IsAdd = false;
                    var tblSample = new TblSample();

                    tblSample = context.TblSample.Find(Args.cId);
                    if (tblSample == null)
                    {
                        IsAdd = true;
                        tblSample = new TblSample();
                    }

                    tblSample.CId = Args.cId;
                        tblSample.CTitle = Args.cTitle;
                        tblSample.CDescription = Args.cDescription;
                        tblSample.CType = Args.cType;
                        tblSample.CStartDate = Args.cStartDate;
                        tblSample.CQueryBox = Args.cQueryBox;
                        tblSample.CType2 = Args.cType2;

                    if (IsAdd)
                    {

                        context.TblSample.Add(tblSample);
                    }

                    context.SaveChanges();

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
        public async Task<ResponseBase<SampleRemoveDataResponse>> RemoveData(SampleRemoveDataArgs Args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<SampleRemoveDataResponse>()
            {
                Entries = new SampleRemoveDataResponse(),
            };

            try
            {
                await using (var context = base.dbTemplate(Enum.ConnectionMode.Master))
                {
                    context.TblSample.Remove(context.TblSample.Find(Args.cId));
                    context.SaveChanges();
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
