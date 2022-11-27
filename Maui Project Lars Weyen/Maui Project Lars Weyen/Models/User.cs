using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Password { get; set; }
        public string PasswordKey { get; set; }
        public string ProfilePicUrl { get; set; }
        public int? ProfileLikes { get; set; }
    }
}
