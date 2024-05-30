using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Domain.DTO.Equipment;

public record CreateEquipmentDto(string Name, int Amount, decimal Price);