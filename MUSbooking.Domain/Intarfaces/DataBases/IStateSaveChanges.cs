using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSbooking.Domain.Intarfaces.DataBases;

public interface IStateSaveChanges
{
    Task<int> SaveChangesAsync();
}
