using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityTypeAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class IdentityEntityTypeAttribute : Attribute
    {
    }
}
