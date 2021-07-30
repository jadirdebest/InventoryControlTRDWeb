using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.CrossCutting.AutoMapper
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object TSource);
        IEnumerable<TDestination> Map<TDestination>(IEnumerable<object> TSource);
    }
}
