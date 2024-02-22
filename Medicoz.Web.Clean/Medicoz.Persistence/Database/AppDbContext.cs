using Medicoz.Application.Contracts.Identity;
using Medicoz.Domain;
using Medicoz.Domain.Common.concrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;


namespace Medicoz.Persistence.Database;

public class AppDbContext : DbContext
{
    private readonly IUserService _userService;

    public AppDbContext(DbContextOptions<AppDbContext> options, IUserService userService) : base(options)
    {
        _userService = userService;
    }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<OurService> OurServices { get; set; }
    public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
    public DbSet<DoctorAppointment> DoctorAppointment { get; set; }
    public DbSet<DoctorDepartment> DoctorDepartments { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductComment> ProductComment { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Blog> Blogs { get; set; }

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

        #region DoctorReservations

        modelBuilder.Entity<DoctorAppointment>()
            .HasOne(dr => dr.Doctor)
            .WithMany(dr=>dr.DoctorReservations)
            .HasForeignKey(dr => dr.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<DoctorAppointment>()
            .HasOne(dr => dr.DoctorSchedule)
            .WithMany(dr => dr.DoctorReservations)
            .HasForeignKey(dr => dr.DoctorScheduleId)
            .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region DoctorDepartments
        modelBuilder.Entity<Department>()
            .ToTable("Departments")
            .HasKey(d => d.Id);


        modelBuilder.Entity<Department>()
        .Property(d => d.Name)
        .HasConversion(jsonConverter)
        .HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Department>()
       .Property(d => d.Detail)
       .HasConversion(jsonConverter)
       .HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<DoctorDepartment>()
       .HasKey(dd => new { dd.DoctorId, dd.DepartmentId });

        modelBuilder.Entity<DoctorDepartment>()
            .HasOne(dd => dd.Doctor)
            .WithMany(d => d.DoctorDepartments)
            .HasForeignKey(dd => dd.DoctorId);

        modelBuilder.Entity<DoctorDepartment>()
            .HasOne(dd => dd.Department)
            .WithMany(d => d.DoctorDepartments)
            .HasForeignKey(dd => dd.DepartmentId);
        #endregion

        #region sliders

        modelBuilder.Entity<Slider>()
           .Property(e => e.Title)
           .HasConversion(jsonConverter)
           .HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Slider>()
           .Property(e => e.Description)
           .HasConversion(jsonConverter)
           .HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Slider>()
           .Property(e => e.Quote)
           .HasConversion(jsonConverter)
           .HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Slider>()
           .Property(e => e.ButtonName2)
           .HasConversion(jsonConverter)
           .HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Slider>()
           .Property(e => e.ButtonName)
           .HasConversion(jsonConverter)
           .HasColumnType("nvarchar(MAX)");
        #endregion

        #region Blogs
        modelBuilder.Entity<Blog>()
          .Property(e => e.Title)
          .HasConversion(jsonConverter)
          .HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Blog>()
          .Property(e => e.Detail)
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
            entry.Entity.UpdatedBy = _userService.UserId;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.Id = Guid.NewGuid().ToString();
                entry.Entity.CreatedAt = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
