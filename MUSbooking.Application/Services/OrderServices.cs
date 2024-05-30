using AutoMapper;
using Fontech.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using MUSbooking.Domain.DTO.Equipment;
using MUSbooking.Domain.DTO.EquipmentOrder;
using MUSbooking.Domain.DTO.Order;
using MUSbooking.Domain.Entity;
using MUSbooking.Domain.Intarfaces.Services;
using QuizAplicationRtk.Domain.Interfaces.Result;
using System.Linq;

namespace MUSbooking.Application.Services
{
    public class OrderServices : IOrderService
    {
        private readonly IBaseRepository<Equipment> _equipmentRepository;
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IBaseRepository<EquipmentOrder> _equipmentOrder;
        private readonly IMapper _mapper;

        public OrderServices(IBaseRepository<Order> orderRepository, IMapper mapper, IBaseRepository<Equipment> equipmentRepository, IBaseRepository<EquipmentOrder> equipmentOrder)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _equipmentRepository = equipmentRepository;
            _equipmentOrder = equipmentOrder;
        }

        public async Task<BaseResult<OrderDto>> CreateOrderAsync(CreateOrderDto dto)
        {
            try
            {
                var order = new Order
                {
                    Description = dto.Description,
                    Equipments = new List<Equipment>()
                };
                
                foreach (var equipmentDto in dto.Equipments)
                {
                    var equipment = await _equipmentRepository.GetAll()
                        .FirstOrDefaultAsync(x => x.Name == equipmentDto.Name);

                    if (equipment == null)
                    {
                        equipment = new Equipment
                        {
                            Name = equipmentDto.Name,
                            Amount = equipmentDto.Amount,
                            Price = equipmentDto.Price
                        };
                        await _equipmentRepository.CreateAsync(equipment);
                        await _equipmentRepository.SaveChangesAsync();
                    }

                    if (equipment.Amount < 0)
                    {
                        throw new InvalidOperationException($"оборудование не может быть меньше нуля.");
                    }

                    var equipmentOrder = new EquipmentOrder
                    {
                        EquipmentId = equipment.Id,
                        OrderId = order.Id,
                    };

                    order.Equipments.Add(equipment);
                    equipment.Amount -= equipmentDto.Amount;
                    _equipmentRepository.Update(equipment);
                    
                }
                order.Price = dto.Equipments.Sum(e => e.Price * e.Amount);
                await _orderRepository.CreateAsync(order);
                await _orderRepository.SaveChangesAsync();

                var orderDto = _mapper.Map<OrderDto>(order);
                return new BaseResult<OrderDto> { Data = orderDto };
            }
            catch (Exception ex)
            {
                return new BaseResult<OrderDto> { ErrorMessage = $": {ex.Message}" };
            }
        }
        public async Task<BaseResult<OrderDto>> DeleteOrderAsync(long id)
        {
            try
            {
                var order = await _orderRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                _orderRepository.Remove(order);
                await _orderRepository.SaveChangesAsync();
                return new BaseResult<OrderDto>()
                {
                    Data = _mapper.Map<OrderDto>(order)
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<OrderDto>
                {
                    ErrorMessage = $"ошибка удаления заказа: {ex.Message}"
                };
            }
        }

        public async Task<CollectionResult<OrderDto>> GetOrdersAsync(int pageNumber, int pageSize, string sortBy = "CreatedAt", bool isAscending = true)
        {
            try
            {
                if (pageNumber < 1)
                {
                    throw new ArgumentException("номер страницы не может быть меньше 1.", nameof(pageNumber));
                }

                if (pageSize < 1)
                {
                    throw new ArgumentException("размер страницы не может быть меньше 1.", nameof(pageSize));
                }

                var totalItemCount = await _orderRepository.GetAll().CountAsync();


                IQueryable<Order> ordersQuery = _orderRepository.GetAll().Include(o => o.Equipments);


                ordersQuery = sortBy switch
                {
                    "Description" => isAscending ? ordersQuery.OrderBy(o => o.Description) : ordersQuery.OrderByDescending(o => o.Description),
                    "Price" => isAscending ? ordersQuery.OrderBy(o => o.Price) : ordersQuery.OrderByDescending(o => o.Price),
                    "CreatedAt" => isAscending ? ordersQuery.OrderBy(o => o.CreatedAt) : ordersQuery.OrderByDescending(o => o.CreatedAt),
                    _ => throw new ArgumentException($"Invalid sort field: {sortBy}", nameof(sortBy))
                };

                ordersQuery = ordersQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);

                var ordersList = await ordersQuery.ToListAsync();

                var orderDtos = ordersList.Select(order => _mapper.Map<OrderDto>(order)).ToList();

                return new CollectionResult<OrderDto>
                {
                    Items = orderDtos,
                    TotalCount = totalItemCount
                };
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Произошла ошибка при получении заказов.", ex);
            }
        }

        public async Task<BaseResult<OrderDto>> UpdateOrderAsync(UpdateOrderDto dto)
        {
            var order = await _orderRepository.GetAll()
                .Include(o => o.Equipments)
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (order == null)
            {
                throw new KeyNotFoundException("Order Not Found");
            }

            order.Description = dto.Description;

            order.Equipments.Clear();

            var newEquipmentOrders = new List<EquipmentOrder>();

            foreach (var equipmentDto in dto.Equipments)
            {
                var equipment = await _equipmentRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Name == equipmentDto.Name);

                if (equipment == null)
                {
                    equipment = new Equipment
                    {
                        Name = equipmentDto.Name,
                        Amount = equipmentDto.Amount,
                        Price = equipmentDto.Price
                    };
                    if (equipment.Amount < 0)
                    {
                        throw new InvalidOperationException($"оборудование не может быть меньше нуля.");
                    }

                    await _equipmentRepository.CreateAsync(equipment);
                    await _equipmentRepository.SaveChangesAsync();
                }

                if (equipment.Amount < 0)
                {
                    throw new InvalidOperationException($"оборудование не может быть меньше нуля.");
                }


                var equipmentOrder = new EquipmentOrder
                {
                    EquipmentId = equipment.Id,
                    OrderId = order.Id,
                };

                order.Equipments.Add(equipment);
                equipment.Amount -= equipmentDto.Amount;
                _equipmentRepository.Update(equipment);

            }

            order.Price = dto.Equipments.Sum(e => e.Price * e.Amount);
            _orderRepository.Update(order);
            await _orderRepository.SaveChangesAsync();

            return new BaseResult<OrderDto>
            {
                Data = _mapper.Map<OrderDto>(order)
            };
        }
    }
}
