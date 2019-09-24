namespace IdentityServer4.Contrib.Postgresql.Entities
{
    public class IdentityClaim: UserClaim
    {
        public IdentityResource IdentityResource { get; set; }
    }
}
