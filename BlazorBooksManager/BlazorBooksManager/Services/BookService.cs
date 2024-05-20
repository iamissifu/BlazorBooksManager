using BlazorBooksManager.Data;
using BlazorBooksManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorBooksManager.Services
{
    public class BookService : IBookService

    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBook(int id)
        {
            try
            {
                var dbBook = await _context.Books.FindAsync(id);
                if (dbBook != null)
                {
                    _context.Books.Remove(dbBook);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    // Log that the book was not found
                    Console.WriteLine($"DeleteBook: Book with id {id} was not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"DeleteBook: An error occurred while trying to delete book with id {id}. Exception: {ex.Message}");
                return false;
            }
        }


        public async Task<Book> EditBook(int id, Book book)
        {
            var dbBook = await _context.Books.FindAsync(id);
            if (dbBook != null)
            {
                dbBook.Name = book.Name;
                await _context.SaveChangesAsync();
                return dbBook;
            }

            throw new Exception("Book not found.");
        }

        public async Task<List<Book>> GetAllBooks()
        {

         await Task.Delay(1000);
        
         var books = await _context.Books.ToListAsync();
            return books;
                
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FindAsync(id);
        }
    }
}
