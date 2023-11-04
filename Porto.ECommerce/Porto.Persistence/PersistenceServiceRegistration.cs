﻿using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Localizer;
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
        services.AddDbContext<AppDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped( typeof(DatabaseLocalisationRepository<>));


        return services;
    }
}
