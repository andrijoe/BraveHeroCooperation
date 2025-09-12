using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveHeroCooperation.Models
{
    internal class Exchange
    {
        public int Id { get; set; }
        public Member member { get; set; }
        public decimal amount { get; set; }
        public decimal amountExchange {  get; set; }
        public decimal fee { get; set; }
        public decimal rate { get; set; }
        public DateTime exchangeDate { get; set; }
    }
}
