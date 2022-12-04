using Mobile_Project_Api.Data.Framework;
using Mobile_Project_Api.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Mobile_Project_Api.Data
{
    public class FavoriteData : SqlCommands, ISqlCommands<Favorite>
    {
        private const string tableName = "Favorites";
        public FavoriteData() : base(tableName)
        {

        }

        public InsertResult Insert(Favorite fav)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {tableName} ");
                insertQuery.Append($"(UserId, GameId) VALUES ");
                insertQuery.Append($"(@UserId, @GameId); ");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = fav.UserId;
                    insertCommand.Parameters.Add("@GameId", System.Data.SqlDbType.Int).Value = fav.GameId;                  
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

        public SelectResult SelectoFavorite(Favorite fav)
        {
            var result = new SelectResult();
            string query = $"select * from {tableName} where UserId = '{fav.UserId}' AND GameID = '{fav.GameId}'";

            base.SelectRecords(query);
            result = (SelectResult)base.BaseResult;
            return result;
        }
        public SelectResult SelectUserFavorites(int userId)
        {
            var result = new SelectResult();
            string query = $"select * from {tableName} where UserId = '{userId}'";

            base.SelectRecords(query);
            result = (SelectResult)base.BaseResult;
            return result;
        }
        public DeleteResult Remove(Favorite fav)
        {
            var result = new DeleteResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"DELETE FROM {tableName} ");
                insertQuery.Append($"where UserId = @UserId AND GameId = @GameId");

                using (SqlCommand deleteCommand = new SqlCommand(insertQuery.ToString()))
                {
                    deleteCommand.Parameters.Add("@UserId", SqlDbType.VarChar).Value = fav.UserId;
                    deleteCommand.Parameters.Add("@GameId", SqlDbType.VarChar).Value = fav.GameId;

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
