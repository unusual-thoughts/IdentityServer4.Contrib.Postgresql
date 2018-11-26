using AutoMapper;

namespace IdentityServer4.PostgresqlUpdated.Mappers
{
    public class PersistedGrantMapperProfile : Profile
    {
        public PersistedGrantMapperProfile()
        {
            CreateMap<Entities.PersistedGrant, Models.PersistedGrant>(MemberList.Destination);

            // model to entity
            CreateMap<Models.PersistedGrant, Entities.PersistedGrant>(MemberList.Source);
        }
       
       
    }
}
