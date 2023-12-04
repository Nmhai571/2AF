using _2FA.Entities;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace _2FA.Service
{
    public class SMSService : ISMSService
    {
        private readonly SMSSetting _smsSetting;
        private readonly SMSDbContext _context;

        public SMSService(IOptions<SMSSetting> smsSetting, SMSDbContext context)
        {
            _smsSetting = smsSetting.Value;
            _context = context;
        }
        public async Task<MessageResource> SendCode(string phone)
        {
            var code = GenerateRandomCode();
            SMSCode codeModel = new SMSCode();
            codeModel.Code = code;
            TwilioClient.Init(_smsSetting.AccountSID, _smsSetting.AuthToken);
            var result = await MessageResource.CreateAsync(
                body: code,
                from: new PhoneNumber(_smsSetting.PhoneNumber),
                to: new PhoneNumber(phone)
            );
            _context.Add(codeModel);
            await _context.SaveChangesAsync();
            return result;
        }
        private static string GenerateRandomCode()
        {

            return new Random().Next(10000, 99999).ToString();

        }
    }
}
