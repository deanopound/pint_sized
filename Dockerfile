FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PintSized.Api/PintSized.Api.csproj", "PintSized.Api/"]
RUN dotnet restore "PintSized.Api/PintSized.Api.csproj"
COPY . .
WORKDIR "/src/PintSized.Api"
RUN dotnet build "PintSized.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PintSized.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PintSized.Api.dll"]