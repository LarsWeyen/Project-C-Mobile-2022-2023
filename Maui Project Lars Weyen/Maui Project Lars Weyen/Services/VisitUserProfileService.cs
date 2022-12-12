using Maui_Project_Lars_Weyen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Services
{
    public class VisitUserProfileService
    {
        HttpClient client;
        public VisitUserProfileService()
        {
            this.client = new HttpClient();
        }

        public async Task<User> GetUserById(int id)
        {
            var response = await client.GetAsync($"http://192.168.0.145:7777/api/Account/userId/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(responseString);
        }
        public async Task<List<Review>> GetUserReviews(int id)
        {
            var response = await client.GetAsync($"http://192.168.0.145:7777/api/Review?userId={id}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Review>>(responseString);
        }
    }
}
