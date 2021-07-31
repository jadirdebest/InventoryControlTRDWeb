using System.Collections.Generic;

namespace AutoMapper
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object TSource);
        IEnumerable<TDestination> Map<TDestination>(IEnumerable<object> TSource);
    }
}
