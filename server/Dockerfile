FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["totvs-test.csproj", "./"]
RUN dotnet restore "totvs-test.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "totvs-test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "totvs-test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/totvs.db .
ENTRYPOINT ["dotnet", "totvs-test.dll"]
