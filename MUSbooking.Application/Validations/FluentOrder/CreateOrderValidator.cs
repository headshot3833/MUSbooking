using FluentValidation;
using MUSbooking.Domain.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Application.Validations.FluentOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
            RuleForEach(x => x.Equipments).ChildRules(equipment =>
            {
                equipment.RuleFor(x => x.Name).NotEmpty();
            });
        }
    }
}
