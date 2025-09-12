using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveHeroCooperation.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public string MemberId { get; set; }
        public string IdCard { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneAlt {  get; set; }
        public DateTime ModDate{get; set;}
        public string Status { get; set; }
        public string Deleted { get; set; }
        public string ReferenceId { get; set; }
        public string Approved { get; set; }
        public string level { get; set; }
    }
}
