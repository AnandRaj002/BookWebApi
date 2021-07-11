using BookWebApi.Model;
using BookWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookRepository bookRepository;
        public BooksController(IBookRepository repository)
        {
            this.bookRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await bookRepository.GetAllBooks());
            } 
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Not able to get data due to error : {ex.Message}");
            }            
        }

        [HttpGet("Id:int")]
        public async Task<ActionResult<Book>> GetBook(int Id)
        {
            try
            {
                var result = await bookRepository.GetBook(Id);
                if (result == null)
                    return NotFound($"No Book found with Id : {Id}");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Not able to get data due to error : {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest("Please provide book details");
                else
                {
                    var result = await bookRepository.AddBook(book);

                    return CreatedAtAction(nameof(GetBook), new { Id = book.BookId }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Not able to add data due to error : {ex.Message}");
            }
        }

        [HttpPut("Id:int")]
        public async Task<ActionResult<Book>> UpdateBook(int Id, Book book)
        {
            try
            {
                if(book == null)
                    return BadRequest("Please provide book details");
                else
                {
                    var result = await bookRepository.UpdateBook(Id, book);

                    if (result == null)
                        return NotFound($"No Book found with Id : {Id}");
                    
                    return result;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Not able to update data due to error : {ex.Message}");
            }
        }

        [HttpDelete("Id:int")]
        public async Task<ActionResult> DeleteBook(int Id)
        {
            try
            {
                var result = await bookRepository.GetBook(Id);

                if (result == null)
                    return NotFound($"No Book found with Id : {Id}");
                else
                {
                    return Ok(bookRepository.DeleteBook(Id));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Not able to delete data due to error : {ex.Message}");
            }
        }
    }
}
