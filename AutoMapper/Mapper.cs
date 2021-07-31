using AutoMapper.MapperAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoMapper
{
    public class Mapper : IMapper
    {
        public TDestination Map<TDestination>(object TSource)
        {
            TDestination instance = Activator.CreateInstance<TDestination>();
            foreach (var attr in instance.GetType().GetProperties())
            {
                attr.SetValue(instance,
                    TSource
                    .GetType()
                    .GetProperties()
                    .Where(a => a.Name == GetAttrName(attr.GetCustomAttributes())).Select(a => a.GetValue(TSource)).SingleOrDefault());
            }
            return instance;
        }
        public IEnumerable<TDestination> Map<TDestination>(IEnumerable<object> TSource)
        {
            var lista = new List<TDestination>();
            foreach (var obj in TSource)
            {
                TDestination instance = Activator.CreateInstance<TDestination>();
                foreach (var attr in instance.GetType().GetProperties())
                {
                    var value = obj
                        .GetType()
                        .GetProperties()
                        .Where(a => a.Name == GetAttrName(attr.GetCustomAttributes())).Select(a => a.GetValue(obj)).SingleOrDefault();

                    attr.SetValue(instance, value);
                }

                lista.Add(instance);
            }

            return lista;
        }

        private string GetAttrName(IEnumerable<Attribute> attrList)
        {
            foreach (var attr in attrList)
            {   
                if (attr is SourceMemberAttribute)
                {
                    SourceMemberAttribute a = (SourceMemberAttribute) attr;
                    return a.SourceName;
                }
            }

            return string.Empty;
        }
    }
}
