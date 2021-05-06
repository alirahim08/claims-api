FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY Carriers.Api/*.csproj ./Carriers.Api/
COPY Carriers.Services/*.csproj ./Carriers.Services/
COPY Carriers.Services.Search.Lucene/*.csproj ./Carriers.Services.Search.Lucene/
COPY Carriers.Domain/*.csproj ./Carriers.Domain/
COPY Carriers.Repository/*.csproj ./Carriers.Repository/
COPY Carriers.Repository.MySql/*.csproj ./Carriers.Repository.MySql/


RUN dotnet restore

# Copy everything else and build
COPY Carriers.Api/. ./Carriers.Api/
COPY Carriers.Services/. ./Carriers.Services/
COPY Carriers.Services.Search.Lucene/. ./Carriers.Services.Search.Lucene/
COPY Carriers.Domain/. ./Carriers.Domain/
COPY Carriers.Repository/. ./Carriers.Repository/
COPY Carriers.Repository.MySql/. ./Carriers.Repository.MySql/


WORKDIR /app/Carriers.Api

FROM build AS publish
RUN dotnet publish "Carriers.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carriers.Api.dll"]
