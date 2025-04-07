using SistemaBiblioteca.Models;

namespace SistemaBiblioteca.Services
{
    public class LibraryServices
    {
        public List<Book> Books = new();
        public Queue<Book> QueueLoans = new();
        public Stack<Book> StackReturns = new();

        public List<Book> GetBooks() => Books;

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public bool LoanBook(string isbn)
        {
            var book = Books.FirstOrDefault(l => l.ISBN == isbn);
            if (book == null || book.Loaned) return false;

            book.Loaned = true;
            QueueLoans.Enqueue(book);
            return true;
        }

        public bool ReturnBook(string isbn)
        {
            var book = Books.FirstOrDefault(l => l.ISBN == isbn);
            if (book == null || !book.Loaned) return false;

            book.Loaned = false;
            StackReturns.Push(book);
            return true;
        }
    }
}
