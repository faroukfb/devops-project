FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["FullStack.API.csproj", "./"]
RUN dotnet restore "./FullStack.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "FullStack.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FullStack.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Install the PostgreSQL client library
RUN apt-get update \
    && apt-get install -y --no-install-recommends libpq-dev \
    && rm -rf /var/lib/apt/lists/*

ENTRYPOINT ["dotnet", "FullStack.API.dll"]
