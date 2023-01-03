using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Project_Api.Business;
using Mobile_Project_Api.Entities;

namespace Mobile_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetFavorite(int userId,int gameId)
        {
            Favorite fav = new Favorite();
            fav.UserId = userId;
            fav.GameId = gameId;
            var dt = Favorites.GetFavoritesDataTable(fav);
            if (dt.Rows.Count == 0)
            {             
                return Ok("IsNotFavorited");
            }
            else
            {
                return Ok("IsFavorited");
            }
        }

        [HttpPost]
        public ActionResult<Favorite> AddOrRemoveToFavorites(Favorite fav)
        {
            var dt = Favorites.GetFavoritesDataTable(fav);
            if (dt.Rows.Count == 0)
            {
                var u = Favorites.AddFavorite(fav);
                return Ok("Item added");
            }
            else
            {
                var s = Favorites.RemoveFavorite(fav);
                return Ok("Item removed");
            }
        }
    }
}
