using Org.BouncyCastle.Utilities;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;

namespace QLDonHangAPI.Services
{
    public interface IOrdersService
    {
        Task<List<Orders>> getAllAsync();

        Task<Orders> Insert(Orders obj);
        Task<Orders> Update(Orders obj);
        Task<Orders> getByIdAsync(int id);
        Task<bool> deleteByIdAsync(int id);
    }
}
