﻿using Maui_Project_Lars_Weyen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Services
{
    public class TrendingService
    {
        HttpClient client;
        public TrendingService()
        {
            this.client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-ID", "cqehu5ezjkda8sikmpmwqs5596f4zv");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer 81vpltw4pk08c1x65t3l6abv2qzylc");
        }

        public async Task<List<Game>> GetGames()
        {
            var content = new StringContent($"fields name,cover.image_id,videos.video_id;where name ~ *\"Modern warfare\"* & version_parent = null & category = 0 & cover.image_id != null;;", Encoding.UTF8, "text/plain");
            var response = await client.PostAsync("https://api.igdb.com/v4/games/", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Game>>(responseString);
        }
    }
}
