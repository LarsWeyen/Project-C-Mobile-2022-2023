using Maui_Project_Lars_Weyen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Graphics.ColorSpace;

namespace Maui_Project_Lars_Weyen.Services
{
    public class FavoritesService
    {
        HttpClient client;
        public FavoritesService()
        {
            this.client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-ID", "cqehu5ezjkda8sikmpmwqs5596f4zv");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer a7jhn83u76snrv5htrdkt8ia8c7t23");
        }

        public async Task<List<Game>> GetUserFavorites(int userId)
        { 
            var response = await client.GetAsync($"http://192.168.0.145:7777/api/GetAllFavorites?userId={userId}");
            var responseString = await response.Content.ReadAsStringAsync();
            List<Favorite> favorites = JsonConvert.DeserializeObject<List<Favorite>>(responseString);
            List<int> id = new List<int>();
            foreach (var fav in favorites)
            {
                id.Add(fav.GameId);
            }
            string stringIds = String.Join(",", id);
            var content = new StringContent($"fields cover.image_id;where id = ({stringIds});", Encoding.UTF8, "text/plain");
            var responseGameDb = await client.PostAsync("https://api.igdb.com/v4/games/", content);
            var responseStringGameDb = await responseGameDb.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Game>>(responseStringGameDb);
        }
    }
}
