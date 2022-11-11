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

    public class Game
    {
        public int id { get; set; }
        public Cover cover { get; set; }
        public string name { get; set; }
        public List<Video> videos { get; set; }
    }

    public class Video
    {
        public int id { get; set; }
        public string video_id { get; set; }
    }


}
