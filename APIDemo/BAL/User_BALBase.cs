using APIDemo.DAL;
using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace APIDemo.BAL
{
    public class User_BALBase
    {
        #region API_SELECT_ALL_USER
        public List<UserModel> API_SELECT_ALL_USER()
        {
            try {
                User_DALBase userDALBase = new User_DALBase();
                List<UserModel> userModels = userDALBase.API_SELECT_ALL_USER();
                return userModels;
            }
            catch {
                return null;
            }
        }
        #endregion

        #region Method : dbo.API_SELECT_BY_PK_USER
        public UserModel API_SELECT_BY_PK_USER(int UserID)
        {
            try
            {
                User_DALBase userDALBase = new User_DALBase();
                UserModel userModel = userDALBase.API_SELECT_BY_PK_USER(UserID);
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : dbo.API_DELETE_USER
        public int API_DELETE_USER(int UserID)
        {
            try
            {
                User_DALBase userDALBase = new User_DALBase();
                var user = userDALBase.API_DELETE_USER(UserID);
                return user;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        #endregion


        #region Method : API_INSERT_USER
        public int API_INSERT_USER(UserModel model)
        {
            try
            {
                User_DALBase userDALBase = new User_DALBase();
                var user = userDALBase.API_INSERT_USER(model);
                return user;
            }
            catch
            {
                return 0;
            }
        }
        #endregion


        #region Method : API_UPDATE_USER
        public int API_UPDATE_USER(USerPostModel model,int UserID)
        {
            try
            {
                User_DALBase userDALBase = new User_DALBase();
                var user = userDALBase.API_UPDATE_USER(model,UserID);
                return user;
            }
            catch
            {
                return 0;
            }
        }
        #endregion


        #region Method : API_SELECT_FILTER
        public List<UserModel> API_SELECT_FILTER(UserFilterModel model)
        {
            try
            {
                User_DALBase userDALBase = new User_DALBase();
                List<UserModel> userModels = userDALBase.API_SELECT_FILTER(model);
                return userModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
