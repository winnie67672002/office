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
using Newtonsoft.Json;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.IO;

namespace App.BLL
{
    public class Apply : ServiceBase, IApply
    {

        private readonly IHostingEnvironment _hostingEnvironment; // 取得網站根目錄

        public Apply(IHostingEnvironment hostingEnvironment)
        {
            
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<ResponseBase<List<ApplyGetListResponse>>> GetList(ApplyGetListArgs Args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<List<ApplyGetListResponse>>()
            {
                Entries = new List<ApplyGetListResponse>(),
            };

            try
            {
                await using (var context = base.dbofficeApi(Enum.ConnectionMode.Slave))
                {
                    var applydata = (
                              from s in context.TblApply
                              select new ApplyGetListResponse()
                              {
                                  cId=s.CId,
                                  cFormNo = s.CFormNo,
                                  cApplyEmpName = s.CApplyEmpName,
                                  cApplyDept = s.CApplyDept,
                                  cApplyDate = s.CApplyDate,
                                  cCostingNo = s.CCostingNo,
                                  cFile = s.CFile,
                                  cRemark = s.CRemark,
                                  cGoodName = string.Join(",", (from a in context.TblGoods
                                                                join b in context.TblApplyItem on a.CId equals b.CGoodsId
                                                                where (b.CApplyId == s.CId)
                                                                select a.CGoodsName).ToList()

                              )
                              }).ToList();

                    if (!string.IsNullOrEmpty(Args.queryName))
                    {
                        applydata = applydata.Where(x => x.cApplyEmpName.Contains(Args.queryName)).ToList();
                    }


                    if (!string.IsNullOrEmpty(Args.queryDept))
                    {
                        applydata = applydata.Where(x => x.cApplyDept.Contains(Args.queryDept)).ToList();
                    }
                    if (Args.startYear != null && Args.endYear != null)
                    {
                        applydata = applydata.Where(x => x.cApplyDate > Args.startYear && x.cApplyDate < Args.endYear).ToList();
                    }



                    response.TotalItems = applydata.Count();
                    response.Entries = applydata.Skip((Args.PageIndex - 1) * Args.PageSize).Take(Args.PageSize).ToList();
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
        public async Task<ResponseBase<ApplyGetDataResponse>> GetData(ApplyGetDataArgs Args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<ApplyGetDataResponse>()
            {
                Entries = new ApplyGetDataResponse(),
            };

            try
            {
                await using (var context = base.dbofficeApi(Enum.ConnectionMode.Slave))
                {
                    var result = context.TblApply.Where(x => x.CId == Args.cId).FirstOrDefault();
                    if (result != null)
                    {
                        response.Entries = new ApplyGetDataResponse()
                        {

                            cId = result.CId,
                            cFormNo = result.CFormNo,
                            cApplyEmpName = result.CApplyEmpName,
                            cApplyDept = result.CApplyDept,
                            cApplyDate = result.CApplyDate,
                            cCostingNo = result.CCostingNo,
                            cFile = result.CFile,
                            cRemark = result.CRemark,
                            Items = (from a in context.TblGoods
                                     join b in context.TblApplyItem on a.CId equals b.CGoodsId
                                     where (b.CApplyId == result.CId)
                                     select new OfficeDetailsItemsResponse()
                                     {

                                         CoodName = a.CGoodsName,
                                         Count = b.CCount


                                     }).ToList()

                        };

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
        public async Task<ResponseBase<ApplySaveDataResponse>> SaveData(ApplySaveDataArgs Args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<ApplySaveDataResponse>()
            {
                Entries = new ApplySaveDataResponse(),
            };

            try
            {
               using (var context = base.dbofficeApi(Enum.ConnectionMode.Master))
                {
                    //新增編輯主檔

                    var Detail = JsonConvert.DeserializeObject<List<Detail>>(Args.items);


                    var IsAdd = false;
                    var tblApply = context.TblApply.Find(Args.cId);
                    if (tblApply == null)
                    {
                        IsAdd = true;
                        tblApply = new TblApply();
                    }


                    var now = DateTime.Now;
                    var statrDT = new DateTime(now.Year, now.Month, now.Day);
                    var endDT = statrDT.AddMonths(1);
                    var count = context.TblApply.Where(x => x.CApplyDate >= statrDT && x.CApplyDate < endDT).Count();
                    count = count + 1;

                    var file = Args.UploadFile;
                    if (file.Length > 0)
                    {
                        var path = $@"{_hostingEnvironment.WebRootPath}\uploads\{file.FileName}";
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }


                    var dbApplyItem = context.TblApplyItem.Where(x => x.CApplyId == tblApply.CId).ToList();
                    tblApply.CFormNo = $"A{now:yyyyMM}{count:000}";
                    tblApply.CApplyEmpName = Args.cApplyEmpName;
                    tblApply.CApplyDept = Args.cApplyDept;
                    tblApply.CApplyDate = Args.cApplyDate;
                    tblApply.CCostingNo = Args.cCostingNo;
                    tblApply.CRemark = Args.cRemark;
                    tblApply.CFile = file.FileName;

                    if (IsAdd == true)
                    {
                        context.TblApply.Add(tblApply);
                    }


                    context.SaveChanges();
                    context.TblApplyItem.RemoveRange(dbApplyItem);

                    foreach (var item in Detail)
                    {
                        var tblApplyItem = new TblApplyItem();
                        tblApplyItem.CApplyId = tblApply.CId;
                        tblApplyItem.CGoodsId = item.Id;
                        tblApplyItem.CCount = item.Count;
                        context.TblApplyItem.Add(tblApplyItem);

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
        public async Task<ResponseBase<ApplyRemoveDataResponse>> RemoveData(ApplyRemoveDataArgs Args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<ApplyRemoveDataResponse>()
            {
                Entries = new ApplyRemoveDataResponse(),
            };

            try
            {
                await using (var context = base.dbofficeApi(Enum.ConnectionMode.Master))
                {
                    context.TblApply.Remove(context.TblApply.Find(Args.cId));
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
