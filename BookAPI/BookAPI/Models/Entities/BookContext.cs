using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models.Entities
{
    public class BookContext:DbContext
    {
        public DbSet<Book> Book { get; set; }


        public BookContext(DbContextOptions<BookContext> options ):base(options)
        {
            Database.EnsureCreated();
        }

    }
}
