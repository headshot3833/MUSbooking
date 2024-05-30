using MUSbooking.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Domain.DTO.Order
{
    public record UpdateOrderDto(long Id,string Description, List<EquipmentDto> Equipments, decimal Price);
}
