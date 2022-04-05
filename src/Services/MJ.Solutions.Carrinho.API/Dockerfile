#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/MJ.Solutions.Carrinho.API/MJ.Solutions.Carrinho.API.csproj", "src/Services/MJ.Solutions.Carrinho.API/"]
RUN dotnet restore "src/Services/MJ.Solutions.Carrinho.API/MJ.Solutions.Carrinho.API.csproj"
COPY . .
WORKDIR "/src/src/Services/MJ.Solutions.Carrinho.API"
RUN dotnet build "MJ.Solutions.Carrinho.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MJ.Solutions.Carrinho.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MJ.Solutions.Carrinho.API.dll"]