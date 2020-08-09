FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MVC_Sample/*.csproj ./MVC_Sample/
RUN dotnet restore

# copy everything else and build app
COPY MVC_Sample/. ./MVC_Sample/
WORKDIR /app/MVC_Sample
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY ["MVC_Sample/aspnetapp.pfx", "./"] # Added
COPY --from=build /app/MVC_Sample/out ./
ENTRYPOINT ["dotnet", "MVC_Sample.dll"]