namespace Core.Models
{
    public enum UserRole { Usuario, Administrador }

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<Game> Library { get; set; } = new List<Game>();
    }


}
