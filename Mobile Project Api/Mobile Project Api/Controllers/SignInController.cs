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
    public class SignInController : ControllerBase
    {
        
        [HttpPost]
        public ActionResult SignInUser(SignIn user)
        {
            string jsonResult;
            var Email = Users.GetUserEmail(user.Email);
            var dt = Users.GetUser(user.Email);
            if (Email.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[2].ToString() == user.Email)
                    {
                        var encryptedPass = EncryptProvider.AESEncrypt(user.Password, dr[4].ToString());
                        if (dr[3].ToString() == encryptedPass)
                        {
                            Dictionary<string, object> resulte = new Dictionary<string, object>();
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                string key = dt.Columns[i].ColumnName;
                                object value = dr[i].ToString();
                                resulte.Add(key, value);
                            }
                            return Ok(jsonResult = JsonConvert.SerializeObject(resulte));
                        }
                        return Ok("User not found");
                    }
                }
            }
            return Ok("User not found");
        }
    }
}
