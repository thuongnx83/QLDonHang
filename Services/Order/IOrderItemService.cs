using Org.BouncyCastle.Utilities;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;

namespace QLDonHangAPI.Services
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> getAllAsync();

        Task<OrderItem> Insert(OrderItem obj);
        Task<OrderItem> Update(OrderItem obj);
        Task<OrderItem> getByIdAsync(int id);
        Task<bool> deleteByIdAsync(int id);
    }
}
