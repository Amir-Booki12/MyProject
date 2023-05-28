using Domain.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// نقش
    /// </summary>
    [EntityTypeAttribute]
    [AuditableAttribute]
    public class ApplicationRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
