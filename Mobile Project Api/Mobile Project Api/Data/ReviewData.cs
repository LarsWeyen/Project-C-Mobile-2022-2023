using Mobile_Project_Api.Data.Framework;
using Mobile_Project_Api.Entities;
using NETCore.Encrypt;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Mobile_Project_Api.Data
{
    public class ReviewData : SqlCommands, ISqlCommands<Review>
    {
        private const string tableName = "Reviews";
        public ReviewData() : base(tableName)
        {

        }
        public InsertResult Insert(Review review)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {tableName} ");
                insertQuery.Append($"(ReviewDescription, GameImageId, GameId, GameNaam, UserId, Rating) VALUES ");
                insertQuery.Append($"(@ReviewDescription, @GameImageId, @GameId , @GameNaam,@UserId ,@Rating); ");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@ReviewDescription", SqlDbType.VarChar).Value = review.ReviewDescription;
                    insertCommand.Parameters.Add("@GameImageId", SqlDbType.VarChar).Value = review.GameImageId;            
                    insertCommand.Parameters.Add("@GameId", SqlDbType.VarChar).Value = review.GameId;
                    insertCommand.Parameters.Add("@GameNaam", SqlDbType.VarChar).Value = review.GameNaam;
                    insertCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = review.UserId;
                    insertCommand.Parameters.Add("@Rating", SqlDbType.Int).Value = review.Rating;
                    result = InsertRecord(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public SelectResult SelectReviews(int userId)
        {
            var result = new SelectResult();
            string query = $"select * from Reviews where UserId = '{userId}'";
            base.SelectRecords(query);
            result = (SelectResult)base.BaseResult;
            return result;
        }

        public SelectResult SelectReviewsByGameId(int gameId)
        {
            var result = new SelectResult();
            string query = $"select r.*,u.Username,u.ProfilePicUrl from Reviews r INNER JOIN Users u On r.UserId=u.UserId where GameId = {gameId}";
            base.SelectRecords(query);
            result = (SelectResult)base.BaseResult;
            return result;
        }
        public SelectResult SelectAllReviewsAndOrder(string sortBy, string orderBy)
        {
            var result = new SelectResult();
            string query = $"select * from Reviews order by {sortBy} {orderBy}";
            base.SelectRecords(query);
            result = (SelectResult)base.BaseResult;
            return result;
        }

        public SelectResult Select()
        {
            throw new NotImplementedException();
        }
    }
}
