using System;
using System.Collections.Generic;
using IdentityServer4.Services;
using Marten;
using Microsoft.Extensions.Logging;
using IdentityServer4.Contrib.Postgresql.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Contrib.Postgresql.Services
{
    public class CorsPolicyService : ICorsPolicyService
    {
        private readonly ILogger<CorsPolicyService> _logger;
        private readonly IDocumentSession _documentSession;
        public CorsPolicyService(ILogger<CorsPolicyService> logger, IDocumentSession documentSession)
        {
            _logger = logger;
            _documentSession = documentSession;
        }
        public async Task<bool> IsOriginAllowedAsync(string origin)
        {
            var origins = await _documentSession.Query<Client>()
                .SelectMany(x => x.AllowedCorsOrigins)
                .Select(y => y.Origin)
                .Distinct()
                .ToListAsync().ConfigureAwait(false);

            var distinctOrigins = new HashSet<string>(origins.Where(x => x != null), StringComparer.OrdinalIgnoreCase);
            var isAllowed = distinctOrigins.Contains(origin.ToLower());

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("Origin {origin} is allowed: {originAllowed}", origin, isAllowed);
            }

            return isAllowed;

        }
    }
}
