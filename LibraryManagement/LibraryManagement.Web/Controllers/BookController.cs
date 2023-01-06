using LibraryManagement.Web.DTOs.Books;
using LibraryManagement.Web.Infrastructure;
using LibraryManagement.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using System.Data;

namespace LibraryManagement.Web.Controllers
{
    /// <summary>
    /// Book Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _BookService;
        public BookController(IBookServices bookServices)
        {
            _BookService = bookServices;
        }

        /// <summary>
        /// Displays all the books present in the Library
        /// </summary>
        [Authorize(Roles = "Member,Librarian")]
        [HttpGet("GetAll")]
        public ActionResult<List<GetBookDTO>> Getall()
        {
            try
            {
                return Ok(_BookService.FetchBookList());
            }
            catch (Exception e)
            {
                new Error(e);
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Fetches a particular book by providing Book Id
        /// </summary>
        [Authorize(Roles = "Member,Librarian")]
        [HttpGet("GetSpecific")]
        public ActionResult<ServiceResponse<GetBookDTO>> Get(int BookId)
        {
            try
            {
                return Ok(_BookService.FetchBookData(BookId));
            }
            catch (Exception e)
            {
                new Error(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// This is for adding a new Book record.Only Librarian can Access
        /// </summary>
        [Authorize(Roles = "Librarian")]
        [HttpPost("Add Book")]
        public async Task<string> Post(CreateBookDTO _newBook)
        {
            try
            {
                await _BookService.AddBook(_newBook);
                return ("Book added in Library");
            }
            catch (Exception e)
            {
                new Error(e);
                return (e.Message);
            }
        }

        /// <summary>
        /// Editing a new Book record. Only Librarian can Access
        /// </summary>
        [Authorize(Roles = "Librarian")]
        [HttpPut("Edit Book")]
        public async Task<string> Put(UpdateBookDTO _updateBook)
        {
            return await _BookService.UpdateBook(_updateBook);

        }

        /// <summary>
        /// Delete a book record. Only Librarian Access
        /// </summary>
        [Authorize(Roles = "Librarian")]
        [HttpDelete("Remove a Book")]
        public async Task<string> Delete(int BookID)
        {
            return await _BookService.RemoveBook(BookID);

        }
    }
}
