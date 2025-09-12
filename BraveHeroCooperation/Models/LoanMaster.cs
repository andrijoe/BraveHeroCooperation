using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveHeroCooperation.Models
{
    public class LoanMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal interest {  get; set; }
        public int tenor { get; set; }
        public decimal fine { get; set; }
        public decimal minAmount { get; set; } = 0;
        public decimal maxAmount { get; set; } = 0;
        public decimal adminFee { get; set; } = 0;
    }
}
