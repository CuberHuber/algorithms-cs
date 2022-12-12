FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["algorithms-cs.csproj", "./"]
RUN dotnet restore "algorithms-cs.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "algorithms-cs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "algorithms-cs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "algorithms-cs.dll"]
