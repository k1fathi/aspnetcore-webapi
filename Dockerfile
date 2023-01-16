FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["aspnetcore-webapi.csproj", ""]
RUN dotnet restore "./aspnetcore-webapi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "aspnetcore-webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aspnetcore-webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aspnetcore-webapi.dll"]