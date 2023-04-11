using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecondaryClient.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly IConfiguration _config;
        public LogoutModel(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return SignOut(
                new AuthenticationProperties
                {
                    RedirectUri = _config["applicationUrl"]
                },
                OpenIdConnectDefaults.AuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme
            );
        }
    }
}
