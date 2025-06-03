namespace Core.Models
{
    public enum UserRole { Usuario, Administrador }

    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public UserRole Tipo { get; set; }
        public DateTime DataDeCadastro { get; set; } = DateTime.UtcNow;

        public List<Game> Biblioteca { get; set; } = new List<Game>();
    }

}
