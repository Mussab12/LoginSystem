using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;

namespace LoginSystem.Repositories.Abstract
{
    public class MyUserService : IUserService
    {
        public Task AuthenticateLocalAsync(string username, string password, SignInMessage message)
        {
            // TODO: Authenticate the user against your local user store
            // and set the appropriate values in the SignInMessage

            return Task.FromResult(0);
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            // TODO: Retrieve the user's profile data and add it to the context

            return Task.FromResult(0);
        }

        public Task GetExternalIdentityAsync(ExternalIdentityRequestContext context)
        {
            // TODO: Retrieve the user's external identity data and add it to the context

            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            // TODO: Check if the user is active and set the appropriate value in the context

            return Task.FromResult(0);
        }

        Task IUserService.PreAuthenticateAsync(PreAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        Task IUserService.AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        Task IUserService.AuthenticateExternalAsync(ExternalAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        Task IUserService.PostAuthenticateAsync(PostAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        Task IUserService.SignOutAsync(SignOutContext context)
        {
            throw new NotImplementedException();
        }

        Task IUserService.GetProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new NotImplementedException();
        }

        Task IUserService.IsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class ExternalIdentityRequestContext
    {
    }
}