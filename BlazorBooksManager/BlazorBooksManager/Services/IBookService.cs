using BlazorBooksManager.Entities;

namespace BlazorBooksManager.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> AddBook(Book book);
        Task<Book> EditBook(int id, Book book);

        Task<bool> DeleteBook(int id);

    }
}
