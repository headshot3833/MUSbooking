using AutoMapper;
using MUSbooking.Domain.DTO.Equipment;
using MUSbooking.Domain.DTO.EquipmentOrder;
using MUSbooking.Domain.DTO.Order;
using MUSbooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Application.Mapping
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
