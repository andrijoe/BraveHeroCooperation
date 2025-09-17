using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BraveHeroCooperation.Data;
using BraveHeroCooperation.Models;

namespace BraveHeroCooperation.Services
{
    public class MemberService
    {
        private readonly AppDbContext _db;
        public MemberService(AppDbContext db) => _db = db;
        public List<object> setDropdown()
        {
            var list = _db.Members.OrderBy(m => m.FullName)
                .Select(m => new
                {
                    m.Id,
                    DisplayName = m.MemberId + " - " + m.FullName
                })
                .ToList<object>();
            return list;
        }

        public Member? findById(int id)
        {
            return _db.Members.FirstOrDefault(x => x.Id == id);
        }

        public object setGrid()
        {
            return 
                _db.Members.OrderByDescending(m=> m.ModDate).ToList();
        }

        public async void update(Member member)
        {
            _db.Members.Update(member);
            await _db.SaveChangesAsync();
        }
    }
}
