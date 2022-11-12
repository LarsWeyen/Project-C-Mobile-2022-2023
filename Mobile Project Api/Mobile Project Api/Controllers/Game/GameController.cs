using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Project_Api.Business;
using Newtonsoft.Json;

namespace Mobile_Project_Api.Controllers.Game
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetReviewsFromUser(int gameId)
        {
            string jsonResult;
            var dt = Reviews.GetGameReviews(gameId);
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }
    }
}
