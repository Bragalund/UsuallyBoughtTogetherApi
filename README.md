# Usually Bought Together API

ASP.NET Core 3.0 Web API that records product co-purchases and serves ML.NET-backed recommendations for items that are usually bought together.

## Features
- REST endpoints for adding product entries and fetching co-purchase predictions
- ML.NET recommendation model served via a prediction engine pool
- Entity Framework Core with SQLite in development and SQL Server in higher environments
- Automatic migrations on startup and OpenAPI/Swagger documentation

## Tech Stack
- .NET Core 3.0
- ASP.NET Core Web API
- Entity Framework Core (SQLite/SQL Server)
- ML.NET recommender
- xUnit tests

## Getting Started
1) Install the .NET Core 3.0 SDK.
2) Navigate to the solution root:
```bash
cd UsuallyBoughtTogetherApi/UsuallyBoughtTogetherApi
```
3) Development run (SQLite):
```bash
export ASPNETCORE_ENVIRONMENT=Development
dotnet restore
dotnet run --project UsuallyBoughtTogetherApi/UsuallyBoughtTogetherApi.csproj
```
4) Production-like run (SQL Server):
   - Set `ASPNETCORE_ENVIRONMENT` to `Production`, `Preprod` or `Test`.
   - Set `UBTA_DB_CONNECTIONSTRING` to a valid SQL Server connection string.
   - Start the app with `dotnet run` as above.

Swagger UI is available at `/swagger` when the app is running.

## Testing
Run the test suite from the solution directory:
```bash
dotnet test UsuallyBoughtTogetherApi.tests/UsuallyBoughtTogetherApi.tests.csproj
```

## Project Layout
- `UsuallyBoughtTogetherApi/` – API project (controllers, services, EF context, migrations, ML model wiring)
- `UsuallyBoughtTogetherApi.tests/` – automated tests
- `Constants/EnvironmentConstants.cs` – supported environment names

## Contributing
Issues and pull requests are welcome. Please include context on expected vs. actual behavior and add tests for new features when possible.

## License
This project is open source under the terms of the `LICENSE` file in this repository.
