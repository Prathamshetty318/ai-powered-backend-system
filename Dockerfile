# ---------- BUILD ----------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY . .

RUN dotnet restore "IdentityHub.API/IdentityHub.API.csproj"

RUN dotnet publish "IdentityHub.API/IdentityHub.API.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore


# ---------- RUN ----------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "IdentityHub.API.dll"]