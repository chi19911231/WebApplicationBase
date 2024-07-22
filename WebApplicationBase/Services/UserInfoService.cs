using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;
using WebApplicationBase.Commons;
using WebApplicationBase.Enums;
using WebApplicationBase.Models.Entities;
using WebApplicationBase.ViewModels;
using WebApplicationBase.ViewModels.Base;

namespace WebApplicationBase.Services
{

    /// <summary> 主頁 Interface </summary>
    public interface IUserInfoService
    {

        /// <summary> 取得所有資料 </summary>
        /// <returns></returns>
        IQueryable<FvmUserInfo.VM_Data> GetSearchList();

        /// <summary> 取得單一資料 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        Task<FvmUserInfo.VM_Data> GetAsync(int id);

        /// <summary> 更新商品 </summary>
        /// <param name="model">更新模型</param>
        /// <returns></returns>
        Task UpdateAsync(FvmUserInfo.VM_Data model);

        /// <summary> 刪除 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

    }

    /// <summary> 主頁 Service </summary>
    public class UserInfoService: IUserInfoService
    {

        private readonly WebApplicationBaseContext context;

        /// <summary> 建構子 </summary>
        /// <param name="context"></param>
        public UserInfoService(WebApplicationBaseContext context)
        {
            this.context = context;
        }

        /// <summary> 取得所有資料 </summary>
        /// <returns></returns>
        public IQueryable<FvmUserInfo.VM_Data> GetSearchList()
        {
            var query = from userInfos in context.UserInfos select new FvmUserInfo.VM_Data
            {
                ID = userInfos.Id,
                Acount = userInfos.Acount,
                Password = userInfos.Password,
                Name = userInfos.Name,
                PersonId = userInfos.PersonId,
                Phone = userInfos.Phone,
                Address = userInfos.Address,
                Email = userInfos.Email,
            };
            return query;
        }

        /// <summary> 取得單一資料 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        public async Task<FvmUserInfo.VM_Data> GetAsync(int id)
        {
            var model =await( from userInfos in context.UserInfos
                        where userInfos.Id == id
                        select new FvmUserInfo.VM_Data
                        {
                            ID = userInfos.Id,
                            Acount = userInfos.Acount,
                            Password = userInfos.Password,
                            Name = userInfos.Name,
                            PersonId = userInfos.PersonId,
                            Gender = userInfos.Gender.HasValue? (int)userInfos.Gender:0,
                            Phone = userInfos.Phone,
                            Address = userInfos.Address,
                            Email = userInfos.Email,
                        }).FirstOrDefaultAsync();

            if (model == null)   
            {                     
                throw new InvalidDataException("找不到該筆資料");                
            }
            return model;
        }

        /// <summary> 更新商品 </summary>
        /// <param name="model">更新模型</param>
        /// <returns></returns>
        public async Task UpdateAsync(FvmUserInfo.VM_Data model)
        {
            //寫法1
            //資料異動如果出問題此SQL交易則取消(RollbackAsync)
            await using (var transaction = await context.Database.BeginTransactionAsync())
            {
                if (model.ID == 0)
                {
                    var userInfo = new UserInfo()
                    {                         
                        Acount = model.Acount,                         
                        Password = model.Password,                      
                        Name = model.Name,
                        PersonId= model.PersonId,
                        Gender = model.Gender.HasValue?(int)model.Gender : 0,
                        Email = model.Email,
                        Phone = model.Phone,
                        Address = model.Address,               
                    };

                    await context.UserInfos.AddAsync(userInfo);

                }
                else
                {
                    var entity = await context.UserInfos.Where(x => x.Id == model.ID).FirstOrDefaultAsync();

                    if (entity == null)
                    {
                        throw new InvalidDataException("找不到該筆資料");
                    }

                    //因Entity Framework Core會自動追蹤實體的變更，不用呼叫Update() ，呼叫 SaveChangesAsync()會自動更新資料庫。
                    entity.Acount = model.Acount;
                    entity.Password = model.Password;
                    entity.Name = model.Name;
                    entity.PersonId = model.PersonId;
                    entity.Gender = model.Gender.HasValue ? (int)model.Gender : 0;
                    entity.Email = model.Email;
                    entity.Phone = model.Phone;
                    entity.Address = model.Address;

                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();

            }
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

                // 刪除實體
                context.UserInfos.Remove(entity);

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                
            }

            return true;
      
        }

    }
}
