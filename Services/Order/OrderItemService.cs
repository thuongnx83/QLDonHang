using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLDonHangAPI.Data;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;
using System.Threading.Tasks;

namespace QLDonHangAPI.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly QLDonHangDbContext _QLDonHangDbContext;
        private readonly IMapper _mapper;
        public OrderItemService(QLDonHangDbContext QLDonHangDbContext, IMapper mapper)
        {
            this._QLDonHangDbContext = QLDonHangDbContext;
            this._mapper = mapper;
        }

        public async Task<OrderItem> Insert(OrderItem obj)
        {
            try
            {
                OrderItem oT = _mapper.Map<OrderItem>(obj);
                oT.DateCreate = DateTime.Now;
                _QLDonHangDbContext.OrderItem.Add(oT);
                await _QLDonHangDbContext.SaveChangesAsync();
                return oT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<OrderItem> Update(OrderItem obj)
        {
            var oT = await _QLDonHangDbContext.OrderItem.Where(_ => _.Id == obj.Id).FirstOrDefaultAsync();
            if (oT == null)
            {
                return new OrderItem();
            }
            else
            {
                //oT.Name = obj.Name;
                //oT.Price = obj.Price;
                //oT.Stock = obj.Stock;
                oT.DateModify = DateTime.Now;
                _QLDonHangDbContext.OrderItem.Update(oT);
                await _QLDonHangDbContext.SaveChangesAsync();
                return oT;
            }
        }
        public async Task<OrderItem> getByIdAsync(int id)
        {
            try
            {
                var obj = await _QLDonHangDbContext.OrderItem.Where(_ => _.Id == id).FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception ex)
            {
                return new OrderItem();
            }
        }

        public async Task<List<OrderItem>> getAllAsync()
        {
            try
            {
                var lst = await _QLDonHangDbContext.OrderItem.FromSql($"SELECT p.* FROM OrderItem p").ToListAsync();
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
                var obj = await _QLDonHangDbContext.OrderItem.Where(_ => _.Id == id).FirstOrDefaultAsync();
                _QLDonHangDbContext.OrderItem.Remove(obj);
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
