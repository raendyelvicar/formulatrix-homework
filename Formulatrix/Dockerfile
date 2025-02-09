FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Formulatrix/Formulatrix.csproj", "Formulatrix/"]
COPY ["CodingCompetencyTest/CodingCompetencyTest.csproj", "CodingCompetencyTest/"]
COPY ["ObjectOrientedTest/ObjectOrientedTest.csproj", "ObjectOrientedTest/"]
COPY ["SoftwareComprehensionTest/SoftwareComprehensionTest.csproj", "SoftwareComprehensionTest/"]
RUN dotnet restore "Formulatrix/Formulatrix.csproj"
COPY . .
WORKDIR "/src/Formulatrix"
RUN dotnet build "Formulatrix.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Formulatrix.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Formulatrix.dll"]
