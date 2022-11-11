using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Project_Api.Business;
using Mobile_Project_Api.Entities;
using Newtonsoft.Json;

namespace Mobile_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetReviewsFromUser(int userId)
        {
            string jsonResult;
            var dt = Reviews.GetUserReviews(userId);
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }
        [HttpPost]
        public ActionResult AddReview(Review review)
        {
            var u = Reviews.AddReview(review);
            return Ok("Review added");
        }
    }
}
