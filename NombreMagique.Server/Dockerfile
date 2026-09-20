#sdk sert à developper, restaurer, compiler, publier
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ["NombreMagique.Server/NombreMagique.Server.csproj", "NombreMagique.Server/"]
COPY ["NombreMagique.Shared/NombreMagique.Shared.csproj", "NombreMagique.Shared/"]

RUN dotnet restore "NombreMagique.Server/NombreMagique.Server.csproj"

COPY . .

WORKDIR "/src/NombreMagique.Server"

RUN dotnet publish "NombreMagique.Server.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

#asp.net sert seulement à executer l'application deja compilee
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

# pour ne pas executer en root on cree un user
USER $APP_UID

EXPOSE 8080

ENTRYPOINT ["dotnet", "NombreMagique.Server.dll"]
