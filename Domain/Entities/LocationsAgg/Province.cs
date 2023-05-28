using Common.Enums;
using Domain.Attributes;
using Domain.Entities.BaseAgg;
using System.Collections.Generic;

namespace Domain.Entities.LocationsAgg
{
    [AuditableAttribute]
    [EntityTypeAttribute]
    public class Province : EntityBaseKey<int>
    {
        public string Title { get; set; }

        public virtual MainLocation MainLocation { get; set; }
        public int MainLocationId { get; set; }
        public StatusEnum Status { get; set; }

        public virtual ICollection<County> Counties { get; set; }
    }
}
