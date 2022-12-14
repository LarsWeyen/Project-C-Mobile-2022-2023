using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Project_Api.Data;
using System.Globalization;

namespace Mobile_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeProfileController : ControllerBase
    {
        [HttpPut]
        public void UpdateLikes(bool like,int userId)
        {
            if (like)
            {
                var userData = new UserData();
                var result = userData.LikeProfile(userId);
            }
            else
            {
                var userData = new UserData();
                var result = userData.UnLikeProfile(userId);
            }
        }
    }
}
