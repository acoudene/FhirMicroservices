#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PatientManagement.Host/PatientManagement.Host.csproj", "PatientManagement.Host/"]
COPY ["PatientManagement.Api/PatientManagement.Api.csproj", "PatientManagement.Api/"]
COPY ["Core.Api/Core.Api.csproj", "Core.Api/"]
COPY ["Core.Data/Core.Data.csproj", "Core.Data/"]
COPY ["Core.Dtos/Core.Dtos.csproj", "Core.Dtos/"]
COPY ["PatientManagement.Data/PatientManagement.Data.csproj", "PatientManagement.Data/"]
COPY ["PatientManagement.Dtos/PatientManagement.Dtos.csproj", "PatientManagement.Dtos/"]
COPY ["PatientManagement.Data.MongoDb/PatientManagement.Data.MongoDb.csproj", "PatientManagement.Data.MongoDb/"]
COPY ["Core.Data.MongoDb/Core.Data.MongoDb.csproj", "Core.Data.MongoDb/"]
RUN dotnet restore "./PatientManagement.Host/./PatientManagement.Host.csproj"
COPY . .
WORKDIR "/src/PatientManagement.Host"
RUN dotnet build "./PatientManagement.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PatientManagement.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientManagement.Host.dll"]