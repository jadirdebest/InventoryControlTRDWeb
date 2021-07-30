using System;


namespace InventoryControlTRD.CrossCutting.AutoMapper.MapperAttributes
{
    public class ObjectMapperAttribute : Attribute
    {
        public Type ObjectName { get; private set; }
        public ObjectMapperAttribute(Type objectName)
        {
            ObjectName = objectName;
        }
    }
}
