FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 81

# Using the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copying the solution file and restoring the project dependencies
COPY ["ProductManagement.sln", "./"]
COPY ["ProductManagement/ProductManagement.csproj", "ProductManagement/"]
RUN dotnet restore "ProductManagement/ProductManagement.csproj"

# Copying the rest of the app source code and building it
COPY . .
WORKDIR "/src/ProductManagement"
RUN dotnet build "ProductManagement.csproj" -c Release -o /app/build

# Publishing the app
FROM build AS publish
RUN dotnet publish "ProductManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Creating the final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Setting the entry point for the application
ENTRYPOINT ["dotnet", "ProductManagement.dll"]