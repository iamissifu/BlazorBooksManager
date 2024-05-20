using BlazorBooksManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorBooksManager.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }
    
        public DbSet<Book> Books {  get; set; } 


    }
}
