# Etapa de compilación (SDK)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar todo el contenido del proyecto
COPY . ./
# Restaurar dependencias
RUN dotnet restore ModOrientacion.csproj
# Compilar
RUN dotnet build ModOrientacion.csproj -c Release -o /app/build
# Etapa de Publish
FROM build AS publish
RUN dotnet publish ModOrientacion.csproj -c Release -o /app/publish
# Etapa de generar imagen final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModOrientacion.dll"]