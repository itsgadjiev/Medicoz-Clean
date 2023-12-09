using Medicoz.Application.Contracts.Identity;
using Medicoz.Domain;
using Medicoz.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace Medicoz.Persistence.IntegrationTests
{
    public class AppDbContextTests
    {
        private readonly AppDbContext _medicozDbContext;

        public AppDbContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _medicozDbContext = new AppDbContext(dbOptions,null);
        }

        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            var ourService = new OurService
            {
                Id = "49aa37c5-47e1-4578-89b2-295aabcdb7f5",
                Title = new Dictionary<string, string> { { "az", "Salam" }, { "en", "Hello" } },
                Description = new Dictionary<string, string> { { "az", "Salam" }, { "en", "Hello" } },
                Icon = Guid.NewGuid().ToString(),
            };

            await _medicozDbContext.AddAsync(ourService);
            await _medicozDbContext.SaveChangesAsync();

            ourService.CreatedAt.ShouldNotBe(DateTime.MinValue);

        }

        [Fact]
        public async Task Save_SetDateModifiedValueAsync()
        {
            var ourService = new OurService
            {
                Id = "49aa37c5-47e1-4578-89b2-29aaabcdb735",
                Title = new Dictionary<string, string> { { "az", "Salam" }, { "en", "Hello" } },
                Description = new Dictionary<string, string> { { "az", "Salam" }, { "en", "Hello" } },
                Icon = Guid.NewGuid().ToString(),
            };

            await _medicozDbContext.AddAsync(ourService);
            await _medicozDbContext.SaveChangesAsync();

            ourService.UpdatedAt.ShouldNotBe(DateTime.MinValue);

        }
    }
}