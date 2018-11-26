using IdentityServer4.PostgresqlUpdated.Entities;
using IdentityServer4.PostgresqlUpdated.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServer4.PostgresqlUpdated.Mappers;
using Xunit;
using GenFu;

namespace IdentityServer4.PostgresqlUpdated.IntegrationTests.Stores
{
	public class ClientStoreTests : IClassFixture<DatabaseFixture>
	{
		private readonly DatabaseFixture martenFixture;
		public ClientStoreTests(DatabaseFixture fixture)
		{
			martenFixture = fixture;
		}

		[Fact]
		public void FindClientByIdAsync_WhenClientExists_ExpectClientRetured()
		{
			var testClient = new Client { Claims = new List<ClientClaim> { new ClientClaim { Type = "type", Value = "value" } }, ClientName = "re", ClientId = "re", AllowedGrantTypes = new List<ClientGrantType> { new ClientGrantType { GrantType = "xxxxx" } } };
			using (var session = martenFixture.Store.OpenSession())
			{
				session.Store(testClient);
				session.SaveChanges();
			}
			using (var session = martenFixture.Store.OpenSession())
			{
				var _client = new ClientStore(session).FindClientByIdAsync(testClient.ClientId).Result;
				Assert.NotNull(_client);
			}
		}
	}
}
