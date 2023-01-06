using AutoMapper;
using LibraryManagement.Web.DTOs.Books;
using LibraryManagement.Web.Infrastructure;
using LibraryManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Web.Services
{
    public class BookServices : IBookServices
    {
        private readonly DbObject _dbObject;
        private readonly IMapper _mapper;
        public BookServices(DbObject dbObject, IMapper mapper)
        {
            _dbObject = dbObject;
            _mapper = mapper;
        }

        public async Task AddBook(CreateBookDTO newbook)
        {
            var result = _dbObject.BookTable.Add(_mapper.Map<Book>(newbook));
            await _dbObject.SaveChangesAsync();
        }

        public async Task<ServiceResponse<GetBookDTO>> FetchBookData(int BookID)
        {
            ServiceResponse<GetBookDTO> response = new ServiceResponse<GetBookDTO>();
            var result = _dbObject.BookTable.FirstOrDefault(c => c.BookId == BookID);
            if (result == null) {
                response.Message = "The book was not found";
                response.Success = false;
                return response;
            }
            response.Data = _mapper.Map<GetBookDTO>(result);
            response.Message = "Fetched Successfully";
            return response;
        }

        public async Task<ServiceResponse<List<GetBookDTO>>> FetchBookList()
        {
            var response = new ServiceResponse<List<GetBookDTO>>();
            try
            {
                var result = _dbObject.BookTable.ToList();
                response.Data = result.Select(c => _mapper.Map<GetBookDTO>(c)).ToList();
 
            }
            catch (Exception e) {
                response.Message = "List cannot be fetched";
                new Error(e);
            }
            
            return response;
        }

        public async Task<string> RemoveBook(int BookId)
        {
            try
            {
                var result = _dbObject.BookTable.FirstOrDefault(c => c.BookId == BookId);
                if (result == null) {
                    return "Book not found. Enter proper Book Id to delete";
                }
                _dbObject.BookTable.Remove(_mapper.Map<Book>(result));
                await _dbObject.SaveChangesAsync();

                return "Successfully removed";
            }
            catch (Exception e) {
                new Error(e);
                return e.Message;
            }
        }

        public async Task<string> UpdateBook(UpdateBookDTO updateBook)
        {
            var response = new ServiceResponse<UpdateBookDTO>();
            try
            {
                var result = _dbObject.BookTable.First(c => c.BookId == updateBook.BookId);
                if (result == null)
                {
                    response.Message = "Book not found.Enter proper Book Id to Modify";
                    return response.Message;
                }
                result.BookName = updateBook.BookName;
                result.Author = updateBook.Author;
                result.Price = updateBook.Price;
                result.genre = updateBook.genre;
                await _dbObject.SaveChangesAsync();

                response.Message = "Successfully Updated";
                return response.Message;
            }
            catch (Exception e) { 
                response.Success = false;
                response.Message = e.Message;
                new Error(e);
                return response.Message;
            }
        }
    }
}
