using Microsoft.Extensions.DependencyInjection;
using MUSbooking.Application.Mapping;
using MUSbooking.Application.Services;
using MUSbooking.Domain.Intarfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonTech.Application.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(EquipmentMapper));
        services.AddAutoMapper(typeof(OrderMapper));
        InitServices(services);
    }
    private static void InitServices(this IServiceCollection services)
    {
        services.AddScoped<IEquipmentService, EquipmentService>();
        services.AddScoped<IOrderService, OrderServices>();
    }
}
