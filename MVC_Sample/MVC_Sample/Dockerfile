#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MVC_Sample/MVC_Sample.csproj", "MVC_Sample/"]
RUN dotnet restore "MVC_Sample/MVC_Sample.csproj"
COPY . .
WORKDIR "/src/MVC_Sample"
RUN dotnet build "MVC_Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MVC_Sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVC_Sample.dll"]
