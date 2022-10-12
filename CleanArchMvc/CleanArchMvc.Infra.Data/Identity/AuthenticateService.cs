using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser()
            {
                Email = email,
                UserName = email
            };

            var result = await userManager.CreateAsync(applicationUser, password);

            if (result.Succeeded)
                await signInManager.SignInAsync(applicationUser, isPersistent: false);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}