using HotChocolate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
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
    [EnableRateLimiting("fixed")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _QLDHService;
        private readonly IDistributedCache _cache;
        public ProductsController(IProductsService obj, IDistributedCache cache)
        {
            this._QLDHService = obj;
            _cache = cache;
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> getListProducts()
        {
            try
            {
                string cacheKey = "key_cache_list_product";
                string cachedData = await _cache.GetStringAsync(cacheKey);

                if (cachedData != null)
                {
                   
                    return Ok(JsonConvert.DeserializeObject<List<Products>>(cachedData) );
                }
                else
                {
                    var lst = await _QLDHService.getAllAsync(); 
                    var cacheEntryOptions = new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                    };

                    await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(lst), cacheEntryOptions);

                    return Ok(lst);
                } 
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
