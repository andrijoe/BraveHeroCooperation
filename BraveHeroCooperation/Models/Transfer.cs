using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveHeroCooperation.Models
{
    internal class Transfer
    {
        public int Id { get; set; }
        public Member origin { get; set; }
        public Member destination { get; set; }
        public decimal amount { get; set; }
        public decimal fee { get; set; }
        public string remarks {  get; set; }
        public DateTime transferDate { get; set; }
        public string transferId { get; set; }
        public string transferType { get; set; } = string.Empty;
    }
}
