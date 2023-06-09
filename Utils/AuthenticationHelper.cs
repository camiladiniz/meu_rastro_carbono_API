using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeuRastroCarbonoAPI.Utils
{
    public static class AuthenticationHelper
    {
        public static string GetTokenString(string jwtSecret, string jwtIssuer, string jwtAudience, string userId)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: new List<Claim>
                {
                    new Claim("userId", userId)
                },
            expires: DateTime.Now.AddMinutes(120),
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }

        public static bool IsEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
