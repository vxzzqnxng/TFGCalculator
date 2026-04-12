FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TFGCalculator.csproj", "."]
RUN dotnet restore "TFGCalculator.csproj"
COPY . .
RUN dotnet publish "TFGCalculator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .
EXPOSE 80
