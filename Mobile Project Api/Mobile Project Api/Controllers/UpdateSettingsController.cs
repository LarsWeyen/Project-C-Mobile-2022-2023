using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Project_Api.Business;
using Mobile_Project_Api.Data.Framework;
using Mobile_Project_Api.Entities;
using System.Data;
using System.Security.Principal;

namespace Mobile_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateSettingsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<User> UpdateAccountSettingsPost(User user)
        {
            if (user.Email != "")
            {
                var dt = Users.GetUser(user.Email);
                ValidateResult result = new ValidateResult();
                var Email = Users.GetUserEmail(user.Email);
                foreach (DataRow dr in dt.Rows)
                {
                    if (Email.Count == 0 || dr[2].ToString() == user.Email)
                    {
                        if (dr[0].ToString() == user.UserId)
                        {
                            var s = Users.UpdateUser(user,true);
                            return Ok("Account settings updated");
                        }
                    }
                    result.AddErrors($"Email already exists");
                    return Ok(result.Errors);
                }
                return Ok("User not found");
            }
            else
            {
                var dt = Users.GetUserById(user.UserId);
                ValidateResult result = new ValidateResult();
                foreach (DataRow dr in dt.Rows)
                {                  
                       if (dr[0].ToString() == user.UserId)
                       {
                            Users.UpdateUser(user,false);
                            return Ok("Account settings updated");
                       }            
                }
                return Ok("User not found");
            }
        }
    }
}
