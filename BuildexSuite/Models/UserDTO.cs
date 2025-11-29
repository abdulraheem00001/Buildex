namespace BuildexSuite.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime LastLoginAt { get; set; } = DateTime.Now;
        public DateTime LastUpdateAt { get; set; } = DateTime.Now;
    }
}
