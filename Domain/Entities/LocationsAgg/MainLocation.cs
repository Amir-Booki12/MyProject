using Common.Enum;
using Common.Enums;
using Domain.Attributes;
using Domain.Entities.BaseAgg;
using System.Collections.Generic;

namespace Domain.Entities.LocationsAgg
{
    [AuditableAttribute]
    [EntityTypeAttribute]
    public class MainLocation : EntityBaseKey<int>
    {
        public string Title { get; set; }
        public StatusEnum Status { get; set; }

        public virtual ICollection<Province> Provinces { get; set; }
    }
}
