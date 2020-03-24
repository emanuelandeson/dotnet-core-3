FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["GolLabs.API/GolLabs.API.csproj", "GolLabs.API/"]
RUN dotnet restore "GolLabs.API/GolLabs.API.csproj"
COPY . .
WORKDIR "/src/GolLabs.API"
RUN dotnet build "GolLabs.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GolLabs.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GolLabs.API.dll"]