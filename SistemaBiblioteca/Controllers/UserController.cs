using Microsoft.AspNetCore.Mvc;
using SistemaBiblioteca.Models;
using SistemaBiblioteca.Utils;

namespace SistemaBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static UserTree _userTree = new();

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto dto)
        {
            var user = new User(dto.Id, dto.Name);
            _userTree.Insert(user);
            return Ok("Usuario registrado.");
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userTree.FindById(id);
            if (user == null) return NotFound("Usuario no encontrado.");
            return Ok(new { user.Id, user.Name });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userTree.RemoveUser(id);
            return Ok("Usuario eliminado.");
        }

        [HttpPost("{id}/loans")]
        public IActionResult AddLoan(int id, [FromBody] LoanDto dto)
        {
            var user = _userTree.FindById(id);
            if (user == null) return NotFound("Usuario no encontrado.");
            user.LoanHistory.Insert(new Loan(dto.BookTitle, DateTime.Now));
            return Ok("Préstamo agregado.");
        }

        [HttpGet("{id}/loans")]
        public IActionResult GetLoanHistory(int id)
        {
            var user = _userTree.FindById(id);
            if (user == null) return NotFound("Usuario no encontrado.");

            var result = new List<string>();
            user.LoanHistory.InOrder(loan => result.Add(loan.ToString()));
            return Ok(result);
        }
    }

}
