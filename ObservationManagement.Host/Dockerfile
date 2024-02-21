#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ObservationManagement.Host/ObservationManagement.Host.csproj", "ObservationManagement.Host/"]
COPY ["ObservationManagement.Api/ObservationManagement.Api.csproj", "ObservationManagement.Api/"]
COPY ["Core.Api/Core.Api.csproj", "Core.Api/"]
COPY ["Core.Data/Core.Data.csproj", "Core.Data/"]
COPY ["Core.Dtos/Core.Dtos.csproj", "Core.Dtos/"]
COPY ["ObservationManagement.Data/ObservationManagement.Data.csproj", "ObservationManagement.Data/"]
COPY ["ObservationManagement.Dtos/ObservationManagement.Dtos.csproj", "ObservationManagement.Dtos/"]
COPY ["ObservationManagement.Data.MongoDb/ObservationManagement.Data.MongoDb.csproj", "ObservationManagement.Data.MongoDb/"]
COPY ["Core.Data.MongoDb/Core.Data.MongoDb.csproj", "Core.Data.MongoDb/"]
RUN dotnet restore "./ObservationManagement.Host/./ObservationManagement.Host.csproj"
COPY . .
WORKDIR "/src/ObservationManagement.Host"
RUN dotnet build "./ObservationManagement.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ObservationManagement.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ObservationManagement.Host.dll"]