#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MJ.Solutions.Pagamento.API/MJ.Solutions.Pagamento.API.csproj", "MJ.Solutions.Pagamento.API/"]
RUN dotnet restore "MJ.Solutions.Pagamento.API/MJ.Solutions.Pagamento.API.csproj"
COPY . .
WORKDIR "/src/MJ.Solutions.Pagamento.API"
RUN dotnet build "MJ.Solutions.Pagamento.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MJ.Solutions.Pagamento.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MJ.Solutions.Pagamento.API.dll"]