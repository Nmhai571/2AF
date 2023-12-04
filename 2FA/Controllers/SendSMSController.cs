 using _2FA.Dtos;
using _2FA.Entities;
using _2FA.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.TwiML.Messaging;

namespace _2FA.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SendSMSController : ControllerBase
    {
        private readonly ISMSService _service;
        private readonly SMSDbContext _context;
        public SendSMSController(ISMSService sMSService, SMSDbContext context)
        {
            _service = sMSService;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> SendSMS(MessageRessourceDto model)
        {
            try
            {
                var result = await _service.SendCode(model.Phone);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Check(string code)
        {

            var latestCode = _context.sMSCodes.OrderByDescending(c => c.Id).FirstOrDefault();
            if (!latestCode.Code.Equals(code))
            {
                return BadRequest("Mã xác minh không đúng");
            }
            return Ok("Hello");
        }
    }
}
