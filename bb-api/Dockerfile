FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-bionic AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-bionic AS build
WORKDIR /src
COPY ["bb-api/bb-api.csproj", "bb-api/"]
RUN dotnet restore "bb-api/bb-api.csproj"
COPY . .
WORKDIR "/src/bb-api"
RUN dotnet build "bb-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "bb-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bb-api.dll"]"]