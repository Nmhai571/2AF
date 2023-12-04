using Twilio.Rest.Api.V2010.Account;

namespace _2FA.Service
{
    public interface ISMSService
    {
        Task<MessageResource> SendCode(string phone);
    }
}
