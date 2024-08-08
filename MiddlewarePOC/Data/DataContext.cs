using Microsoft.EntityFrameworkCore;
using MiddlewarePOC.Models;
using System.Collections.Generic;

namespace MiddlewarePOC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
