using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Models
{
    public class Cover
    {
        public int id { get; set; }
        public string image_id { get; set; }
    }

    public class GameMode
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
        public Color selectedBorder { get; set; }
        public Color selectedLabel { get; set; }
        public Genre()
        {
            string selected = "#868686";
            selectedBorder = Color.FromArgb(selected);
            selectedLabel = Colors.White;
        }
    }

    public class Platform
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Game
    {
        public int id { get; set; }
        public Cover cover { get; set; }
        public List<GameMode> game_modes { get; set; }
        public List<Genre> genres { get; set; }
        public string name { get; set; }
        public List<Platform> platforms { get; set; }
        public List<SimilarGame> similar_games { get; set; }
        public List<Video> videos { get; set; }
    }

    public class SimilarGame
    {
        public int id { get; set; }
        public Cover cover { get; set; }
        public string name { get; set; }
    }

    public class Video
    {
        public int id { get; set; }
        public string video_id { get; set; }
    }


}
