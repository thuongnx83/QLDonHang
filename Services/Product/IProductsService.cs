using Org.BouncyCastle.Utilities;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;

namespace QLDonHangAPI.Services
{
    public interface IProductsService
    {
        Task<List<Products>> getAllAsync();

        Task<Products> Insert(Products obj);
        Task<Products> Update(Products obj);
        Task<Products> getByIdAsync(int id);
        Task<bool> deleteByIdAsync(int id);
    }
}
