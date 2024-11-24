FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../App.Api/App.Api.csproj", "App.Api/"]
COPY ["../App.Postgres/App.Postgres.csproj", "App.Postgres/"]
COPY ["../Models/Models.csproj", "Models/"]
COPY ["../App.Sqllite/App.Sqllite.csproj", "App.Sqllite/"]
COPY ["../App.SqlServer/App.SqlServer.csproj", "App.SqlServer/"]
RUN dotnet restore "App.Api/App.Api.csproj"

COPY . .
WORKDIR "/src/App.Api"
RUN dotnet build "App.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "App.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.Api.dll"]
