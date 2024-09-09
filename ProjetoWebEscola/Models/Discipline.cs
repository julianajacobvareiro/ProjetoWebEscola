namespace ProjetoWebEscola.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public Classes Classes { get; set; }

        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
