FROM mcr.microsoft.com/dotnet/sdk:10.0 AS builder
WORKDIR /app
COPY DevelopersTeam.Fruitlogix.Platform/*.csproj DevelopersTeam.Fruitlogix.Platform/
RUN dotnet restore ./DevelopersTeam.Fruitlogix.Platform
COPY . .
RUN dotnet publish ./DevelopersTeam.Fruitlogix.Platform -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=builder /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "DevelopersTeam.Fruitlogix.Platform.dll"]