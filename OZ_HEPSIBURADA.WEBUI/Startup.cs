using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(OZ_HEPSIBURADA.WEBUI.Startup))]

namespace OZ_HEPSIBURADA.WEBUI
{ 
    // A token will be generated resting on the server for user authorization.
    // Instead of going to the db and checking the session person every time, you will check it on the machine once, thanks to the token.
    // In this way, we make the server independent of db and UI as an authentication mechanism.
    // Normally session works like this; every time we log on, we go to the server database and check if this person is available, 
    // and then they have to go to the UI and be used there.
    // With this structure, the client checks if there is a token of its own on the sever when logged in, 
    // and if there is, it won't need to go to database again.
    // 1. You will enter with your username and password.
    // 2. The machine will verify you from sql once. The moment it does this, it will generate a token mechanism.
    // 3. Since this token mechanism is now permanent on that server, it will check your token on the server when you log in again. 
    // The server does not need to go to db anymore, it'll say that I already have it in db and will do the operations.
    // 4. Whenever you delete, you will go to sql then again, to delete you from db. 
    public class Startup
    {
        // IAppBuilder: Version of the Configuration file on CodeFirst for Identity.
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                // The system will run on a cookie mechanism instead of sessions.
                AuthenticationType = "ApplicationCookie",
                // Where will it go if the verification process does not take place?
                // As soon as the page opens, where will it lead you in the authentication mechanism?
                LoginPath = new PathString("/Account/Login")    // same as loginUrl logic in routeConfig.
            });
        }
    }
}