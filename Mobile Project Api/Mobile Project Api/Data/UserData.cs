using Mobile_Project_Api.Data.Framework;
using Mobile_Project_Api.Entities;
using System.Data.SqlClient;
using NETCore.Encrypt;
using System.Data;
using System.Security.Principal;
using System.Text;

namespace Mobile_Project_Api.Data
{
    public class UserData : SqlCommands, ISqlCommands<User>
    {
        private const string tableName = "Users";
        public UserData() : base(tableName)
        {

        }

        public static string GenerateRSA()
        {
            var aesKey = EncryptProvider.CreateAesKey();
            var key = aesKey.Key;
            return key;
        }

        public InsertResult Insert(User user)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {tableName} ");
                insertQuery.Append($"(Username, Email, Password,PasswordKey,ProfilePicUrl,ProfileLikes) VALUES ");
                insertQuery.Append($"(@Username, @Email, @Password , @PasswordKey,@ProfilePicUrl,@ProfileLikes); ");

                string passwordKey = GenerateRSA();
                var encryptedPass = EncryptProvider.AESEncrypt(user.Password, passwordKey);

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = user.Username;
                    insertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;                  
                    insertCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = encryptedPass;
                    insertCommand.Parameters.Add("@PasswordKey", SqlDbType.VarChar).Value = passwordKey;
                    insertCommand.Parameters.Add("@ProfilePicUrl", SqlDbType.VarChar).Value = user.ProfilePicUrl;
                    insertCommand.Parameters.Add("@ProfileLikes", SqlDbType.VarChar).Value = user.ProfileLikes;
                    result = InsertRecord(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public SelectResult Select()
        {
            var result = new SelectResult();
            base.SelectRecords();
            result = (SelectResult)base.BaseResult;
            return result;
        }

        public SelectResult SelectUser(string Email)
        {
            var result = new SelectResult();
            string query = $"select * from Users where Email = '{Email}'";          
            base.SelectRecords(query);
            result = (SelectResult)base.BaseResult;
            return result;
        }
        public SelectResult SelectEmail(string Email)
        {
            var result = new SelectResult();
            string query = $"select * from Users where Email = '{Email}'";
            base.SelectRecords(query);
            result = (SelectResult)base.BaseResult;
            return result;
        }
    }
}
