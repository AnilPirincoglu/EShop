using EShop.IdentityServer.Dtos;
using EShop.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
           var user = new ApplicationUser
           {
               UserName = userRegisterDto.UserName,
               Email = userRegisterDto.Email,
               Name = userRegisterDto.Name,
               Surname = userRegisterDto.Surname
           };
            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("User Created SuccessFully");
            }
            return Ok(result.Errors);
        }
    }
}
