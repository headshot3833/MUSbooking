using MUSbooking.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Domain.DTO.EquipmentOrder
{
    public record EquipmentOrderDto(long OrderId, long EquipmentId);
}
