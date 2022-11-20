using Maui_Project_Lars_Weyen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Services
{
    public class HomeService
    {
        HttpClient client;
        public HomeService()
        {
            this.client = new HttpClient();
        }

        public async Task<List<Review>> GetReviews(string orderBy,string sortBy)
        {
            var response = await client.GetAsync($"http://192.168.0.145:7777/api/Home?sortBy={orderBy}&orderBy={sortBy}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Review>>(responseString);
        }
    }
}
