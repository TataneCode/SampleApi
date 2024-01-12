$MigrationName = Read-Host -Prompt 'Input your migration name'
cd ../..
dotnet ef migrations add $MigrationName --project CompleteApiSample.Infrastructure --startup-project CompleteApiSample
cd ./CompleteApiSample.Infrastructure/Migrations