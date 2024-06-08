using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MUSbooking.Domain.DTO.Order;
using MUSbooking.Domain.Intarfaces.Services;
using QuizAplicationRtk.Domain.Interfaces.Result;

namespace MUSbooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _order;

        public OrderController(IOrderService order)
        {
            _order = order;
        }
        /// <summary>
        /// Создание заказа
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<OrderDto>>> Create([FromBody] CreateOrderDto dto)
        {   
            var response = await _order.CreateOrderAsync(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);    
         }
        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(template:"{Id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<OrderDto>>> Delete(long Id)
        {
            var response = await _order.DeleteOrderAsync(Id);
            if (response.IsSuccess)
            {   
                return Ok(response);
            }
            return BadRequest(response);
        }
        /// <summary>
        /// получение списка заказов по дате
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<OrderDto>>> GetOrder(int pageNumber, int pageSize)
        {
            var response = await _order.GetOrdersAsync(pageNumber, pageSize);
            if (response.IsSuccess)
            {
                return Ok(response.Items);
            }
            return BadRequest(response);
        }
        /// <summary>
        /// Обновление заказа
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<OrderDto>>> Update([FromBody] UpdateOrderDto dto)
        {
            var response = await _order.UpdateOrderAsync(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
