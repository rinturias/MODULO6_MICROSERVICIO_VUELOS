FROM centos:7 AS base

# Add Microsoft package repository and install ASP.NET Core
RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm \
    && yum install -y aspnetcore-runtime-5.0

# Ensure we listen on any IP Address 
ENV DOTNET_URLS=http://+:80
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
# ... remainder of dockerfile as before
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY . .
RUN dotnet restore 
RUN dotnet publish ./Aerolinea.Vuelos.Api/Aerolinea.Vuelos.Api.csproj -c Release -o  /app/publish

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
# ENV ASPNETCORE_ENVIRONMENT=docker
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aerolinea.Vuelos.Api.dll"]