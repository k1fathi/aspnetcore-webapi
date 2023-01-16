#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["aspnetcore-webapi/aspnetcore-webapi.csproj", "aspnetcore-webapi/"]
RUN dotnet restore "aspnetcore-webapi/aspnetcore-webapi.csproj"
COPY . .
WORKDIR "/src/aspnetcore-webapi"
RUN dotnet build "aspnetcore-webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aspnetcore-webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aspnetcore-webapi.dll"]

RUN docker run