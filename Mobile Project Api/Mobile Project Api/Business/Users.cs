using Mobile_Project_Api.Data;
using Mobile_Project_Api.Data.Framework;
using Mobile_Project_Api.Entities;
using System.Data;
using System.Security.Principal;

namespace Mobile_Project_Api.Business
{
    public class Users
    {
        public static DataTable GetUser(string Email)
        {
            var dr = new DataTable();
            try
            {
                var registerData = new UserData();
                var result = registerData.SelectUser(Email);
                dr = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return dr;
        }
        public static InsertResult AddUser(User info)
        {
            var result = new InsertResult();
            try
            {
                var registerData = new UserData();
                registerData.Insert(info);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public static DataView GetUserEmail(string Email)
        {
            var dv = new DataView();
            try
            {
                var userData = new UserData();
                var result = userData.SelectEmail(Email);
                dv = result.DataTable.DefaultView;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return dv;
        }
        
    }
}
