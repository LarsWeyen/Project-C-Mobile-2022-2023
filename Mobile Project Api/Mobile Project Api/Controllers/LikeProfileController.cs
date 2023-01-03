using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Project_Api.Business;
using Mobile_Project_Api.Data;
using Mobile_Project_Api.Entities;
using System.Globalization;

namespace Mobile_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeProfileController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetProfileLike(int profileId, int userId)
        {
            ProfileLike like = new ProfileLike();
            like.ProfileId = profileId;
            like.UserId = userId;
            var dt = Likes.GetProfileLike(like);
            if (dt.Rows.Count == 0)
            {
                return Ok("NotLiked");
            }
            else
            {
                return Ok("Liked");
            }
        }
        [Route("Update")]
        [HttpPost]
        public void UpdateLikes(UpdateLike update)
        {
            if (update.Like)
            {
                var userData = new UserData();
                var result = userData.LikeProfile(update.UserId);
            }
            else
            {
                var userData = new UserData();
                var result = userData.UnLikeProfile(update.UserId);
            }
        }
        [HttpPost]
        public ActionResult<Favorite> AddOrRemoveProfileLike(ProfileLike like)
        {
            var dt = Likes.GetProfileLike(like);
            if (dt.Rows.Count == 0)
            {
                var u = Likes.AddProfileLike(like);
                return Ok("Item added");
            }
            else
            {
                var s = Likes.RemoveProfileLike(like);
                return Ok("Item removed");
            }
        }
    }
}
