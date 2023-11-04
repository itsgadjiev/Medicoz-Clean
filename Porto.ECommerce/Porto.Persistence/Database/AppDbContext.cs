using Medicoz.Domain;
using Medicoz.Domain.Common.abstracts;
using Microsoft.EntityFrameworkCore;

namespace Medicoz.Persistence.Database;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Slider> Sliders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
