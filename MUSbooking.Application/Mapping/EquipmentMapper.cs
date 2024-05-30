using AutoMapper;
using MUSbooking.Application.Services;
using MUSbooking.Domain.DTO.Equipment;
using MUSbooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Application.Mapping
{
    public class EquipmentMapper : Profile
    {
        public EquipmentMapper()
        {
            CreateMap<Equipment, EquipmentDto>().ReverseMap();
        }
    }
}
