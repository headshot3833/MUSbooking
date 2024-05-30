using MUSbooking.Application.Services;
using MUSbooking.Domain.DTO.Equipment;
using MUSbooking.Domain.Entity;
using QuizAplicationRtk.Domain.Interfaces.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Domain.Intarfaces.Services
{
    public interface IEquipmentService
    {
        /// <summary>
        /// Создание оборудования 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BaseResult<EquipmentDto>> CreateEquipment(CreateEquipmentDto dto);

    }
}
