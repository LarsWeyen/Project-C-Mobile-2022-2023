using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewDescription { get; set; }
        public string GameImageId { get; set; }
        public int GameId { get; set; }
        public string GameNaam { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
    }
}
