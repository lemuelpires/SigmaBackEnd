# Imagem base do ASP.NET para execução do container final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5001       # Porta padrão do HTTP no Docker
EXPOSE 5002       # Porta padrão do HTTPS no Docker

# Imagem SDK do .NET para construção e publicação da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["sigmaBack.API/sigmaBack.API.csproj", "sigmaBack.API/"]
RUN dotnet restore "sigmaBack.API/sigmaBack.API.csproj"

# Copia o restante do código para o contexto de build
COPY . . 
WORKDIR "/src/sigmaBack.API"
RUN dotnet build "sigmaBack.API.csproj" -c Release -o /app/build

# Etapa de publicação da aplicação
FROM build AS publish
RUN dotnet publish "sigmaBack.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem final que usará a publicação para executar a aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Comando de inicialização do container
ENTRYPOINT ["dotnet", "sigmaBack.API.dll"]
