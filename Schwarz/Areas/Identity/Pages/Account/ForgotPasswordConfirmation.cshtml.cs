
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Encodings.Web;

namespace Schwarz.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        public string? UrlResetPassword { get; set; }
        public void OnGet(string url)
        {
                UrlResetPassword = HtmlEncoder.Default.Encode(url);

        }
    }
}
