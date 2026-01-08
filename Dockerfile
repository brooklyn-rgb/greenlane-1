# Use .NET 8 SDK
FROM mcr.microsoft.com AS build
WORKDIR /src
COPY ["greenlane.csproj", "./"]
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Use .NET 8 Runtime
FROM mcr.microsoft.com AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "greenlane.dll"]
