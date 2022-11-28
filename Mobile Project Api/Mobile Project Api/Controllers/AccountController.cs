using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Project_Api.Business;
using Mobile_Project_Api.Entities;
using Newtonsoft.Json;
using System.Data;

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
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string key = dt.Columns[i].ColumnName;
                    object value = dr[i].ToString();
                    result.Add(key, value);
                }
            }
            jsonResult = JsonConvert.SerializeObject(result);
            return Ok(jsonResult);
        }

        
        
    }
}
