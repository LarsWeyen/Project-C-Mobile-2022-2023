using Maui_Project_Lars_Weyen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Services
{
    public class SettingsService
    {
        HttpClient client;
        User loggedInUser;
        public SettingsService()
        {
            this.client = new HttpClient();
            loggedInUser = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.userInfo), ""));
        }

        public async Task<User> GetUserByEmail()
        {
            var response = await client.GetAsync($"http://192.168.0.145:7777/api/Account?email={loggedInUser.Email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(responseString);
        }

        public async Task<string> GetUserString()
        {
            var response = await client.GetAsync($"http://192.168.0.145:7777/api/Account?email={loggedInUser.Email}");
            return await response.Content.ReadAsStringAsync();      
        }

        public async Task<HttpResponseMessage> UpdateSettings(Dictionary<string,object> postData)
        {
            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
            return await client.PostAsync("http://192.168.0.145:7777/api/UpdateSettings", content);   
        }
    }
}
