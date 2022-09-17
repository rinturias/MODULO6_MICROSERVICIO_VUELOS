FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-end
WORKDIR /app

COPY . .
RUN dotnet restore 
RUN dotnet publish ./Aerolinea.Vuelos.Api/Aerolinea.Vuelos.Api.csproj -c Release -o  /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENV ASPNETCORE_ENVIRONMENT=docker
COPY --from=build-end /app/publish .  

ENTRYPOINT ["dotnet", "Aerolinea.Vuelos.Api.dll"]