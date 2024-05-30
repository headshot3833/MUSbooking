using Fontech.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Domain.Entity;

public class Order : IEntityId<long>, IAuditable
{
    public long Id { get; set; }

    public string Description {  get; set; }

    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt {  get; set; }
    public List<Equipment> Equipments {  get; set; }
}
