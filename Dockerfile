FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["TechnoAcademyApi.csproj", "TechnoAcademyApi/"]
RUN dotnet restore "TechnoAcademyApi/TechnoAcademyApi.csproj"
COPY . .
WORKDIR "/src/TechnoAcademyApi"
RUN dotnet build "TechnoAcademyApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechnoAcademyApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechnoAcademyApi.dll"]