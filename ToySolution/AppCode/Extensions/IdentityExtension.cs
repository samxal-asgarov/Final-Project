using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.NetCV.AppCode.Extensions
{
    public static partial class Extension
    {
        //ad soyad getirmek ucundur
        static public string GetPrinciplesName(this ClaimsPrincipal principal)
        {
            string name = principal.Claims.FirstOrDefault(n => n.Type.Equals("name"))?.Value; //adini axtarir
            string surname = principal.Claims.FirstOrDefault(n => n.Type.Equals("surname"))?.Value;//soyad axtarir
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(name))
            {
                return $"{name}{surname}";

            }
            return principal.Claims.FirstOrDefault(n => n.Type.Equals("Email"))?.Value;

        }
    }
}


