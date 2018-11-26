using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.PostgresqlUpdated.Entities
{
    public abstract class EntityKey
    {
        public string Id { get; set; }
    }
}
