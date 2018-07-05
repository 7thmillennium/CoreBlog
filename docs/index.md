# Net Core + Angular + PostgresQl 


# Creating Migrations DB

looper@looper-lappy:~/netcore/ArchBlog/Arch.IS4Host$ dotnet ef migrations add initial_identity_migration -c ApplicationDbContext -o Data/Migrations/AspNetIdentity/ApplicationDb
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
