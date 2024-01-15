using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Xunit;

namespace CarWorkshop.Application.ApplicationUser.Tests
{
    public class UserContextTests
    {
        #region ApplicationUser
        [Fact()]
        public void IsInRole_WithMatchingCaseRole_ShouldReturnTrue()
        {
            // Arrange
            var claims = new[] { new Claim(ClaimTypes.Role, Roles.Admin) };
            var identity = new ClaimsIdentity(claims , "Test");
            var user = new ClaimsPrincipal(identity);

            var httpContext = new DefaultHttpContext { User = user };
            var httpContextAccessor = new HttpContextAccessor { HttpContext = httpContext };
            var userCntext = new UserContext(httpContextAccessor);

            // Act
            bool result = userCntext.IsInRole("Admin");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsInRole_WithNoAuthetication_ShouldReturnFalse()
        {
            // Arrange
            var claims = new[] { new Claim(ClaimTypes.Role, Roles.Admin) };
            var identity = new ClaimsIdentity(claims);
            var user = new ClaimsPrincipal(identity);

            var httpContext = new DefaultHttpContext { User = user };
            var httpContextAccessor = new HttpContextAccessor { HttpContext = httpContext };
            var userCntext = new UserContext(httpContextAccessor);

            // Act
            bool result = userCntext.IsInRole(Roles.Admin);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsInRole_WithNoMatchingCaseRole_ShouldReturnFalse()
        {
            //Arrange
            var claims = new Claim[] { 
                new Claim(ClaimTypes.Role,Roles.Admin),
                new Claim(ClaimTypes.Role, "wiedzmin"),
                new Claim(ClaimTypes.Role, "AdamMalysz"),
            };
            var identity = new ClaimsIdentity(claims,"Test");
            var user = new ClaimsPrincipal(identity);
            var httpContext =new DefaultHttpContext { User = user };
            var httpContextAccessor = new HttpContextAccessor
            {
                HttpContext = httpContext
            };
            var userCntext = new UserContext (httpContextAccessor);

            // Act
            bool result = userCntext.IsInRole(Roles.Admin.ToLower());

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetUserRoles_WithAuthenticatedUser_ShouldReturnCrrentUserRoles()
        {
            // Arrange
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "xxxxxx-xxxxxx-xxxxxx-xxxxxx"),
                new Claim(ClaimTypes.Role, Roles.Admin),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.Email, "test@gmail.com"),
            };

            var identity = new ClaimsIdentity(claims, "Test");
            var user = new ClaimsPrincipal(identity);

            var httpContext = new DefaultHttpContext { User = user };
            var httpContextAccessor = new HttpContextAccessor { HttpContext = httpContext };
            var userContext = new UserContext(httpContextAccessor);

            // Act
            var resultClaims = userContext.GetUserRoles()?.ToList();
            var testClaims = httpContextAccessor.HttpContext.User.Claims
                                                .Where(c => c.Type == ClaimTypes.Role)
                                                .Select(c => c.Value)
                                                .ToList();

            // Assert
            resultClaims.Should().BeEquivalentTo(testClaims);
        }

        [Fact]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCrrentUser()
        {
            //Arrange
            IEnumerable<Claim> claims = new[]
            {
                new Claim(ClaimTypes.Role, Roles.Admin),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.Email, "test@test.test"),
                new Claim(ClaimTypes.NameIdentifier, "873614")
            };
            var claimIdentity = new ClaimsIdentity(claims, "Test");
            var userPrincipal = new ClaimsPrincipal(claimIdentity);
            var httpContext = new DefaultHttpContext { User = userPrincipal };

            var httpContextAccessor = new HttpContextAccessor { HttpContext = httpContext };

            //Act
            var userContext = new UserContext(httpContextAccessor);
            
            var currentUser = userContext.GetCurrentUser();

            var id = userPrincipal.Claims.Where(r => r.Type == ClaimTypes.NameIdentifier).Single().Value;
            var email = userPrincipal.Claims.Where(r => r.Type == ClaimTypes.Email).Single().Value;
            var currentUserTest = new CurrentUser(id,email);

            //Arrange
            currentUser.Should().BeEquivalentTo(currentUserTest);
        }
        #endregion
    }
}