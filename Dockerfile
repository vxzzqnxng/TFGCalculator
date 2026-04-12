FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5159

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TFGCalculator.csproj", "."]
RUN dotnet restore "TFGCalculator.csproj"
COPY . .
RUN dotnet build "TFGCalculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TFGCalculator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/wwwroot ./wwwroot
RUN dotnet tool install -g dotnet-serve
ENV PATH="${PATH}:/root/.dotnet/tools"
CMD dotnet-serve -p 5159 ./wwwroot
