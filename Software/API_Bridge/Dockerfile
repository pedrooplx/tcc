#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base

#TIMEZONE START
RUN echo "America/Sao_Paulo" > /etc/timezone
RUN ln -fs /usr/share/zoneinfo/America/Sao_Paulo /etc/localtime
RUN dpkg-reconfigure -f noninteractive tzdata
#TIMEZONE END

WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_ENVIRONMENT="Staging"

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TCC.API/TCC.API.csproj", "TCC.API/"]
COPY ["TCC.Application/TCC.Application.csproj", "TCC.Application/"]
COPY ["TCC.Domain/TCC.Domain.csproj", "TCC.Domain/"]
#COPY ["TCC.Infra/TCC.Infra.csproj", "TCC.Infra/"]
RUN dotnet restore "TCC.API/TCC.API.csproj"
COPY . .
WORKDIR "/src/TCC.API"
RUN dotnet build "TCC.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCC.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet TCC.API.dll