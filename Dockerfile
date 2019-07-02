FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Nortal.WebApi/*.csproj ./Nortal.WebApi/
COPY Nortal.WebApi.Tests/*.csproj ./Nortal.WebApi.Tests/
RUN dotnet restore

# copy everything else and build app
COPY Nortal.WebApi/. ./Nortal.WebApi/
WORKDIR /app/Nortal.WebApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/Nortal.WebApi/out ./
ENTRYPOINT ["dotnet", "Nortal.WebApi.dll"]