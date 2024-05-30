using AutoMapper;
using Fontech.Domain.Interfaces.Repositories;
using MUSbooking.Domain.DTO.Equipment;
using MUSbooking.Domain.Entity;
using MUSbooking.Domain.Intarfaces.Services;
using QuizAplicationRtk.Domain.Interfaces.Result;
using Microsoft.EntityFrameworkCore;

namespace MUSbooking.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IBaseRepository<Equipment> _equipmentRepository;
        private readonly IMapper _mapper;
        public EquipmentService(IBaseRepository<Equipment> equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }


        async Task<BaseResult<EquipmentDto>> IEquipmentService.CreateEquipment(CreateEquipmentDto dto)
        {
            var equipment = await _equipmentRepository.GetAll().FirstOrDefaultAsync(x => x.Name == dto.Name);

            equipment = new Equipment()
            {
                Name = dto.Name,
                Amount = dto.Amount,
                Price = dto.Price,
            };
            if(equipment.Amount < 0)
            {
                throw new InvalidOperationException($"оборудование не может быть меньше нуля.");
            }
            await _equipmentRepository.CreateAsync(equipment);
            await _equipmentRepository.SaveChangesAsync();

            return new BaseResult<EquipmentDto>
            {
                Data = _mapper.Map<EquipmentDto>(equipment),
            };
        }
    }
}
