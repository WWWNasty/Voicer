using System;
using System.Linq;
using System.Security.Claims;

namespace BusinessLogicLayer.Abstraction.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            Claim userId = user.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

            if (userId != null) return userId.Value;
          
                return String.Empty;

        } 
    }
}