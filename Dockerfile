# Dockerfile (for production)
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /app

# Copy everything and restore dependencies
COPY . ./
RUN dotnet restore

# Build and publish in release mode
RUN dotnet publish -c Release -o out

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview
WORKDIR /app

# Copy build output
COPY --from=build /app/out .

ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 5121
ENTRYPOINT ["dotnet", "ProductService.dll", "--urls=http://0.0.0.0:5121"]