using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CarWorkshop.Application.ApplicationUser
{
    public class UserContext : IUserContext
    {
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        private IHttpContextAccessor HttpContextAccessor { get; }

        public CurrentUser? GetCurrentUser()
        {
            var user = HttpContextAccessor.HttpContext!.User;   
            if (!user.Identity!.IsAuthenticated)
            {
                return null;
            }

            //Ostrzeżenie o potencjalnym null znika, ponieważ używasz operatora !
            //(tzw. null-forgiving operator) w C#. Operator ten informuje kompilator, że masz pewność, że wyrażenie po nim nigdy nie zwróci wartości null.
            var currentUser = new CurrentUser(user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value,
                user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value);

            return currentUser;
        }

        public IEnumerable<string>? GetUserRoles()
        {
            var user = HttpContextAccessor.HttpContext!.User;
            if (!user.Identity!.IsAuthenticated)
            {
                return null;
            }
            return user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
        }

        public bool IsInRole(string roleName)
        {
            var user = HttpContextAccessor.HttpContext!.User;
            bool isaut = user.Identity!.IsAuthenticated;
            if (!user.Identity!.IsAuthenticated)
            {
                return false;
            }

            return user.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == roleName);
        }
    }
}
