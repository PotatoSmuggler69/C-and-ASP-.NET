using LibraryManagement.Web.DTOs.Books;
using LibraryManagement.Web.Infrastructure;

namespace LibraryManagement.Web.Services
{
    public interface IBookServices
    {
        Task<ServiceResponse<List<GetBookDTO>>> FetchBookList();
        Task<ServiceResponse<GetBookDTO>> FetchBookData(int BookId);
        Task AddBook(CreateBookDTO _newClientInfo);

        Task<String> UpdateBook(UpdateBookDTO updateBook);
        Task<String> RemoveBook(int BookId);
    }
}
