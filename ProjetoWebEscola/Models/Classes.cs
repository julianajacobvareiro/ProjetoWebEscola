namespace ProjetoWebEscola.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
        
    }
}
