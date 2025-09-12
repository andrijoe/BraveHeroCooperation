using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveHeroCooperation.Models
{
    internal class MemberAccess
    {
        public int Id { get; set; }
        public Member member { get; set; }
        public string accessList {  get; set; }
    }
}
