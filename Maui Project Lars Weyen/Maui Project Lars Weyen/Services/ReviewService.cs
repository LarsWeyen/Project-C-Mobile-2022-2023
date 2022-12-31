using Maui_Project_Lars_Weyen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Services
{
    public class ReviewService
    {
        HttpClient client;
        
        public ReviewService()
        {
            this.client = new HttpClient();
        }

        public async Task<Review> GetReview(int reviewId)
        {
            var response = await client.GetAsync($"http://192.168.0.145:7777/api/Review/reviewId/{reviewId}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Review>>(responseString).First();
        }
    }
}
