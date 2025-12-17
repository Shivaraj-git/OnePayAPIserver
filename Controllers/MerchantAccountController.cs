using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnePayAPI.IServices;
using OnePayAPI.Models.DTOs;

namespace OnePayAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MerchantAccountController : ControllerBase
    {
        private readonly IMerchantAccountService _merchantAccountService;
        public MerchantAccountController(IMerchantAccountService merchantAccountService)
        {
            _merchantAccountService = merchantAccountService;
        }
        //Route: api/MerchantAccount/AddMerchantBankAccount
        [HttpPost]
        public IActionResult AddMechantBankAccount([FromBody] MerchantBankAccountDTO accntDetails)
        {
            if (accntDetails == null) return BadRequest("Invalid request");
            var accnt = _merchantAccountService.AddAccountDetails(accntDetails.MerchantId,accntDetails.AccountHolderName, accntDetails.AccountNumber, accntDetails.Ifsccode, accntDetails.BankName);
            if (accnt == null) return BadRequest("Merchant Not Found");//400
            return Ok("Account Created Successfully");//200
        }
    }
}
