using Common.Enums;
using Common.Enums.Location;
using Domain.Attributes;
using Domain.Entities.BaseAgg;
using System.Collections.Generic;

namespace Domain.Entities.LocationsAgg
{
    [AuditableAttribute]
    [EntityTypeAttribute]
    public class CityOrVilage : EntityBaseKey<int>
    {
        public string Title { get; set; }
        public int PartId { get; set; }
        public int RuralId { get; set; }
        public int? ServiceCenterId { get; set; }
        public int? AreaExpertId { get; set; }
        public CityOrVilageTypeEnum CityOrVilageType { get; set; }
        public StatusEnum Status { get; set; }

        #region Relations
        public virtual Part Part { get; set; }
        #endregion

    }
}
