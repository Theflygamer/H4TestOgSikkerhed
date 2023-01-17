using Microsoft.AspNetCore.Identity;

namespace H4TestOgSikkerhed.Data
{
    public class MyRoleHandler
    {
        public async Task CreateUserRoles(string user, string role, IServiceProvider _serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;

            bool userRoleCheck = await roleManager.RoleExistsAsync(role);
            if (!userRoleCheck)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(role));
            }

            IdentityUser identityUser = await userManager.FindByEmailAsync(user);
            await userManager.AddToRoleAsync(identityUser, role);

        }
    }
}
