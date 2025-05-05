namespace SistemaBiblioteca.Utils
{
    public class User : IComparable<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LoanHistoryTree LoanHistory { get; set; } = new();

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int CompareTo(User? other)
        {
            return Id.CompareTo(other?.Id);
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
