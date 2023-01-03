using Mobile_Project_Api.Business;
using Mobile_Project_Api.Data.Framework;
using Mobile_Project_Api.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Mobile_Project_Api.Data
{
    public class ProfileLikesData : SqlCommands, ISqlCommands<ProfileLike>
    {
        private const string tableName = "ProfileLikes";
        public ProfileLikesData() : base(tableName)
        {

        }

        public InsertResult Insert(ProfileLike t)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {tableName} ");
                insertQuery.Append($"(ProfileId, UserId) VALUES ");
                insertQuery.Append($"(@ProfileId, @UserId); ");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@ProfileId", System.Data.SqlDbType.Int).Value = t.ProfileId;
                    insertCommand.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = t.UserId;
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
            throw new NotImplementedException();
        }

        public SelectResult SelectProfileLike(ProfileLike like)
        {
            var result = new SelectResult();
            string query = $"select * from {tableName} where ProfileId = '{like.ProfileId}' AND UserId = '{like.UserId}'";

            base.SelectRecords(query);
            result = (SelectResult)base.BaseResult;
            return result;
        }
        public DeleteResult Remove(ProfileLike like)
        {
            var result = new DeleteResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"DELETE FROM {tableName} ");
                insertQuery.Append($"where ProfileId = @ProfileId AND UserId = @UserId");

                using (SqlCommand deleteCommand = new SqlCommand(insertQuery.ToString()))
                {
                    deleteCommand.Parameters.Add("@ProfileId", SqlDbType.VarChar).Value = like.ProfileId;
                    deleteCommand.Parameters.Add("@UserId", SqlDbType.VarChar).Value = like.UserId;

                    result = DeleteRecord(deleteCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
    }
}
