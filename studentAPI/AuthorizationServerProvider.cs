using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace studentAPI.Models {
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
            using (StudentRepository _repo = new StudentRepository()) {
                var user = _repo.ValidateUser(context.UserName, context.Password);
                if (user == null) {
                    context.SetError("invalid_grant", "Provided email and pin is incorrect.");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, user.FCACADSTATUS));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.FCLASTNAME+ ", " +user.FCFIRSTNAME));
                identity.AddClaim(new Claim("Email", user.FCEMAIL));

                context.Validated(identity);
            }
        }
    }
}