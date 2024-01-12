#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
RUN apk add --no-cache icu-libs icu-data-full tzdata
USER app
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_URLS=http://+:8080
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY ["CompleteApiSample/CompleteApiSample.csproj", "CompleteApiSample/"]
COPY ["CompleteApiSample/CompleteApiSample.Common.csproj", "CompleteApiSample.Common/"]
COPY ["CompleteApiSample/CompleteApiSample.Domain.csproj", "CompleteApiSample.Domain/"]
COPY ["CompleteApiSample/CompleteApiSample.Infrastructure.csproj", "CompleteApiSample.Infrastructure/"]
COPY ["CompleteApiSample/CompleteApiSample.Service.csproj", "CompleteApiSample.Service/"]
RUN dotnet restore "CompleteApiSample/CompleteApiSample.csproj"
COPY . .
WORKDIR "/src/CompleteApiSample"
RUN dotnet build "CompleteApiSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompleteApiSample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompleteApiSample.dll"]