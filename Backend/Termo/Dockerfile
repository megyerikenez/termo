#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN mkdir Email
COPY ["Termo/Termo.csproj", "Termo/"]
COPY ["Termo.Core/Termo.Core/Termo.Core.csproj", "Termo.Core/Termo.Core/"]
COPY ["Termo.Data/Termo.Data/Termo.Data.csproj", "Termo.Data/Termo.Data/"]
RUN dotnet restore "Termo/Termo.csproj"
COPY . .
WORKDIR "/src/Termo"
RUN dotnet build "Termo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Termo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Termo.dll"]