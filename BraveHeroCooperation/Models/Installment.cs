using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveHeroCooperation.Models
{
    internal class Installment
    {
        public string Id { get; set; }
        public Loan loan { get; set; }
        public decimal amount { get; set; } 
        public DateTime paidDate { get; set; }
        public string docId { get; set; }
    }
}
