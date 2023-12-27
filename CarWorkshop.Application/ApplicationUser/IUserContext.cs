using Microsoft.AspNetCore.Http;

namespace CarWorkshop.Application.ApplicationUser
{
    public interface IUserContext
    {
        IHttpContextAccessor HttpContextAccessor { get; }

        CurrentUser? GetCurrentUser();
        IEnumerable<string>? GetUserRoles();

        bool IsInRole(string roleName);
    }
}