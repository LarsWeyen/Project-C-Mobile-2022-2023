using Mobile_Project_Api.Data;
using Mobile_Project_Api.Data.Framework;
using Mobile_Project_Api.Entities;
using System.Data;

namespace Mobile_Project_Api.Business
{
    public class Likes
    {
        public static DataTable GetProfileLike(ProfileLike like)
        {
            var dt = new DataTable();
            try
            {
                var profileLikesData = new ProfileLikesData();
                var result = profileLikesData.SelectProfileLike(like);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return dt;
        }
        
        public static InsertResult AddProfileLike(ProfileLike like)
        {
            var result = new InsertResult();
            try
            {
                var profileLikesData = new ProfileLikesData();
                profileLikesData.Insert(like);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public static UpdateResult RemoveProfileLike(ProfileLike like)
        {
            var result = new UpdateResult();
            try
            {
                var profileLikesData = new ProfileLikesData();
                profileLikesData.Remove(like);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
    }
}
