﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CarWorkshop.Application.ApplicationUser
{
    public class UserContext : IUserContext
    {
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public IHttpContextAccessor HttpContextAccessor { get; }

        public CurrentUser GetCurrentUser()
        {
            var user = HttpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                return new CurrentUser("0", "0");
            }

            //Ostrzeżenie o potencjalnym null znika, ponieważ używasz operatora !
            //(tzw. null-forgiving operator) w C#. Operator ten informuje kompilator, że masz pewność, że wyrażenie po nim nigdy nie zwróci wartości null.
            var currentUser = new CurrentUser(user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value,
                user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value);

            return currentUser;
        }
    }
}