using Microsoft.AspNetCore.Mvc;
using PublisherDomain;
using PubAPI.Service;
using PubAPI.Model;

namespace PubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _service;

        public AuthorsController(AuthorService service)
        {
            _service = service;
        }

        // GET: api/Authors
        [HttpGet("GetAllAuthors")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _service.GetAllAuthors();
            return Ok(authors);
        }

        // GET: api/Author/5
        [HttpGet("GetAuthor/{id}")]
        public async Task<ActionResult<AuthorModel>> GetAuthor(int id)
        {
            var authorModel = await _service.GetAuthorById(id);

            if (authorModel == null)
            {
                return NotFound();
            }

            return authorModel;
        }

     
        //// PUT: api/Authors/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, AuthorModel authorModel)
        {
            if (id != authorModel.Id)
            {
                return BadRequest();
            }
            var res = await _service.UpdateAuthor(id, authorModel);
            return Ok(res);
        }

        //// POST: api/Authors
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor(AuthorModel authorModel)
        {
            var res = await _service.AddAuthor(authorModel);
            return Ok(res);
        }

        //// DELETE: api/Authors/5
        [HttpDelete("DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
           var res = await _service.DeleteAuthorById(id);
           return Ok(res);
           
        }

        [HttpPost("AddMultipleAuthor")]
        public async Task<IActionResult> AddMultipleAuthor(List<AuthorModel> authorModels)
        {
            var res = await _service.AddMultipleAuthors(authorModels); 
            return Ok(res);
        }

        //private bool AuthorExists(int id)
        //{
        //    return _context.Author.Any(e => e.AuthorId == id);
        //}
    }
}
