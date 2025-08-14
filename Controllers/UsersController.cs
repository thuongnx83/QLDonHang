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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _QLDHService;
        public UsersController(IUsersService obj)
        {
            this._QLDHService = obj;
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(string username, string password)
        {
            try
            {
                UserInfo objUser = await _QLDHService.getLogin(username, password);
                if (objUser != null)
                {
                    return Ok(objUser);
                }
                else
                    return BadRequest("Username hoặc mật khẩu không hợp lệ !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> register(Users obj)
        {
            try
            {
                bool isExist = await _QLDHService.checkbyUserName(obj.UserName);
                if (isExist == false)
                {
                    var oT = await _QLDHService.Insert(obj);
                    return Ok(oT);
                }
                else
                    return BadRequest("Username đã tồn tại !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> updateUser(Users obj)
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
        public async Task<IActionResult> deleteUser(int id)
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
        [HttpGet("getlist")]
        public async Task<IActionResult> getListUsers()
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
        public async Task<IActionResult> getByIdUser(int id)
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
    }
}
