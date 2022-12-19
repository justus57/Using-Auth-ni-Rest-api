using DotNetAuth.Profiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUpdate.Controllers
{
    public class ProfileController : Controller
    {
        ProfileProperty[] requiredProperties = new[] { ProfileProperty.Email, ProfileProperty.DisplayName, ProfileProperty.UniqueID, ProfileProperty.DisplayName };
        // GET: /Profile/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public RedirectResult Login()
        {
            var userProcessUri = Url.Action("Callback", "Profile", null, protocol: Request.Url.Scheme);
            var provider = LoginProvider.Get(LoginProviderRegistry.Facebook.Fullname);
            var authorizationUrl = DotNetAuth.Profiles.Login.GetAuthenticationUri(provider, new Uri(userProcessUri), new DefaultLoginStateManager(Session), requiredProperties);
            authorizationUrl.Wait();
            return Redirect(authorizationUrl.Result.AbsoluteUri);
        }
        // GET: /Process
        [HttpGet]
        public ActionResult Callback(string providerName)
        {
            var userProcessUri = Url.Action("Callback", "Profile", null, protocol: Request.Url.Scheme);
            var provider = LoginProvider.Get(LoginProviderRegistry.Facebook.Fullname);
            var profile = DotNetAuth.Profiles.Login.GetProfile(provider, Request.Url, userProcessUri, new DefaultLoginStateManager(Session), requiredProperties);
            profile.Wait();
            return Content(profile.Result.ToString());
        }
    }
}
 

