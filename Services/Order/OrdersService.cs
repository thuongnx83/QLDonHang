using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        public async Task<List<Orders>> getHistoryUser(int userid)
        {
            try
            {
                var lst = await _QLDonHangDbContext.Orders.Where(x=>x.UserId== userid).ToListAsync();
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ReportDay>> reportDay(DateTime day)
        {
            try
            {
                var lst = await _QLDonHangDbContext.Database.SqlQueryRaw<ReportDay>($"Select p.Id,p.Name,SUM(i.Total) as TotalItem,SUM(i.TotalPrice) as TotalValue  from Products p left join orderitem i on i.ProductID=p.Id WHERE day(i.DateCreate)={0} and month(i.DateCreate)={1} and year(i.DateCreate)={2} GROUP BY p.Id, p.Name", new object[] { day.Day, day.Month, day.Year }).ToListAsync();
                
                return  lst; 
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<ReportWeek>> reportWeek(DateTime day)
        {
            try
            {
                var lst = await _QLDonHangDbContext.Database.SqlQueryRaw<ReportWeek>($"Select p.Id,p.Name,SUM(i.Total) as TotalItem,SUM(i.TotalPrice) as TotalValue  from Products p left join orderitem i on i.ProductID=p.Id WHERE day(i.DateCreate)={0} and month(i.DateCreate)={1} and year(i.DateCreate)={2} GROUP BY p.Id, p.Name", new object[] { day.Day, day.Month, day.Year }).ToListAsync();
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<ReportMonth>> reportMonth(int year)
        { 
                try
                {
                    var lst = await _QLDonHangDbContext.Database.SqlQueryRaw<ReportMonth>($"Select p.Id,p.Name,SUM(i.Total) as TotalItem,SUM(i.TotalPrice) as TotalValue  from Products p left join orderitem i on i.ProductID=p.Id WHERE day(i.DateCreate)={0} and month(i.DateCreate)={1} and year(i.DateCreate)={2} GROUP BY p.Id, p.Name", new object[] { year, year, year }).ToListAsync();
                    return lst;
                }
                catch (Exception ex)
                {
                    return null;
                } 
        }
    }
}
