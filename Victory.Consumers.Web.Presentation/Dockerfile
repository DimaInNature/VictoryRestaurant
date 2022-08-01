#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Victory.Consumers.Web.Presentation/Victory.Consumers.Web.Presentation.csproj", "Victory.Consumers.Web.Presentation/"]
RUN dotnet restore "Victory.Consumers.Web.Presentation/Victory.Consumers.Web.Presentation.csproj"
COPY . .
WORKDIR "/src/Victory.Consumers.Web.Presentation"
RUN dotnet build "Victory.Consumers.Web.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Victory.Consumers.Web.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Victory.Consumers.Web.Presentation.dll"]