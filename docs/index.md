# Net Core + Angular + PostgresQl 


# Creating Migrations DB

`dotnet ef migrations add initial_identity_migration -c ApplicationDbContext -o Data/Migrations/AspNetIdentity/ApplicationDb`

```
[18:57:59 Information] IdentityServer4.Startup
You are using the in-memory version of the persisted grant store. This will store consent decisions, authorization codes, refresh and reference tokens in memory only. If you are using any of those features in production, you want to switch to a different store implementation.

[18:57:59 Debug] IdentityServer4.Startup
Using Identity.Application as default scheme for authentication

[18:57:59 Debug] IdentityServer4.Startup
Using Identity.External as default scheme for sign-in

[18:57:59 Debug] IdentityServer4.Startup
Using Identity.External as default scheme for sign-out

[18:57:59 Debug] IdentityServer4.Startup
Using Identity.Application as default scheme for challenge

[18:57:59 Debug] IdentityServer4.Startup
Using Identity.Application as default scheme for forbid

Done. To undo this action, use 'ef migrations remove'
```


`dotnet ef migrations add initial_is4_server_config_migration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb`

[19:36:54 Debug] IdentityServer4.Startup
Using Identity.Application as default scheme for authentication

[19:36:54 Debug] IdentityServer4.Startup
Using Identity.External as default scheme for sign-in

[19:36:54 Debug] IdentityServer4.Startup
Using Identity.External as default scheme for sign-out

[19:36:54 Debug] IdentityServer4.Startup
Using Identity.Application as default scheme for challenge

[19:36:54 Debug] IdentityServer4.Startup
Using Identity.Application as default scheme for forbid

Your target project 'Arch.IS4Host' doesn't match your migrations assembly 'System.Private.CoreLib'. Either change your target project or change your migrations assembly.
Change your migrations assembly by using DbContextOptionsBuilder. E.g. options.UseSqlServer(connection, b => b.MigrationsAssembly("Arch.IS4Host")). By default, the migrations assembly is the assembly containing the DbContext.
Change your target project to the migrations project by using the Package Manager Console's Default project drop-down list, or by executing "dotnet ef" from the directory containing the migrations project.

`dotnet ef migrations add initial_is4_persisted_grant_migration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb`

```
[19:48:39 Debug] IdentityServer4.Startup
Using Identity.Application as default scheme for authentication

[19:48:39 Debug] IdentityServer4.Startup
Using Identity.External as default scheme for sign-in

[19:48:39 Debug] IdentityServer4.Startup
Using Identity.External as default scheme for sign-out

[19:48:39 Debug] IdentityServer4.Startup
Using Identity.Application as default scheme for challenge

[19:48:39 Debug] IdentityServer4.Startup
Using Identity.Application as default scheme for forbid

Done. To undo this action, use 'ef migrations remove'
```