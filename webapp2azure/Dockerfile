FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["webapp2azure/webapp2azure.csproj", "webapp2azure/"]
RUN dotnet restore "webapp2azure/webapp2azure.csproj"
COPY . .
WORKDIR "/src/webapp2azure"
RUN dotnet build "webapp2azure.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webapp2azure.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapp2azure.dll"]
