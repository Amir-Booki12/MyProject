using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums.RolesManagment
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ClaimLocationAttribute : Attribute
    {
        private string _claimLocation { get; }
        public ClaimLocationAttribute(string claimLocation) => _claimLocation = claimLocation;
        public virtual string ClaimLocation => _claimLocation;
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ClaimLevelAttribute : Attribute
    {
        private string _claimLevel { get; }
        public ClaimLevelAttribute(string claimLevel) => _claimLevel = claimLevel;
        public virtual string ClaimLevel => _claimLevel;
    }
}
