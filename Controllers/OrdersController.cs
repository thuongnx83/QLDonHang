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
        public OrdersController(IOrdersService obj)
        {
            this._QLDHService = obj;
        }
 
        [HttpPost("insert")]
        public async Task<IActionResult> insertOrder(Orders obj)
        {
            try
            {
                var oT = await _QLDHService.Insert(obj);
                return Ok(oT);
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
                bool flag = await _QLDHService.deleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
