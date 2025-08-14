using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLDonHangAPI.Data;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;
using System.Threading.Tasks;

namespace QLDonHangAPI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly QLDonHangDbContext _QLDonHangDbContext;
        private readonly IMapper _mapper;
        public ProductsService(QLDonHangDbContext QLDonHangDbContext, IMapper mapper)
        {
            this._QLDonHangDbContext = QLDonHangDbContext;
            this._mapper = mapper;
        }

        public async Task<Products> Insert(Products obj)
        {
            try
            {
                Products oT = _mapper.Map<Products>(obj);
                oT.DateCreate = DateTime.Now;
                _QLDonHangDbContext.Products.Add(oT);
                await _QLDonHangDbContext.SaveChangesAsync();
                return oT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Products> Update(Products obj)
        {
            var oT = await _QLDonHangDbContext.Products.Where(_ => _.Id == obj.Id).FirstOrDefaultAsync();
            if (oT == null)
            {
                return new Products();
            }
            else
            { 
                oT.Name = obj.Name;
                oT.Price = obj.Price;
                oT.Stock = obj.Stock;
                oT.DateModify = DateTime.Now;
                _QLDonHangDbContext.Products.Update(oT); 
                await _QLDonHangDbContext.SaveChangesAsync();
                return oT;
            }
        }
        public async Task<Products> getByIdAsync(int id)
        {
            try
            {
                var obj = await _QLDonHangDbContext.Products.Where(_ => _.Id == id).FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception ex)
            {
                return new Products();
            }
        }

        public async Task<List<Products>> getAllAsync()
        {
            try
            {
                var lst = await _QLDonHangDbContext.Products.FromSql($"SELECT p.* FROM Products p").ToListAsync();
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
                var obj = await _QLDonHangDbContext.Products.Where(_ => _.Id == id).FirstOrDefaultAsync();
                _QLDonHangDbContext.Products.Remove(obj);
                await _QLDonHangDbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
