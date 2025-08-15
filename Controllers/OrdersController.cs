using HotChocolate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;
using QLDonHangAPI.Data;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;
using QLDonHangAPI.Services;
using System.ComponentModel;

namespace QLDonHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _QLDHService;
        private readonly IOrderItemService _ItemService;
        private readonly IProductsService _ProductService;
        public OrdersController(IOrdersService obj, IProductsService product, IOrderItemService item)
        {
            this._QLDHService = obj;
            this._ProductService = product;
            this._ItemService = item;
        }
 
        [HttpPost("insert")]
        public async Task<IActionResult> insertOrder(OrderDTO obj)
        {
            try  
            {
                if(obj.Items ==null || obj.Items.Count==0)
                {
                    return BadRequest("Đơn hàng không hợp lệ !");
                }
                bool isError = false;
                int TotalItem = 0;
                long TotalPrice = 0;
                foreach (ItemDTO oT in obj.Items)
                {
                    TotalItem += oT.Total;
                    TotalPrice += oT.TotalPrice;
                    Products oProduct = await _ProductService.getByIdAsync((int)oT.ProductId);
                    if(oProduct.Stock<oT.Total)  isError = true; 
                }
                if (isError)
                {
                    return BadRequest("Số lượng sản phẩm trong kho không đủ !");
                }

                //Thêm đơn hàng
                Orders objOrder = new Orders();
                objOrder.UserId = obj.UserId;
                objOrder.TotalItem = TotalItem;
                objOrder.TotalPrice = TotalPrice;
                objOrder.DateCreate = DateTime.Now;
                var objReturn = await _QLDHService.Insert(objOrder);
                if(objReturn !=null)
                {
                    //Thêm chi tiết sản phẩm
                    foreach (ItemDTO item in obj.Items)
                    {
                        OrderItem objItem = new OrderItem();
                        objItem.OrderId = objReturn.Id;
                        objItem.ProductId = item.ProductId;
                        objItem.Total = item.Total;
                        objItem.Price = item.Price;
                        objItem.TotalPrice = item.TotalPrice;
                        objItem.DateCreate = DateTime.Now;
                        await _ItemService.Insert(objItem);

                        //Trừ trong kho
                        Products oProduct = await _ProductService.getByIdAsync((int)item.ProductId);
                        oProduct.Stock = oProduct.Stock - item.Total;
                        await _ProductService.Update(oProduct);
                    }
                }    
                return Ok(objOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> deleteOrder(int id)
        {
            try
            {
                Orders obj = await _QLDHService.getByIdAsync(id);
                if (obj == null)
                {
                    return BadRequest("Đơn hàng không tồn tại !");
                }

                bool flag = await _QLDHService.deleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("history")]
        public async Task<IActionResult> historyByUser(int userid)
        {
            try
            {
                var lst = await _QLDHService.getHistoryUser(userid);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("list")]
        public async Task<IActionResult> getListOrder()
        {
            try
            {
                var lst = await _QLDHService.getAllAsync();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
