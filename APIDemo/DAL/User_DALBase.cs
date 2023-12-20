using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.DAL
{
    public class User_DALBase : DAL_Helpers
    {
        #region Method : dbo.API_Person_SelectAll
        public List<UserModel> API_SELECT_ALL_USER()
        {
            try
            {
                List<UserModel> listOfPerson = new List<UserModel>();
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_SELECT_ALL_USER");
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        UserModel personModel = new UserModel();
                        personModel.UserID = Convert.ToInt32(dataReader["UserID"]);
                        personModel.Name = dataReader["Name"].ToString();
                        personModel.Email = dataReader["Email"].ToString();
                        personModel.Contact = dataReader["Contact"].ToString();
                        listOfPerson.Add(personModel);
                    }

                }
                return listOfPerson;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : dbo.API_Person_SelectByID
        public UserModel API_SELECT_BY_PK_USER(int UserID)
        {
            try
            {

                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_SELECT_BY_PK_USER");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, UserID);
                UserModel userModel = new UserModel();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataReader.Read();
                    userModel.UserID = Convert.ToInt32(dataReader["UserID"].ToString());
                    userModel.Name = dataReader["Name"].ToString();
                    userModel.Email = dataReader["Email"].ToString();
                    userModel.Contact = dataReader["Contact"].ToString();
                }
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
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_DELETE_USER");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
                var user = sqlDatabase.ExecuteNonQuery(dbCommand);
                return user;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        #endregion


        #region Method : API_INSERT_USER
        public int API_INSERT_USER([FromBody] UserModel model)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_INSERT_USER");
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.VarChar, model.Name);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, model.Email);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, model.Contact);
                var user = sqlDatabase.ExecuteNonQuery(dbCommand);
                return user;
            }
            catch (Exception ex)
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
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_UPDATE_USER");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.VarChar, model.Name);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, model.Email);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, model.Contact);
                var user = sqlDatabase.ExecuteNonQuery(dbCommand);
                return user;
            }
            catch (Exception ex)
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
                List<UserModel> listOfPerson = new List<UserModel>();
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_SELECT_FILTER");
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.VarChar, model.Name);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, model.Email);
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        UserModel userModel = new UserModel();
                        userModel.UserID = Convert.ToInt32(dataReader["UserID"]);
                        userModel.Name = dataReader["Name"].ToString();
                        userModel.Email = dataReader["Email"].ToString();
                        userModel.Contact = dataReader["Contact"].ToString();
                        listOfPerson.Add(userModel);
                    }

                }
                return listOfPerson;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
