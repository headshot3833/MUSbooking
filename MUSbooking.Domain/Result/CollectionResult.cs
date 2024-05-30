using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAplicationRtk.Domain.Interfaces.Result;

public class CollectionResult<T> : BaseResult<IEnumerable<T>>
{
    public List<T> Items { get; set; }
    public int TotalCount {  get; set; }
}
