using System;

namespace AutoMapper.MapperAttributes
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
