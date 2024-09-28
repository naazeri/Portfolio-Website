# Resume

## Migrations

### Add new migration

`dotnet ef migrations add AddModels --project Resume.DAL/Resume.DAL.csproj --startup-project Resume.Web/Resume.Web.csproj --context Resume.DAL.Context.AppDbContext --configuration Debug`

### Apply migration(essensial for seed database)

`dotnet ef database update --project Resume.Web`

### Drop entire database(remove entire database)

`dotnet ef database drop --project Resume.Web`

### Run project

#### Run in normal mode

`dotnet run --project Resume.Web`

#### Run in watch mode

`dotnet watch --project Resume.Web`
