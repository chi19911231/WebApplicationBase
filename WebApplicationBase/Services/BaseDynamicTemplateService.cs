using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using WebApplicationBase.Models.Entities;
using WebApplicationBase.ViewModels;

namespace WebApplicationBase.Services
{
    /// <summary> 主頁 Interface </summary>
    public interface IBaseDynamicTemplateService
    {
        /// <summary> 取得資料 </summary>
        /// <returns></returns>
        IQueryable<FvmDynamic.VM_Data> GetSearchList();

        /// <summary> 取得單一資料 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        Task<FvmDynamic.VM_Data> GetAsync(int id);

        /// <summary> 新增、更新 </summary>
        /// <param name="model">新增、更新 模型</param>
        /// <returns></returns>
        Task UpdateAsync(FvmDynamic.VM_Data model);

        /// <summary> 刪除 </summary>
        /// <param name="id">模型id<</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

    }

    public class BaseDynamicTemplateService: IBaseDynamicTemplateService
    {
        private readonly WebApplicationBaseContext context;

        /// <summary> 建構子 </summary>
        /// <param name="context"></param>
        public BaseDynamicTemplateService(WebApplicationBaseContext context)
        {
            this.context = context;
        }

        /// <summary> 取得所有資料 </summary>
        /// <returns></returns>
        public IQueryable<FvmDynamic.VM_Data> GetSearchList()
        {
            var query = from userInfos in context.UserInfos
                        select new FvmDynamic.VM_Data
                        {
                            Id = userInfos.Id,
                            Acount = userInfos.Acount,
                            Password = userInfos.Password,
                            Name = userInfos.Name,
                            //PersonId = userInfos.PersonId,
                            //Phone = userInfos.Phone,
                            //Address = userInfos.Address,
                            //Email = userInfos.Email,
                        };

            return query;
        }


        /// <summary> 取得單一資料 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        public async Task<FvmDynamic.VM_Data> GetAsync(int id)
        {
            var listDynamicDataModel =  await(from addressInfo in context.AddressInfos                                              
                                              where addressInfo.UserInfoId == id                                             
                                              select new FvmDynamic.VM_DynamicData                                             
                                              {                                               
                                                  DynamicId = addressInfo.Id,
                                                  Address = addressInfo.Address,
                                              }).ToListAsync();

            var model = await (from userInfos in context.UserInfos
                               where userInfos.Id == id
                               select new FvmDynamic.VM_Data
                               {                                   
                                   Id = userInfos.Id,                                   
                                   Acount = userInfos.Acount,                                      
                                   Name = userInfos.Name,                                      
                                   Password = userInfos.Password,                                        
                                   ListDynamicData = listDynamicDataModel,
                               }).FirstOrDefaultAsync();

            if (model == null)
            {
                throw new InvalidDataException("找不到該筆資料");
            }

            return model;
        }


        /// <summary> 新增、更新 </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateAsync(FvmDynamic.VM_Data model)
        {
            //寫法1
            //資料異動如果出問題此SQL交易則取消(RollbackAsync)
            await using (var transaction = await context.Database.BeginTransactionAsync())
            {
                if (model.Id == 0)
                {
                    var objectInfo = new UserInfo()
                    {
                        Acount = model.Acount,
                        Name = model.Name,
                    };
                    await context.UserInfos.AddAsync(objectInfo);
                    context.SaveChanges();

                    int newObjectInfoId = objectInfo.Id;

                    if (model.ListDynamicData != null)
                    {
                        foreach (var item in model.ListDynamicData)
                        {
                            var dynamicObjectInfo = new AddressInfo()
                            {
                                UserInfoId = newObjectInfoId,
                                Address = item.Address,
                            };
                            await context.AddressInfos.AddAsync(dynamicObjectInfo);
                        }
                    }
                    await context.SaveChangesAsync();
                }
                else
                {
                    //主資料更新
                    var entity = await context.UserInfos.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    if (entity == null)
                    {
                        throw new InvalidDataException("找不到該筆資料");
                    }
                    entity.Acount = model.Acount;
                    entity.Name = model.Name;

                    //動態資料(新增、更新、刪除)
                    if (model.ListDynamicData != null)
                    {
                        //動態資料
                        var listDynamicData = model.ListDynamicData;
                       
                        #region 新增
                        var dynamicAddData = listDynamicData.Where(x => x.DynamicId == 0);
                        foreach (var item in dynamicAddData)
                        {
                            var objectInfo = new AddressInfo()                               
                            {                                   
                                UserInfoId = model.Id,                                   
                                Address = item.Address,                                
                            };                               
                            await context.AddressInfos.AddAsync(objectInfo);                 
                        }

                        #endregion

                        #region 更新
                        var dynamicUpdateData = listDynamicData.Where(x => x.DynamicId != 0);
                        foreach (var item in dynamicUpdateData)
                        {
                            var entityUpdateInfo = await context.AddressInfos.Where(x => x.Id == item.DynamicId).FirstOrDefaultAsync()?? new AddressInfo();                            
                            if (entityUpdateInfo.Id != 0)
                            {
                                entityUpdateInfo.Address = item.Address;
                            }
                        }
                        #endregion

                        #region 刪除
                        //原始資料
                        var queryOrigin = context.AddressInfos.Where(x => x.UserInfoId == model.Id).Select(x => x.Id);
                        //差異資料
                        var queryDifference = queryOrigin.Except(listDynamicData.Select(x => x.DynamicId));
                        foreach (var item in queryDifference)
                        {
                            var entityDynamicDelete = await context.AddressInfos.Where(x => x.Id == item).FirstOrDefaultAsync();
                            if (entityDynamicDelete != null)
                            {
                                context.AddressInfos.Remove(entityDynamicDelete);
                            }
                        }
                        #endregion

                    }

                    //因Entity Framework Core會自動追蹤實體的變更，不用呼叫Update() ，呼叫 SaveChangesAsync()會自動更新資料庫。
                    await context.SaveChangesAsync();
                }

                //await context.SaveChangesAsync();
                await transaction.CommitAsync();

            }

            ////舊寫法
            ////風險高，可能發生資料異常問題
            //var baseTable = new BaseTable()
            //{
            //    Title = model.Title,
            //    Content = model.Content,
            //};
            //await context.BaseTables.AddAsync(baseTable);
            //await context.SaveChangesAsync();

        }


        /// <summary> 刪除 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            //寫法1
            //資料異動如果出問題此SQL交易則取消(RollbackAsync)
            await using (var transaction = await context.Database.BeginTransactionAsync())
            {
                var entity = await context.UserInfos.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new InvalidDataException("找不到該筆資料");
                }

                var entityAddress = await context.AddressInfos.Where(x => x.UserInfoId == id).FirstOrDefaultAsync();

                if (entityAddress != null) 
                {
                    // 刪除實體
                    context.AddressInfos.Remove(entityAddress);
                }

                // 刪除實體
                context.UserInfos.Remove(entity);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

            }

            return true;

        }


    }
}
