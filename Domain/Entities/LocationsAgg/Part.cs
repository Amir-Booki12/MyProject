using Domain.Attributes;
using Domain.Entities.BaseAgg;
using System.Collections.Generic;

namespace Domain.Entities.LocationsAgg
{
    [AuditableAttribute]
    [EntityTypeAttribute]
    public class Part : EntityBaseKey<int>
    {
        public string Title { get; set; }

        public virtual County County { get; set; }
        public int CountyId { get; set; }

        public virtual ICollection<CityOrVilage> CityOrVilages { get; set; }
    }
}
