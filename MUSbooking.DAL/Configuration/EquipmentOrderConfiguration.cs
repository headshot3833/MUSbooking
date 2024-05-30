using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MUSbooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.DAL.Configuration
{
    public class EquipmentOrderConfiguration : IEntityTypeConfiguration<EquipmentOrder>
    {
        public void Configure(EntityTypeBuilder<EquipmentOrder> builder)
        {
        }
    }
}
