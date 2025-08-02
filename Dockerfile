# step 1 Build aplication
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy project files
COPY . .

# Restore packs
RUN dotnet restore "FiapCloudGamesProject.sln"

# Build and publish aplication
RUN dotnet publish "FiapCloudGamesAPI/FiapCloudGamesAPI.csproj" -c Release -o /app/publish

# Step 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

# Exposes port 80 of the container
EXPOSE 80

# Start aplication
ENTRYPOINT ["dotnet", "FiapCloudGamesAPI.dll"]
