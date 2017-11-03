using System;
using System.Threading.Tasks;
using XamarinAdal.Domain;

namespace XamarinAdal.Interfaces
{
    public interface IAuthenticator
    {
        Task<AuthenticateResponse> Authenticate(string authority, string resource, string clientId, string returnUri);
        Task ClearToken(string authority);
    }
}