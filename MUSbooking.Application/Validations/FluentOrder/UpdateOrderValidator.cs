using FluentValidation;
using MUSbooking.Domain.DTO.Order;
using MUSbooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Application.Validations.FluentOrder
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
            RuleForEach(x => x.Equipments).ChildRules(equipment =>
            {
                equipment.RuleFor(x => x.Name).NotEmpty();
            });
        }
    }
}
