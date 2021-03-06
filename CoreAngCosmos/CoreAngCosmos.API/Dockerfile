#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["CoreAngCosmos.API/CoreAngCosmos.API.csproj", "CoreAngCosmos.API/"]
COPY ["CoreAngCosmos.Service/CoreAngCosmos.Services.csproj", "CoreAngCosmos.Service/"]
COPY ["CoreAngCosmos.Models/CoreAngCosmos.Models.csproj", "CoreAngCosmos.Models/"]
RUN dotnet restore "CoreAngCosmos.API/CoreAngCosmos.API.csproj"
COPY . .
WORKDIR "/src/CoreAngCosmos.API"
RUN dotnet build "CoreAngCosmos.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoreAngCosmos.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoreAngCosmos.API.dll"]
