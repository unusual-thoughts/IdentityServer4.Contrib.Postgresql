using System.Collections.Generic;

namespace IdentityServer4.Contrib.Postgresql.Entities
{
    public class ClientClaim
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public IDictionary<string, string> Properties { get; } = new Dictionary<string, string>();
    }
}
