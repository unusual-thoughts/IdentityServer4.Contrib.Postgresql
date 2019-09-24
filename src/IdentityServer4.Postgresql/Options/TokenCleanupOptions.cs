namespace IdentityServer4.Contrib.Postgresql.Options
{
    public class TokenCleanupOptions
    {
        public int Interval { get; set; } = 60;
    }
}
