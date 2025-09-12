using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveHeroCooperation.Models
{
    internal class Saving
    {
        public int Id { get; set; }
        public Member member { get; set; }
        public LoanMaster loanMaster { get; set; }
        public DateTime savingDate {  get; set; }
        public decimal amount { get; set; }
        public decimal fine { get; set; }
        public decimal withdrawAmount { get; set; }
        public DateTime withdrawDate { get; set; }
    }
}
