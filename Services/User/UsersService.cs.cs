using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLDonHangAPI.Data;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;
using System.Threading.Tasks;

namespace QLDonHangAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly QLDonHangDbContext _QLDonHangDbContext;
        private readonly IMapper _mapper;
        public UsersService(QLDonHangDbContext QLDonHangDbContext, IMapper mapper)
        {
            this._QLDonHangDbContext = QLDonHangDbContext;
            this._mapper = mapper;
        }

        public async Task<Users> Insert(Users obj)
        {
            try
            {
                Users oT = _mapper.Map<Users>(obj);
                oT.DateCreate = DateTime.Now;
                _QLDonHangDbContext.Users.Add(oT);
                await _QLDonHangDbContext.SaveChangesAsync();
                return oT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Users> Update(Users obj)
        {
            var oT = await _QLDonHangDbContext.Users.Where(_ => _.Id == obj.Id).FirstOrDefaultAsync();
            if (oT == null)
            {
                return new Users();
            }
            else
            {
                oT.FullName = obj.FullName;
                oT.Email = obj.Email;
                oT.Active = obj.Active;
                oT.DateModify = DateTime.Now;
                _QLDonHangDbContext.Users.Update(oT);
                await _QLDonHangDbContext.SaveChangesAsync();
                return oT;
            }
        }
        public async Task<Users> getByIdAsync(int id)
        {
            try
            {
                var obj = await _QLDonHangDbContext.Users.Where(_ => _.Id == id).FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception ex)
            {
                return new Users();
            }
        }

        public async Task<List<Users>> getAllAsync()
        {
            try
            {
                var lst = await _QLDonHangDbContext.Users.FromSql($"SELECT p.* FROM Users p").ToListAsync();
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
                var obj = await _QLDonHangDbContext.Users.Where(_ => _.Id == id).FirstOrDefaultAsync();
                _QLDonHangDbContext.Users.Remove(obj);
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
