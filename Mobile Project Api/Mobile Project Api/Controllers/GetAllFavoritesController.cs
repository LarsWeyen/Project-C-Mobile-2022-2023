using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Project_Api.Business;
using Mobile_Project_Api.Entities;
using Newtonsoft.Json;

namespace Mobile_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllFavoritesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetFavoritesFromUser(int userId)
        {
            string jsonResult;
            var dt = Favorites.GetFavoritesFromUserDataTable(userId);
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }
    }
}
