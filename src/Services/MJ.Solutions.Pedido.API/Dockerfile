#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MJ.Solutions.Pedido.API/MJ.Solutions.Pedido.API.csproj", "MJ.Solutions.Pedido.API/"]
RUN dotnet restore "MJ.Solutions.Pedido.API/MJ.Solutions.Pedido.API.csproj"
COPY . .
WORKDIR "/src/MJ.Solutions.Pedido.API"
RUN dotnet build "MJ.Solutions.Pedido.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MJ.Solutions.Pedido.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MJ.Solutions.Pedido.API.dll"]