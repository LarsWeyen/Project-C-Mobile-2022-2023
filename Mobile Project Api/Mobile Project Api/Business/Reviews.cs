using Mobile_Project_Api.Data.Framework;
using Mobile_Project_Api.Data;
using Mobile_Project_Api.Entities;
using System.Data;

namespace Mobile_Project_Api.Business
{
    public class Reviews
    {
        public static InsertResult AddReview(Review review)
        {
            var result = new InsertResult();
            try
            {
                var reviewData = new ReviewData();
                reviewData.Insert(review);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public static DataTable GetUserReviews(int userId)
        {
            var dv = new DataTable();
            try
            {
                var reviewData = new ReviewData();
                var result = reviewData.SelectReviews(userId);
                dv = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return dv;
        }
        public static DataTable GetGameReviews(int gameId)
        {
            var dv = new DataTable();
            try
            {
                var reviewData = new ReviewData();
                var result = reviewData.SelectReviewsByGameId(gameId);
                dv = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return dv;
        }
        public static DataTable GetAllReviews(string sortBy,string orderBy)
        {
            var dv = new DataTable();
            try
            {
                var reviewData = new ReviewData();
                var result = reviewData.SelectAllReviewsAndOrder(sortBy,orderBy);
                dv = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return dv;
        }
    }
}
