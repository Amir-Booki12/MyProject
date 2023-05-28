using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                typeof(UserMapper),
                //typeof(ProductMapper),
            };
        }
    }
}
