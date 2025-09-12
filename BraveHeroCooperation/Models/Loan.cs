using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveHeroCooperation.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public Member member { get; set; }
        public int LoanId { get; set; }
        public decimal amount { get; set; }
        public decimal outstanding { get; set; }
        public decimal fine { get; set; }
        public int tenorLeft { get; set; }
    }
}
