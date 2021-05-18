# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MVC_Sample/*.csproj ./MVC_Sample/
RUN dotnet restore

# copy everything else and build app
COPY MVC_Sample/. ./MVC_Sample/
WORKDIR /source/MVC_Sample
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY ["MVC_Sample/aspnetapp.pfx", "./"] # Added
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "MVC_Sample.dll"]