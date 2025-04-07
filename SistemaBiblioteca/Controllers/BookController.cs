using Microsoft.AspNetCore.Mvc;
using SistemaBiblioteca.Models;
using SistemaBiblioteca.Services;

namespace SistemaBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private static LibraryServices libraryServices = new LibraryServices();

        [HttpGet("getBook")]
        public IActionResult GetBooks() => Ok(libraryServices.GetBooks());

        [HttpPost("addBook")]

        public IActionResult AddBook([FromBody] Book book)
        {
            libraryServices.AddBook(book);
            return Ok("Libro agregado.");
        }

        [HttpPut("loanBook/{isbn}")]
        public IActionResult LoanBook(string isbn)
        {
            var resultado = libraryServices.LoanBook(isbn);
            return resultado ? Ok("Libro prestado.") : NotFound("No disponible.");
        }

        [HttpPut("returnBook/{isbn}")]
        public IActionResult ReturnBook(string isbn)
        {
            var result = libraryServices.ReturnBook(isbn);
            return result ? Ok("Libro devuelto.") : NotFound("No prestado.");
        }
    }
}
