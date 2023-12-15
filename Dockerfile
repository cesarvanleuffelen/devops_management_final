# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

# Set the working directory in the container
WORKDIR /app

# Copy the project files (including .csproj) to the container
COPY . ./

# Restore dependencies and build the project
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Create a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/publish .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "project_manager.dll"]

# Expose the port your app is running on (if needed)
EXPOSE 80
