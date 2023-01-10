using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Services
{
    public class StartService
    {
        HttpClient client;
        
        public StartService()
        {
            this.client = new HttpClient();        
        }

        public async Task<HttpResponseMessage> LoginUser(Dictionary<string,object> postData)
        {
            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
            return await client.PostAsync("http://192.168.0.145:7777/api/SignIn", content);
        }
        public async Task<HttpResponseMessage> RegisterUser(Dictionary<string, object> postData)
        {
            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
            return await client.PostAsync("http://192.168.0.145:7777/api/Register", content);
        }
    }
}
