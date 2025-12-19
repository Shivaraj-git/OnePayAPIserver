using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnePayAPI.IServices;
using OnePayAPI.Models.DTOs;

namespace OnePayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        //Route(api/Profile?id=_)
        [HttpGet]
        public IActionResult GetMerchantDetails([FromQuery] int id)
        {
            if (id == null) return BadRequest("Invalid Request");//400 status code
            MerchantDTO merchDetails= _profileService.GetProfileDetails(id);
            if (merchDetails == null) return NotFound("Merchant Details Not Found");//404 status code
            return Ok(merchDetails);//200 status code
        }
    }
}
