using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;
using PubAPI.Service;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _service.GetAllAuthors();
            return Ok(authors);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorModel authorModel)
        {
            if (id != authorModel.AuthorId)
            {
                return BadRequest();
            }
            var res = await _service.UpdateAuthor(id, authorModel);
            return Ok(res);
        }

        //// POST: api/Authors
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostAuthor(AuthorModel authorModel)
        {
            var res = await _service.AddAuthor(authorModel);
            return Ok(res);
        }

        //// DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
           var res = await _service.DeleteAuthorById(id);
           return Ok(res);
           
        }

        //private bool AuthorExists(int id)
        //{
        //    return _context.Author.Any(e => e.AuthorId == id);
        //}
    }
}
