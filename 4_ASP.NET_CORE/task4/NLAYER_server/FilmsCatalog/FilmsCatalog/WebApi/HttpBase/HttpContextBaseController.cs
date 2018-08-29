using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace FilmsCtalog.WebApi.HttpBase
{
    public static class HttpContextBaseController
    {
        public static string GetUserIdAsync(this HttpContext context)
        {
            return context.User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
        }
    }
}
    