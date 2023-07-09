FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /applayers
EXPOSE 5001
EXPOSE 4200

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ./src/DSTest.Api/*.csproj ./src/DSTest.Api/
COPY ./src/DSTest.Application/*.csproj ./src/DSTest.Application/
COPY ./src/DSTest.Domain/*.csproj ./src/DSTest.Domain/
COPY ./src/DSTest.Infrastructure/*.csproj ./src/DSTest.Infrastructure/

COPY ./tests/DSTest.UnitTests/*.csproj ./tests/DSTest.UnitTests/
COPY ./tests/DSTest.IntegrationTests/*.csproj ./tests/DSTest.IntegrationTests/
RUN dotnet restore ./CleanTemplate.sln

# copy everything else and build app
COPY . .
RUN dotnet publish -c Release -o /app/build-dll

FROM base AS final
WORKDIR /app
COPY --from=build /app/build-dll .
ENV ASPNETCORE_URLS=http://+:5001
ENTRYPOINT ["dotnet", "DSTest.Api.dll"]
