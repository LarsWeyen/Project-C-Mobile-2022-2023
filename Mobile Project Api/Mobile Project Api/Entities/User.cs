namespace Mobile_Project_Api.Entities
{
    public class User
    {
        public string? UserId { get; set; }
        public string? Username { get; set; }
        public string? Bio { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ProfilePicUrl { get; set; }
        public int? ProfileLikes { get; set; }
    }
}
