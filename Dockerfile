FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5159
ENV ASPNETCORE_URLS=http://+:5159
# USER app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TFGCalculator.csproj", "."]
RUN dotnet restore "TFGCalculator.csproj"
COPY . .
RUN dotnet build "TFGCalculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TFGCalculator.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN echo "=== Содержимое /app/publish ===" && ls -la /app/publish
RUN echo "=== Поиск DLL в /app/publish ===" && find /app/publish -name "*.dll" -type f
RUN echo "=== Поиск всех файлов в /app/publish (первые 20) ===" && find /app/publish -type f | head -20

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/. .
RUN echo "=== Финальное содержимое /app ===" && ls -la /app
RUN echo "=== Поиск DLL в финальном образе ===" && find /app -name "*.dll" -type f
ENTRYPOINT ["dotnet", "TFGCalculator.dll"]
