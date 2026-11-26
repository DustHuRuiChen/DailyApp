FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY NuGet.Config ./
COPY ["DailyApp.API/DailyApp.API/DailyApp.API.csproj", "DailyApp.API/DailyApp.API/"]
RUN dotnet restore "DailyApp.API/DailyApp.API/DailyApp.API.csproj" --configfile NuGet.Config

COPY DailyApp.API/DailyApp.API/ DailyApp.API/DailyApp.API/
WORKDIR "/src/DailyApp.API/DailyApp.API"
RUN dotnet publish "DailyApp.API.csproj" -c Release --no-restore -o /app/publish /p:UseAppHost=false /p:DebugType=None

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
USER 10001:0

ENTRYPOINT ["dotnet", "DailyApp.API.dll"]
