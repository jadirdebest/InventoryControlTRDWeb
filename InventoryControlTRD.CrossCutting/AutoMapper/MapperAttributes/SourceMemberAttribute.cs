using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.CrossCutting.AutoMapper.MapperAttributes
{
    public class SourceMemberAttribute : Attribute
    {
        public string SourceName { get; private set; }
        public SourceMemberAttribute(string sourceName)
        {
            SourceName = sourceName;
        }
    }
}
