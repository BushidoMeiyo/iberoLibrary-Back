namespace SistemaBiblioteca.Utils
{
    public class Loan : IComparable<Loan>
    {
        public string BookTitle { get; set; }
        public DateTime Date { get; set; }

        public Loan(string bookTitle, DateTime date)
        {
            BookTitle = bookTitle;
            Date = date;
        }

        public int CompareTo(Loan? other)
        {
            return Date.CompareTo(other?.Date ?? DateTime.MinValue);
        }
    }

}
