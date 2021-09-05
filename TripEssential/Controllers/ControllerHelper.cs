using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace TripEssential.Controllers
{
    public class ControllerHelper
    {
        public static bool ValidateAccessToken(HttpRequest request)
        {
            try
            {
                if (!request.Headers.TryGetValue("AccessToken", out StringValues _accessToken))
                {
                    return false;
                }
                else
                {
                    if (_accessToken.FirstOrDefault() ==
                        "7CA7EA049AE1441D813B13A607191621C995397180104D4E81A6F7A47E7AC664F722CF28733346729963642E5608AFF86D3A15B89F6F420AA6CFE3C07FEB0109AF30B9DC4082462EA2F6419C41CE3A97")
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
