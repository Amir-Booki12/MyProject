using Common.Enums;
using Domain.Attributes;
using Domain.Entities.BaseAgg;
using System.Collections.Generic;

namespace Domain.Entities.LocationsAgg
{
    [AuditableAttribute]
    [EntityTypeAttribute]
    public class County : EntityBaseKey<int>
    {
        public string Title { get; set; }
        public virtual Province Province { get; set; }
        public int ProvinceId { get; set; }
        public StatusEnum Status { get; set; }
        public virtual ICollection<Part> Parts { get; set; }

    }
}
