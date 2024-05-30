using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MUSbooking.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fontech.DAL.Interceptors;
using Fontech.Domain.Interfaces.Repositories;
using MUSbooking.Domain.Entity;
using Fontech.DAL.Repositories;

namespace QuizAplicationRtk.DAL.DipendencyInjection;

public static class DipendencyInjection
{
    public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration )
    {
        SQLitePCL.Batteries.Init();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddSingleton<DateInterceptors>();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        services.InitRepositories();
    }

    private static void InitRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();
        services.AddScoped<IBaseRepository<Equipment>, BaseRepository<Equipment>>();
        services.AddScoped<IBaseRepository<EquipmentOrder>, BaseRepository<EquipmentOrder>>();
    }
}
