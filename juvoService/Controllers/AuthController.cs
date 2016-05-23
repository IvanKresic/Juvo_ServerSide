using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.Mobile.Server.Login;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System;
using juvoService.Models;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace juvoService.Controllers
{
    [MobileAppController]
    public class AuthController : ApiController
    {
        //juvoContext db = new juvoContext();
        private int userID;
        private bool auth = false;

        public async Task<HttpResponseMessage> Post(string email, string password)
        {

            await IsPasswordValid(email, password);
            // return error if password is not correct

            if (!auth)
            {
                return this.Request.CreateUnauthorizedResponse();
            }

            JwtSecurityToken token = this.GetAuthenticationTokenForUser(email);

            return this.Request.CreateResponse(HttpStatusCode.OK, new
            {
                Token = token.RawData,
                Username = email,
                UserId = userID
            });
        }


        private async Task IsPasswordValid(string email, string pass)
        {
            // this is where we would do checks agains a database
            using (var context = new TEST())
            {
                var temp = await context.Users.SqlQuery("SELECT * FROM dbo.Users WHERE Email = '" + email + "' AND Password = '" + pass + "'").ToListAsync();
                if (temp != null)
                {
                    foreach (Users u in temp)
                    {
                        userID = u.ID;
                        auth = true;
                    }
                }
                else
                {
                    auth = false;
                }
                
            }

            
        }


        private JwtSecurityToken GetAuthenticationTokenForUser(string email)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email)
            };

            var signingKey = this.GetSigningKey();
            var audience = this.GetSiteUrl(); // audience must match the url of the site
            var issuer = this.GetSiteUrl(); // audience must match the url of the site 

            JwtSecurityToken token = AppServiceLoginHandler.CreateToken(
                claims,
                signingKey,
                audience,
                issuer,
                TimeSpan.FromHours(24)
                );

            return token;
        }


        private string GetSiteUrl()
        {
            var settings = this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                return "http://localhost";
            }
            else
            {
                return "https://" + settings.HostName + "/";
            }
        }


        private string GetSigningKey()
        {
            var settings = this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // this key is for debuggint and testing purposes only
                // this key should match the one supplied in Startup.MobileApp.cs
                return ConfigurationManager.AppSettings["SigningKey"];
            }
            else
            {
                return Environment.GetEnvironmentVariable("WEBSITE_AUTH_SIGNING_KEY");
            }
        }

        // GET api/Auth
        public string Get()
        {
            return "Hello from custom controller!";
        }
    }
}
