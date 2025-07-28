FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CourseManager.API/CourseManager.API.csproj", "CourseManager.API/"]
COPY ["CourseManager.Application/CourseManager.Application.csproj", "CourseManager.Application/"]
COPY ["CourseManager.Domain/CourseManager.Domain.csproj", "CourseManager.Domain/"]
COPY ["CourseManager.Infrastructure/CourseManager.Infrastructure.csproj", "CourseManager.Infrastructure/"]
RUN dotnet restore "CourseManager.API/CourseManager.API.csproj"
COPY . .
WORKDIR "/src/CourseManager.API"
RUN dotnet build "CourseManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CourseManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseManager.API.dll"]
