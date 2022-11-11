using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Project_Api.Business;
using Mobile_Project_Api.Entities;
using Newtonsoft.Json;

namespace Mobile_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAccount(string email)
        {
            string jsonResult;
            var dt = Users.GetUser(email);
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }

        
        
    }
}
