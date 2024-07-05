# Estágio base para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AppControleMantec.API/AppControleMantec.API.csproj", "AppControleMantec.API/"]
COPY ["AppControleMantec.Application/AppControleMantec.Application.csproj", "AppControleMantec.Application/"]
COPY ["AppControleMantec.Domain/AppControleMantec.Domain.csproj", "AppControleMantec.Domain/"]
COPY ["AppControleMantec.Infra.Data.Mongo/AppControleMantec.Infra.Data.Mongo.csproj", "AppControleMantec.Infra.Data.Mongo/"]
COPY ["AppControleMantec.Infra.IoC/AppControleMantec.Infra.IoC.csproj", "AppControleMantec.Infra.IoC/"]
RUN dotnet restore "AppControleMantec.API/AppControleMantec.API.csproj"
COPY . .
WORKDIR "/src/AppControleMantec.API"
RUN dotnet build "AppControleMantec.API.csproj" -c Release -o /app/build

# Estágio de publicação
FROM build AS publish
RUN dotnet publish "AppControleMantec.API.csproj" -c Release -o /app/publish

# Estágio final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppControleMantec.API.dll"]
