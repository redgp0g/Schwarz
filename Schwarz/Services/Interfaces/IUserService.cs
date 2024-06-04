using Schwarz.Areas.Identity.Data;
using Schwarz.Models;
using System.Security.Claims;

namespace Schwarz.Services.Interfaces
{
    public interface IUserService
    {
        SchwarzUser GetUser(ClaimsPrincipal claimsPrincipal);
    }
}
