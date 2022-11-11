using Maui_Project_Lars_Weyen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Services
{
    public class ProfileService
    {
        HttpClient client;
        User loggedInUser;
        public ProfileService()
        {
            this.client = new HttpClient();
            loggedInUser = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.userInfo), ""));
        }
        public async Task<User> GetUserByEmail()
        {          
            var response = await client.GetAsync($"http://192.168.0.145:7777/api/Account?email={loggedInUser.Email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User[]>(responseString).First();
        }
        public async Task<List<Review>> GetUserReviews()
        {
            var response = await client.GetAsync($"http://192.168.0.145:7777/api/Review?userId={loggedInUser.UserId}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Review>>(responseString);
        }
    }
}
