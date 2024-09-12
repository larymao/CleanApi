#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt update && apt install -y curl

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore
WORKDIR /src
COPY ["Directory.*.props", "."]
COPY ["src/*/*.csproj", "."]
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
RUN dotnet restore "Web/Web.csproj"

FROM restore AS publish
COPY src .
RUN dotnet publish "Web/Web.csproj" -c Release -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
HEALTHCHECK --start-period=15s --interval=60s --timeout=3s CMD curl --fail --silent http://localhost:8080/health || exit 1
ENTRYPOINT ["dotnet", "CleanApi.Web.dll"]

# http://label-schema.org/rc1/
ARG BUILD_DATE
ARG VCS_REF
ARG BUILD_VERSION
LABEL org.label-schema.schema-version="1.0"
LABEL org.label-schema.build-date=$BUILD_DATE
LABEL org.label-schema.name="cleanapi"
LABEL org.label-schema.description="A web API template based on CleanArchitecture."
LABEL org.label-schema.vendor="Lary Mao"
LABEL org.label-schema.vcs-ref=$VCS_REF
LABEL org.label-schema.version=$BUILD_VERSION
LABEL org.label-schema.vcs-url=https://github.com/larymao/CleanApi.git
