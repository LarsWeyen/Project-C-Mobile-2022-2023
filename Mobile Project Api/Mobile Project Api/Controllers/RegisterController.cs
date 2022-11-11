using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Project_Api.Business;
using Mobile_Project_Api.Entities;
using NETCore.Encrypt;
using Newtonsoft.Json;
using System.Data;
using System.Security.Principal;

namespace Mobile_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAccount()
        {
            return Ok("huts");
        }
        [HttpPost]
        public ActionResult<User> RegisterUser(User user)
        {
            string jsonResult;
            Dictionary<string, object> resulte = new Dictionary<string, object>();
            var dt = Users.GetUser(user.Email);
            if (dt.Rows.Count == 0)
            {
                var s = Users.AddUser(user);
                var dataTable = Users.GetUser(user.Email);
                foreach (DataRow dr in dataTable.Rows)
                {                                      
                            
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                string key = dt.Columns[i].ColumnName;
                                object value = dr[i].ToString();
                                resulte.Add(key, value);
                            }
                                                        
                }
                return Ok(jsonResult = JsonConvert.SerializeObject(resulte));
            }
            else
            {
                return Ok("Email is used!");
            }
        }
    }
}
