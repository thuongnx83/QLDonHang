using Org.BouncyCastle.Utilities;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;

namespace QLDonHangAPI.Services
{
    public interface IAccountsService
    {
        Task<List<Accounts>> getAllAsync();

        Task<Accounts> Insert(Accounts obj);
        Task<Accounts> Update(Accounts obj);
        Task<Accounts> getByIdAsync(int id);
        Task<bool> deleteByIdAsync(int id);
    }
}
