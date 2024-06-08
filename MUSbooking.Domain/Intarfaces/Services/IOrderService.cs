using MUSbooking.Domain.DTO.Order;
using QuizAplicationRtk.Domain.Interfaces.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Domain.Intarfaces.Services;

public interface IOrderService
{
    /// <summary>
    /// Созание заказа
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<BaseResult<OrderDto>> CreateOrderAsync(CreateOrderDto dto);
    /// <summary>
    /// Удаление заказа
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<BaseResult<OrderDto>> DeleteOrderAsync(long Id);

    /// <summary>
    /// Получение всех Заказов
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<CollectionResult<OrderDto>> GetOrdersAsync(int pageNumber, int pageSize, string sortBy = "CreatedAt");
    /// <summary>
    /// обновление заказа
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<BaseResult<OrderDto>> UpdateOrderAsync(UpdateOrderDto dto);
}
