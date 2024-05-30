using MUSbooking.Application.Services;
using MUSbooking.Domain.DTO.Equipment;
using MUSbooking.Domain.DTO.EquipmentOrder;
using MUSbooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Domain.DTO.Order
{
    public class OrderDto
    {
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public decimal Price { get; set; }
        public List<EquipmentOrderDto> EquipmentOrders { get; set; }
    }
}