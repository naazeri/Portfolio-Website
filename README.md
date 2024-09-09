# Resume

## Migrations

### Add new migration

`dotnet ef migrations add <migration_name> --project Resume.Web`

### Apply migration

`dotnet ef database update --project Resume.Web`

### Run project

#### Run in normal mode

`dotnet run --project Resume.Web`

#### Run in watch mode

`dotnet watch --project Resume.Web`
