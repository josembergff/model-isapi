using ModelISAPI.Models;

namespace ModelISAPI.Data
{
    public class ModelISAPIContextSeed
    {
        public static void SeedDatabase(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ModelISAPIContext>();
                SeedAsync(context);
            }
        }

        public static async void SeedAsync(ModelISAPIContext modelISAPIContext)
        {
            if (!modelISAPIContext.Notes.Any())
            {
                var listNote = new List<Note>
                {
                    new Note
                    {
                        Id = 1,
                        CreatedDate = DateTime.Now,
                        Description = "Note one description",
                        Title = "Title one"
                    },
                    new Note
                    {
                        Id = 2,
                        CreatedDate = DateTime.Now.AddDays(-2),
                        Description = "Note two description",
                        Title = "Title two"
                    },
                    new Note
                    {
                        Id = 3,
                        CreatedDate = DateTime.Now.AddDays(-5),
                        Description = "Note three description",
                        Title = "Title three"
                    }
                };

                await modelISAPIContext.AddRangeAsync(listNote);
                await modelISAPIContext.SaveChangesAsync();
            }
        }
    }
}
