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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _QLDHService;
        public ProductsController(IProductsService obj)
        {
            this._QLDHService = obj;
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> getListProducts()
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
        [HttpGet("{id}")]
        public async Task<IActionResult> getByIdProduct(int id)
        {
            try
            {
                var obj = await _QLDHService.getByIdAsync(id);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("insert")]
        public async Task<IActionResult> insertProduct(Products obj)
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
        [HttpPost("update")]
        public async Task<IActionResult>updateProduct(Products obj)
        {
            try
            {
                var oT = await _QLDHService.Update(obj); 
                return Ok(oT);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> deleteProduct(int id)
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
