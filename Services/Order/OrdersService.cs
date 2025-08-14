using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLDonHangAPI.Data;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;
using System.Threading.Tasks;

namespace QLDonHangAPI.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly QLDonHangDbContext _QLDonHangDbContext;
        private readonly IMapper _mapper;
        public OrdersService(QLDonHangDbContext QLDonHangDbContext, IMapper mapper)
        {
            this._QLDonHangDbContext = QLDonHangDbContext;
            this._mapper = mapper;
        }

        public async Task<Orders> Insert(Orders obj)
        {
            try
            {
                Orders oT = _mapper.Map<Orders>(obj);
                oT.DateCreate = DateTime.Now;
                _QLDonHangDbContext.Orders.Add(oT);
                await _QLDonHangDbContext.SaveChangesAsync();
                return oT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Orders> Update(Orders obj)
        {
            var oT = await _QLDonHangDbContext.Orders.Where(_ => _.Id == obj.Id).FirstOrDefaultAsync();
            if (oT == null)
            {
                return new Orders();
            }
            else
            {
                //oT.Name = obj.Name;
                //oT.Price = obj.Price;
                //oT.Stock = obj.Stock;
                oT.DateModify = DateTime.Now;
                _QLDonHangDbContext.Orders.Update(oT);
                await _QLDonHangDbContext.SaveChangesAsync();
                return oT;
            }
        }
        public async Task<Orders> getByIdAsync(int id)
        {
            try
            {
                var obj = await _QLDonHangDbContext.Orders.Where(_ => _.Id == id).FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception ex)
            {
                return new Orders();
            }
        }

        public async Task<List<Orders>> getAllAsync()
        {
            try
            {
                var lst = await _QLDonHangDbContext.Orders.FromSql($"SELECT p.* FROM Orders p").ToListAsync();
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
                var obj = await _QLDonHangDbContext.Orders.Where(_ => _.Id == id).FirstOrDefaultAsync();
                _QLDonHangDbContext.Orders.Remove(obj);
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
