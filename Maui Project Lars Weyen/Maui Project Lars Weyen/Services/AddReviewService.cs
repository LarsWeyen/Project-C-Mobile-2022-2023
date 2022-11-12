using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Services
{
    public class AddReviewService
    {
        HttpClient client;
        public AddReviewService()
        {
            this.client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-ID", "cqehu5ezjkda8sikmpmwqs5596f4zv");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer 81vpltw4pk08c1x65t3l6abv2qzylc");
        }

        public async Task<List<Game>> SearchGames(string entrySearch)
        {
            var content = new StringContent($"fields name,cover.image_id,videos.*;where name ~ *\"{entrySearch}\"* & version_parent = null & category = 0 & cover.image_id != null;", Encoding.UTF8, "text/plain");
            var response = await client.PostAsync("https://api.igdb.com/v4/games/", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Game>>(responseString);
        }

        public async Task<HttpResponseMessage> AddReview(Dictionary<string,object> postData)
        {
            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
            return await client.PostAsync("http://192.168.0.145:7777/api/Review", content);
            
        }
    }
}
