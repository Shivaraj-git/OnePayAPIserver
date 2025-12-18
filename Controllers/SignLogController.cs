using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnePayAPI.IServices;
using OnePayAPI.Models.DTOs;
namespace OnePayAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignLogController : ControllerBase
    {
        private readonly ISignLogServices _signLogServices;
        public SignLogController(ISignLogServices signLogServices)
        {
            _signLogServices = signLogServices;
        }
        //Route: api/SignLog/SignUp
        [HttpPost]
        public IActionResult SignUp([FromBody] SignUpDTO signUpDTO)
        {
            if (signUpDTO == null) return BadRequest("Invalid request");
            var merchant = _signLogServices.SignUp(signUpDTO.FullName, signUpDTO.BusinessName, signUpDTO.Email, signUpDTO.PhoneNumber, signUpDTO.Password);
            if (merchant == null) return BadRequest("Merchant with given email or phone number already exists");//400
            return Ok("Merchant Registered Successfully");//200
        }
        //Route: api/SignLog/Login
        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null) return BadRequest("Invalid request");
            var merchant = _signLogServices.Login(loginDTO.LoginInput, loginDTO.Password);
            if (merchant == null) return BadRequest("Invalid login credentials");//400
            return Ok("Login Successful");//200
        }
    }
}
