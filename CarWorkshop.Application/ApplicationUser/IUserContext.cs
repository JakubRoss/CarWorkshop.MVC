using Microsoft.AspNetCore.Http;

namespace CarWorkshop.Application.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
        IEnumerable<string>? GetUserRoles();

        bool IsInRole(string roleName);
    }
}