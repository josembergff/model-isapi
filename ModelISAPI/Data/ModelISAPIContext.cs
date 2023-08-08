using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelISAPI.Models;

namespace ModelISAPI.Data
{
    public class ModelISAPIContext : DbContext
    {
        public ModelISAPIContext (DbContextOptions<ModelISAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Note { get; set; } = default!;
    }
}
