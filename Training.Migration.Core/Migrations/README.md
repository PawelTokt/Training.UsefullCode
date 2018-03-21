Comsole command for migrations:

Add migration for context:
dotnet ef migrations add Initial -c:BaseContext

Update:
dotnet ef database update -c:BaseContext

Remove migration:
dotnet ef migrations remove -c:BaseContext