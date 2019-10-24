# IdentityServer4.Contrib.Postgresql

[![Build status](https://ci.appveyor.com/api/projects/status/vgeofxaqxkgf3ija?svg=true)](https://ci.appveyor.com/project/unusual-thoughts/identityserver4-postgresql)
[![Build status](https://travis-ci.org/unusual-thoughts/IdentityServer4.Postgresql.svg?branch=master)](https://travis-ci.org/unusual-thoughts/IdentityServer4.Postgresql)
[![NuGet Version](http://img.shields.io/nuget/v/IdentityServer4.Postgresql.svg?style=flat)](https://www.nuget.org/packages/IdentityServer4.Contrib.Postgresql/)

`Install-Package IdentityServer4.Contrib.Postgresql`

e.g AspNet Core
```
using IdentityServer4.Contrib.Postgresql.Extensions;

public void ConfigureServices(IServiceCollection services)
{
   var builder = services.AddIdentityServer();
   builder.AddConfigurationStore().AddOperationalStore();
}
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
 {
    app.UseIdentityServer():
 }
 ```
 This will register all the `IdentityServer` stores and optionally a Marten's `IDocumentSession` as well as `IDocumentStore` if you pass a connection string;
 
