using Mobile_Project_Api.Data.Framework;
using Mobile_Project_Api.Data;
using Mobile_Project_Api.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Mobile_Project_Api.Business
{
    public class Favorites
    {
        public static InsertResult AddFavorite(Favorite fav)
        {
            var result = new InsertResult();
            try
            {
                var favoriteData = new FavoriteData();
                favoriteData.Insert(fav);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public static DataTable GetFavoritesDataTable(Favorite fav)
        {
            var dt = new DataTable();
            try
            {
                var favoriteData = new FavoriteData();
                var result = favoriteData.SelectoFavorite(fav);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return dt;
        }
        public static DataTable GetFavoritesFromUserDataTable(int userId)
        {
            var dt = new DataTable();
            try
            {
                var favoriteData = new FavoriteData();
                var result = favoriteData.SelectUserFavorites(userId);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return dt;
        }
        public static UpdateResult RemoveFavorite(Favorite fav)
        {
            var result = new UpdateResult();
            try
            {
                var favoriteData = new FavoriteData();
                favoriteData.Remove(fav);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        
    }
}
