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

        public DbSet<Note> Notes { get; set; } = default!;
    }
}
