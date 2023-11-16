using Medicoz.Domain;
using Medicoz.Domain.Common.abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;


namespace Medicoz.Persistence.Database;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<OurService> OurServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var jsonConverter = new ValueConverter<Dictionary<string, string>, string>(
           v => JsonSerializer.Serialize(v, new JsonSerializerOptions { IgnoreNullValues = true }),
           v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, new JsonSerializerOptions { IgnoreNullValues = true }),
           new ConverterMappingHints(size: -1) 
       );

        modelBuilder.Entity<OurService>()
            .Property(e => e.Title)
            .HasConversion(jsonConverter)
            .HasColumnType("nvarchar(MAX)"); 

        modelBuilder.Entity<OurService>()
            .Property(e => e.Description)
            .HasConversion(jsonConverter)
            .HasColumnType("nvarchar(MAX)"); 

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);



    }



    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<IAuditable>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.UpdatedAt = DateTime.Now;
            //entry.Entity.UpdatedBy = _userService.UserId;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now;
                //entry.Entity.UpdatedBy = _userService.UserId;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}
