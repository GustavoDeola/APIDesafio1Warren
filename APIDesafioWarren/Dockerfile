#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APIDesafioWarren/APIDesafioWarren.csproj", "APIDesafioWarren/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Application.Models/Application.Models.csproj", "Application.Models/"]
COPY ["Domain Models/Domain.Models.csproj", "Domain Models/"]
COPY ["DomainServices/Domain.Services.csproj", "DomainServices/"]
COPY ["Infrastructure.Data/Infrastructure.Data.csproj", "Infrastructure.Data/"]
RUN dotnet restore "APIDesafioWarren/APIDesafioWarren.csproj"
COPY . .
WORKDIR "/src/APIDesafioWarren"
RUN dotnet build "APIDesafioWarren.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIDesafioWarren.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIDesafioWarren.dll"]