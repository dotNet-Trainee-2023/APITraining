using APITraining.Models;
using Microsoft.EntityFrameworkCore;

namespace APITraining.Data
{
    public class ApiDBContext : DbContext
    {

        public ApiDBContext(DbContextOptions dbContextOptions): base(dbContextOptions) 
        { 
        }

        public DbSet<Place> Places { get; set; }

    }
}
