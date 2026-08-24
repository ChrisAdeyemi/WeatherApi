FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ./WeatherAPI/WeatherAPI.csproj ./WeatherAPI/
RUN dotnet restore ./WeatherAPI/WeatherAPI.csproj

COPY ./WeatherAPI/ ./WeatherAPI/

WORKDIR /src/WeatherAPI
RUN dotnet publish WeatherAPI.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "WeatherAPI.dll"]
