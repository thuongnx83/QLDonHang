using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLDonHangAPI.Data;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;
using System.Threading.Tasks;

namespace QLDonHangAPI.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly QLDonHangDbContext _QLDonHangDbContext;
        private readonly IMapper _mapper;
        public AccountsService(QLDonHangDbContext QLDonHangDbContext, IMapper mapper)
        {
            this._QLDonHangDbContext = QLDonHangDbContext;
            this._mapper = mapper;
        }

        public async Task<Accounts> Insert(Accounts obj)
        {
            try
            {
                Accounts oT = _mapper.Map<Accounts>(obj);
                oT.DateCreate = DateTime.Now;
                _QLDonHangDbContext.Accounts.Add(oT);
                await _QLDonHangDbContext.SaveChangesAsync();
                return oT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Accounts> Update(Accounts obj)
        {
            var oT = await _QLDonHangDbContext.Accounts.Where(_ => _.Id == obj.Id).FirstOrDefaultAsync();
            if (oT == null)
            {
                return new Accounts();
            }
            else
            {
                oT.FullName = obj.FullName;
                oT.Email = obj.Email;
                oT.Active = obj.Active;
                oT.DateModify = DateTime.Now;
                _QLDonHangDbContext.Accounts.Update(oT);
                await _QLDonHangDbContext.SaveChangesAsync();
                return oT;
            }
        }
        public async Task<Accounts> getByIdAsync(int id)
        {
            try
            {
                var obj = await _QLDonHangDbContext.Accounts.Where(_ => _.Id == id).FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception ex)
            {
                return new Accounts();
            }
        }

        public async Task<List<Accounts>> getAllAsync()
        {
            try
            {
                var lst = await _QLDonHangDbContext.Accounts.FromSql($"SELECT p.* FROM Accounts p").ToListAsync();
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> deleteByIdAsync(int id)
        {
            try
            {
                var obj = await _QLDonHangDbContext.Accounts.Where(_ => _.Id == id).FirstOrDefaultAsync();
                _QLDonHangDbContext.Accounts.Remove(obj);
                await _QLDonHangDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
