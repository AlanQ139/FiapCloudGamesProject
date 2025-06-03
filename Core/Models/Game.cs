namespace Core.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataDeCadastro { get; set; } = DateTime.UtcNow;

        public List<User> Usuarios { get; set; } = new List<User>();
    }

}
