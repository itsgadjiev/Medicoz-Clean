using Medicoz.Domain;
using Medicoz.Domain.Common.abstracts;
using Medicoz.Domain.Common.concrets;
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
    public DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var jsonConverter = new ValueConverter<Dictionary<string, string>, string>(
           v => JsonSerializer.Serialize(v, new JsonSerializerOptions { IgnoreNullValues = true }),
           v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, new JsonSerializerOptions { IgnoreNullValues = true }),
           new ConverterMappingHints(size: -1)
       );

        #region OurService
        modelBuilder.Entity<OurService>()
           .Property(e => e.Title)
           .HasConversion(jsonConverter)
           .HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<OurService>()
            .Property(e => e.Description)
            .HasConversion(jsonConverter)
            .HasColumnType("nvarchar(MAX)");
        #endregion

        #region Doctor
        modelBuilder.Entity<Doctor>()
        .ToTable("Doctors")
        .HasMany(d => d.DoctorSchedules)
        .WithOne(ds => ds.Doctor)
        .HasForeignKey(ds => ds.DoctorId);

        modelBuilder.Entity<Doctor>()
            .Property(d => d.Title)
            .HasConversion(jsonConverter)
            .HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Doctor>()
            .Property(d => d.Education)
            .HasConversion(jsonConverter)
            .HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Doctor>()
           .Property(d => d.Description)
           .HasConversion(jsonConverter)
           .HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Doctor>()
         .Property(d => d.Experience)
         .HasConversion(jsonConverter)
         .HasColumnType("nvarchar(MAX)");

        #endregion

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }



    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
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
