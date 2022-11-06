using AdWeb.AppServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.Infrastructure.Identity
{
    public class HttpContextClaimsAccessor : IClaimsAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public HttpContextClaimsAccessor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Task<IEnumerable<Claim>> GetClaims(CancellationToken cancellation)
        {
            return (Task<IEnumerable<Claim>>)_contextAccessor.HttpContext.User.Claims;
        }
    }
}
