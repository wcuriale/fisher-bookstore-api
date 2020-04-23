using Microsoft.AspNetCore.Mvc;
using System;
using Fisher.Bookstore.Models;
using Fisher.Bookstore.Services;



namespace Fisher.Bookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController: ControllerBase
    {
        
        [HttpGet]//for all objects
        public IActionResult GetAll()
        {
            return Ok(authorsRepository.GetAuthors());
        }
        [HttpGet("{authorId}")]

        public IActionResult GetAuthor(int authorId)//for specific objects
        {
            if(!authorsRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            return Ok(authorsRepository.GetAuthor(authorId));
        }
        private IAuthorsRepository authorsRepository;
        public AuthorsController(IAuthorsRepository repository)
        {
            authorsRepository = repository;
        }
        [HttpPost]
        public IActionResult Post([FromBody]Author author)//for creating objects
        {
            var authorId = authorsRepository.AddAuthor(author);
            return Created($"https://localhost:5001/api/authors/{authorId}", author);
        }
        [HttpPut("{authorId}")]//for updating objects
        public IActionResult Put(int authorId, [FromBody]Author author)
        {
            if(authorId != author.Id)
            {
                return BadRequest();
            }
            if(!authorsRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            authorsRepository.UpdateAuthor(author);
            return Ok(author);
        }
        [HttpDelete("{authorId}")]//for deleting objects
        public IActionResult Delete(int authorId)
        {
            
            if(!authorsRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            authorsRepository.DeleteAuthor(authorId);
            return Ok();
        }
    }

}