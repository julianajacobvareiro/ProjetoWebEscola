namespace ProjetoWebEscola.Models
{
    public class Student : ApplicationUser
    {
        public string Enroll { get; set; } //matricula

        public string Name { get; set; }
        public ICollection<Note> Notes { get; set; } = new List<Note>();
       
    }
}
