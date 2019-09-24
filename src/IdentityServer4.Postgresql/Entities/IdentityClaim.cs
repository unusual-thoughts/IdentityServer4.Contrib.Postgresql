namespace IdentityServer4.Postgresql.Entities
{
    public class IdentityClaim: UserClaim
    {
        public IdentityResource IdentityResource { get; set; }
    }
}
