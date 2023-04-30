using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages
{
    public class LogOutModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public LogOutModel(IConfiguration congif)
        {
            _configuration = congif;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return SignOut(new AuthenticationProperties
            {
                RedirectUri = _configuration["applicationUrl"]
            },
            OpenIdConnectDefaults.AuthenticationScheme,
            CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
