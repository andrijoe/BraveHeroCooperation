using BraveHeroCooperation.Data;
using BraveHeroCooperation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveHeroCooperation.Services
{
    public class BalanceService
    {
        private readonly AppDbContext _db;
        public BalanceService(AppDbContext db) => _db = db;

        public async void setBalance(String memberCode)
        {
            Balance? balance = await _db.Balances.FirstOrDefaultAsync(b => b.MemberCode == memberCode);
            if (balance == null)
            {
                balance = new Balance
                {
                    MemberCode = memberCode,
                    Amount = 0,
                    UpdateOn = DateTime.Now
                };
                _db.Balances.Add(balance);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Balance?> getBalance(String memberCode)
        {
            return await _db.Balances.FirstOrDefaultAsync(b => b.MemberCode == memberCode);
        }

        public async void Update(Balance balance)
        {
            _db.Balances.Update(balance);
            await _db.SaveChangesAsync();
        }
    }
}
