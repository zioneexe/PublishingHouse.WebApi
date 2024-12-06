using Microsoft.AspNetCore.Identity;

namespace PublishingHouse.WebApi.Auth.Interface
{
    public interface ITokenService
    {
        string CreateJwtToken(IdentityUser user, IList<string> role);
    }
}
