using Microsoft.AspNetCore.Identity;
using Schwarz.Areas.Identity.Data;
using Schwarz.Models;
using Schwarz.Services.Interfaces;
using System.Security.Claims;

namespace Schwarz.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<SchwarzUser> _userManager;
        private readonly SignInManager<SchwarzUser> _signInManager;
        public UserService(UserManager<SchwarzUser> userManager, SignInManager<SchwarzUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public SchwarzUser GetUser(ClaimsPrincipal claimsPrincipal)
        {
            return _userManager.Users.First(x => x.Id == _userManager.GetUserId(claimsPrincipal));
        }
    }
}
