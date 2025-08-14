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
        Task<bool> checkbyUserName(string username);
        Task<AccountInfo> getLogin(string _username, string _password);
        Task<bool> deleteByIdAsync(int id);
    }
}
