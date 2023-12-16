using Microsoft.AspNetCore.Http;

namespace CarWorkshop.Application.ApplicationUser
{
    public interface IUserContext
    {
        IHttpContextAccessor HttpContextAccessor { get; }

        CurrentUser GetCurrentUser();
    }
}