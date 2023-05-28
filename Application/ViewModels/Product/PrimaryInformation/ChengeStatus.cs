using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Product.PrimaryInformation
{
    public class ChengeStatus
    {
        public long ProductId { get; set; }
        public StatusEnum StatusEnum { get; set; }
    }
}
