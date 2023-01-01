using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Project_Api.Business;
using Newtonsoft.Json;
using System.Data;

namespace Mobile_Project_Api.Controllers.Game
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrendingGamesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetTrendingGames()
        {
            string jsonResult;
            var dt = Reviews.GetTrendingGamesDataTable();        
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }
    }
}
