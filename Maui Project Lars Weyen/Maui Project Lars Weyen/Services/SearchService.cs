using Maui_Project_Lars_Weyen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Services
{
    public class SearchService
    {
        HttpClient client;
        public SearchService()
        {
            this.client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-ID", "cqehu5ezjkda8sikmpmwqs5596f4zv");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer a7jhn83u76snrv5htrdkt8ia8c7t23");
        }

        public async Task<List<Game>> SearchGames(string entrySearch)
        {
            var content = new StringContent($"fields name,cover.image_id,videos.video_id;where name ~ *\"{entrySearch}\"* & version_parent = null & category = 0 & cover.image_id != null;", Encoding.UTF8, "text/plain");
            var response = await client.PostAsync("https://api.igdb.com/v4/games/", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Game>>(responseString);
        }

        public async Task<List<Genre>> GetGenres()
        {
            var content = new StringContent($"fields name,id;", Encoding.UTF8, "text/plain");
            var response = await client.PostAsync("https://api.igdb.com/v4/genres/", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Genre>>(responseString);
        }
        public async Task<List<Game>> SearchByGenre(string genre)
        {
            var content = new StringContent($"fields name,genres.name,cover.image_id,videos.video_id;where version_parent = null & category = 0 & cover.image_id != null & genres.name = ({genre});", Encoding.UTF8, "text/plain");
            var response = await client.PostAsync("https://api.igdb.com/v4/games/", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Game>>(responseString);
        }
    }
}
