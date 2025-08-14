using Org.BouncyCastle.Utilities;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;

namespace QLDonHangAPI.Services
{
    public interface IUsersService
    {
        Task<List<Users>> getAllAsync();

        Task<Users> Insert(Users obj);
        Task<Users> Update(Users obj);
        Task<Users> getByIdAsync(int id);
        Task<bool> deleteByIdAsync(int id);
        Task<bool> checkbyUserName(string username);
        Task<UserInfo> getLogin(string _username, string _password);
    }
}
