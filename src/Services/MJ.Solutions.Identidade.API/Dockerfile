#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MJ.Solutions.Identidade.API/MJ.Solutions.Identidade.API.csproj", "MJ.Solutions.Identidade.API/"]
RUN dotnet restore "MJ.Solutions.Identidade.API/MJ.Solutions.Identidade.API.csproj"
COPY . .
WORKDIR "/src/MJ.Solutions.Identidade.API"
RUN dotnet build "MJ.Solutions.Identidade.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MJ.Solutions.Identidade.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MJ.Solutions.Identidade.API.dll"]