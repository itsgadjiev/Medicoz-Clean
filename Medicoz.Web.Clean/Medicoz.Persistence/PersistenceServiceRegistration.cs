using Medicoz.Application.Contracts.Percistance;
using Medicoz.Persistence.Database;
using Medicoz.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medicoz.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IDatabaseLocalisationRepository<>), typeof(DatabaseLocalisationRepository<>));
        services.AddScoped<ISliderRepository, SliderRepository>();
        services.AddScoped<IOurServicesRepository, OurServicesRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();
        services.AddScoped<IDoctorAppointmentRepository, DoctorAppointmentRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IDoctorDepartmentRepository, DoctorDepartmentRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IBasketItemRepository, BasketItemRepository>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
