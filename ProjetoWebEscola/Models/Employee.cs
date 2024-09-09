namespace ProjetoWebEscola.Models
{
    public class Employee : ApplicationUser
    {
        public string Position { get; set; } //cargo
        public ICollection<Classes> Class { get; set; } = new List<Classes>();  // Relacionamento com Turmas (um funcionário pode gerenciar várias turmas)

    }
}
