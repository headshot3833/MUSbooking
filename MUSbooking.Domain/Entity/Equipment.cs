using Fontech.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Domain.Entity;

public class Equipment : IEntityId<long>
{
    public long Id { get; set; }

    public string Name { get; set; }

    public int Amount { get; set; }
    public List<Order> Orders { get; set; }
    public decimal Price {  get; set; }

}
