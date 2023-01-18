using Bunit;
using Bunit.TestDoubles;
using H4TestOgSikkerhed.Areas.Identity;
using H4TestOgSikkerhed.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace H4TestOgSikkerhedTest
{
    public class AuthenticationTest
    {
        [Fact]
        public void UserIsAuthenticated()
        {
            // Arrange
            TestContext context = new();
            context.Services.AddSingleton<MyRoleHandler>();
            context.Services.AddSingleton<EmailToFileService>();
            context.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();


            // Act
            context.AddTestAuthorization().SetAuthorized("jens");
            var index = context.RenderComponent<H4TestOgSikkerhed.Pages.Index>();

            // Assert
            Assert.True(index.Instance.IsAuthenticated);
        }

        [Fact]
        public void UserIsNotAuthenticated()
        {
            // Arrange
            TestContext context = new();
            context.Services.AddSingleton<MyRoleHandler>();
            context.Services.AddSingleton<EmailToFileService>();
            context.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();


            // Act
            context.AddTestAuthorization().SetNotAuthorized();
            var index = context.RenderComponent<H4TestOgSikkerhed.Pages.Index>();

            // Assert
            Assert.False(index.Instance.IsAuthenticated);
        }

        [Fact]
        public void UserIsAdminTest()
        {
            // Arrange
            TestContext context = new();
            context.Services.AddSingleton<MyRoleHandler>();
            context.Services.AddSingleton<EmailToFileService>();
            context.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();


            // Act
            context.AddTestAuthorization().SetAuthorized("jens");
            context.AddTestAuthorization().SetRoles("Admin");
            var index = context.RenderComponent<H4TestOgSikkerhed.Pages.Index>();

            // Assert
            Assert.True(index.Instance.IsAdmin);
        }

        [Fact]
        public void UserIsNotAdminTest()
        {
            // Arrange
            TestContext context = new();
            context.Services.AddSingleton<MyRoleHandler>();
            context.Services.AddSingleton<EmailToFileService>();
            context.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();


            // Act
            context.AddTestAuthorization().SetAuthorized("jens");
            var index = context.RenderComponent<H4TestOgSikkerhed.Pages.Index>();


            // Assert
            Assert.False(index.Instance.IsAdmin);
        }
    }
}