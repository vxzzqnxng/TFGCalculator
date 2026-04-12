FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TFGCalculator.csproj", "."]
RUN dotnet restore "TFGCalculator.csproj"
COPY . .
RUN dotnet publish "TFGCalculator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM nginx:alpine AS final
RUN echo 'server { \
    listen 80; \
    server_name localhost; \
    charset utf-8; \
    location / { \
        root /usr/share/nginx/html; \
        try_files $uri $uri/ =404; \
    } \
}' > /etc/nginx/conf.d/default.conf

WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .
EXPOSE 80
