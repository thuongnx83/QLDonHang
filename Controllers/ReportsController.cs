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
    public class ReportsController : ControllerBase
    {
        private readonly IOrdersService _QLDHService;
        private readonly IOrderItemService _ItemService;
        private readonly IProductsService _ProductService;
        public ReportsController(IOrdersService obj, IProductsService product, IOrderItemService item)
        {
            this._QLDHService = obj;
            this._ProductService = product;
            this._ItemService = item;
        }
         
        [HttpPost("day")]
        public async Task<IActionResult> reportDay(DateTime day)
        {
            try
            {
                var lst = await _QLDHService.reportDay(day);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("week")]
        public async Task<IActionResult> reportWeek(DateTime day)
        {
            try
            {
                var lst = await _QLDHService.reportWeek(day);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("month")]
        public async Task<IActionResult> reportMonth(int year)
        {
            try
            {
                var lst = await _QLDHService.reportMonth(year);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
