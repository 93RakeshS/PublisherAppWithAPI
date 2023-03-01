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

        [HttpGet("GetAllAuthors")]
        public async Task<ActionResult<IEnumerable<AuthorModel>>> GetAuthors()
        {
            try
            {
                var authors = await _service.GetAllAuthors();
                return Ok(authors);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
                
        }

        [HttpGet("GetAuthor/{id}")]
        public async Task<ActionResult<AuthorModel>> GetAuthor(int id)
        {
            try
            {
                var authorModel = await _service.GetAuthorById(id);

                if (authorModel == null)
                {
                    return NotFound();
                }

                return authorModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateAuthor/{id}")]
        public async Task<ActionResult<AuthorModel>> UpdateAuthor(int id, AuthorModel authorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != authorModel.Id)
                    {
                        return BadRequest();
                    }
                    var author = await _service.UpdateAuthor(id, authorModel);
                    if (author != null)
                    {
                        return author;
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor(AuthorModel authorModel)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var res = await _service.AddAuthor(authorModel);
                    return Ok(res);
                }   
                else
                { 
                    return BadRequest(ModelState); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var res = await _service.DeleteAuthorById(id);
                return (res==true)?Ok("Author Deleted"):NotFound("Author Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddMultipleAuthor")]
        public async Task<ActionResult<IEnumerable<AuthorModel>>> AddMultipleAuthor(IEnumerable<AuthorModel> authorModels)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _service.AddMultipleAuthors(authorModels);
                    return Ok(res);
                }
                else
                { 
                    return BadRequest(ModelState); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
