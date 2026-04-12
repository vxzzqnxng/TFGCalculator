FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5159

ENV ASPNETCORE_URLS=http://+:5159

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["TFGCalculator.csproj", "./"]
RUN dotnet restore "TFGCalculator.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TFGCalculator.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TFGCalculator.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bin/Release/net8.0/TFGCalculator.dll"]
