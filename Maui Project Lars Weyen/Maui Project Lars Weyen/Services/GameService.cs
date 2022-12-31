using Maui_Project_Lars_Weyen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Services
{
    public class GameService
    {
        HttpClient client;
        public GameService()
        {
            this.client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-ID", "cqehu5ezjkda8sikmpmwqs5596f4zv");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer a7jhn83u76snrv5htrdkt8ia8c7t23");
        }

        public async Task<Game> GetGame(int id)
        {
            var content = new StringContent($"fields name,cover.image_id,videos.video_id,genres.name,game_modes.name,platforms.name,similar_games.name,similar_games.cover.image_id;where id = {id};", Encoding.UTF8, "text/plain");
            var response = await client.PostAsync("https://api.igdb.com/v4/games/", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Game>>(responseString).First();
        }

        public async Task<List<Review>> GetGameReviews(int gameId)
        {
            var response = await client.GetAsync($"http://192.168.0.145:7777/api/Game?gameId={gameId}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Review>>(responseString);       
        }
        public async Task<HttpResponseMessage> AddToOrRemoveFromFavorites(Dictionary<string, object> postData)
        {
            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
            return await client.PostAsync("http://192.168.0.145:7777/api/Favorites", content);
        }
        public async Task<string> SearchForFavorite(int userId,int gameId)
        {
            var response = await client.GetAsync($"http://192.168.0.145:7777/api/Favorites?userId={userId}&gameId={gameId}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
