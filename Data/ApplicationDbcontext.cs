using Microsoft.EntityFrameworkCore;
using onlineBookstore.Models;

namespace onlineBookstore.Data{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options){

        }
        public DbSet<Category> Categories {get;set;}
    }
}