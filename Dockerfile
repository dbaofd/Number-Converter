# Use the official .NET 8 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file
COPY WebApplication1.csproj .
RUN dotnet restore WebApplication1.csproj

# Copy all source code
COPY . .

# Build and publish the application
RUN dotnet publish WebApplication1.csproj -c Release -o /app/publish

# Use the official .NET 8 runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy the published application
COPY --from=build /app/publish .

# Expose port (Render uses PORT environment variable)
EXPOSE $PORT

# Set the entry point
ENTRYPOINT ["dotnet", "WebApplication1.dll"]