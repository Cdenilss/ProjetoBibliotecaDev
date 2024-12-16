using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        [HttpPost]
        // Post api/Loans
        public IActionResult PostLoan(CreateLoanInputModel model)
        {
            return Created();
        }
        
        //GET api/Loand/1234

        [HttpGet("{id}")]
        public IActionResult GetLoanById(int id)
        {
            return Ok();
        }
        
        
        // criar um upadat nos loans
    }
}