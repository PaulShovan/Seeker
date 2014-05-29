using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Seeker.Web
{
    public partial class Startup {

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301883
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            // and also store information about a user logging in with a third party login provider.
            // This is required if your application allows users to login
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            app.UseMicrosoftAccountAuthentication(
                clientId: "000000004811E94B",
                clientSecret: "zCJlM1cCv9ddv0IyKuKoFiyeWyskYdvp");

            app.UseTwitterAuthentication(
               consumerKey: "qJRx1ndr4blaPYGw1RbIVPC9m",
               consumerSecret: "SRSWMi0CTHj6BHZjsWlJEgWrGwb3Px8b3pj2TT8zuwRDy40X4Q");

            app.UseFacebookAuthentication(
               appId: "236512299876389",
               appSecret: "8304b4644f5970f8567105ef76b6d1d6");

            //app.UseGoogleAuthentication();
        }
    }
}
