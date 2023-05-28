using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BaseAgg
{
    public class EntityBaseKey<TPrimaryKey>
    {
        [Key]
        [Column, NotNull]
        public virtual TPrimaryKey Id { get; set; }
    }

    public class EntityBaseKeyInteger : EntityBaseKey<int>
    {
    }

    public class EntityBaseKeyLong : EntityBaseKey<long>
    {
    }

    public class EntityBaseKeyGuid : EntityBaseKey<Guid>
    {
    }
}
