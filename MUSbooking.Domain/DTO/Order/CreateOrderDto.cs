

using MUSbooking.Application.Services;
using MUSbooking.Domain.DTO.Equipment;
using MUSbooking.Domain.DTO.EquipmentOrder;
using MUSbooking.Domain.Entity;

namespace MUSbooking.Domain.DTO.Order
{
    public record CreateOrderDto(string Description, List<CreateEquipmentDto> Equipments);
}
