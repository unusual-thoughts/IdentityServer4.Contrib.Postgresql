using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using IdentityServer4.Postgresql.Mappers;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Marten;
using System.Linq;

namespace IdentityServer4.Postgresql.Stores
{
	public class ResourceStore : IResourceStore
	{
		private readonly IDocumentSession _documentSession;
		public ResourceStore(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}
		public async Task<ApiResource> FindApiResourceAsync(string name)
		{
			var resource = await _documentSession.Query<Entities.ApiResource>()
				.FirstOrDefaultAsync(_ => _.Name == name).ConfigureAwait(false);

			return resource.ToModel();
		}

		public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
		{
			if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

			var names = scopeNames.ToArray();
			var resources = await _documentSession.Query<Entities.ApiResource>()
				.Where(x => x.Name.IsOneOf(names))
				.ToListAsync();

			return resources.Select(x => x.ToModel());
		}

		public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
		{
			if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

			var names = scopeNames.ToArray();
			var identities = await _documentSession.Query<Entities.IdentityResource>()
				.Where(x => x.Name.IsOneOf(names))
				.ToListAsync();

			return identities.Select(x => x.ToModel());
		}

		public async Task<Resources> GetAllResourcesAsync()
		{
			var identityResources = await _documentSession.Query<Entities.IdentityResource>().ToListAsync();
			var apiResources = await _documentSession.Query<Entities.ApiResource>().ToListAsync();

			return new Resources(
				identityResources.Select(x => x.ToModel()),
				apiResources.Select(x => x.ToModel()));
		}
	}
}
