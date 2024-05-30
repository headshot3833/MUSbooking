using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MUSbooking.Application.Services;
using MUSbooking.Application.Validations.FluentEquipment;
using MUSbooking.Domain.DTO.Equipment;
using MUSbooking.Domain.DTO.Order;
using MUSbooking.Domain.Entity;
using MUSbooking.Domain.Intarfaces.Services;
using QuizAplicationRtk.Domain.Interfaces.Result;

namespace MUSbooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        IEquipmentService _Equipment;

        public EquipmentController(IEquipmentService equipment)
        {
            _Equipment = equipment;
        }
        /// <summary>
        /// Создание Оборудование 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<EquipmentDto>>> Create([FromBody] CreateEquipmentDto dto)
        {
            var response = await _Equipment.CreateEquipment(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
