FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS projects
WORKDIR /src
COPY . .
RUN find . \! -type d -regextype posix-extended \! -iregex '.+\.(sln|csproj|props|targets|lock\.json)$' -delete \
    && find . -depth -type d -empty -delete

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Install clang/zlib1g-dev dependencies for publishing to native
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev

# Copy only necessary files for restoring dependencies
COPY --from=projects /src .
RUN dotnet restore --locked-mode

# Copy and publish app and libraries
COPY . .
#RUN dotnet publish --no-restore "src/Web/Web.csproj" -c Release -r linux-x64 -o /app
RUN dotnet publish --no-restore "src/Web/Web.csproj" -c Release -o /app

#FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=build /app .
#ENTRYPOINT ["./Rinha.MMXXIV.Q1.Web"]
ENTRYPOINT ["dotnet", "Rinha.MMXXIV.Q1.Web.dll"]
