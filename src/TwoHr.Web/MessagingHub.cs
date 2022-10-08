using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Identity;
using Volo.Abp.Auditing;

namespace TwoHr.Web
{
    [Authorize]
    [DisableAuditing]
    [HubRoute("/my-messaging-hub")]
    public class MessagingHub : AbpHub
    {
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly ILookupNormalizer _lookupNormalizer;

        public MessagingHub(IIdentityUserRepository identityUserRepository, ILookupNormalizer lookupNormalizer)
        {
            _identityUserRepository = identityUserRepository;
            _lookupNormalizer = lookupNormalizer;
        }

        public async Task SendMessage(string nome, string message)
        {
            message = message + " " + nome;

            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
