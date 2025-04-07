namespace SistemaBiblioteca.Models
{
    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public bool Loaned { get; set; } = false;
    }
}
