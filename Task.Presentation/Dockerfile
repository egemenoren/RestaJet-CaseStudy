#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN sed -i 's/CipherString = DEFAULT@SECLEVEL=2/CipherString = DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Task.Presentation/CaseStudy.Presentation.csproj", "Task.Presentation/"]
COPY ["Task.Application/CaseStudy.Application.csproj", "Task.Application/"]
COPY ["CaseStudy.ExternalServices/CaseStudy.ExternalServices.csproj", "CaseStudy.ExternalServices/"]
COPY ["Task.Core/CaseStudy.Core.csproj", "Task.Core/"]
COPY ["Task.Infrastructure/CaseStudy.Infrastructure.csproj", "Task.Infrastructure/"]
RUN dotnet restore "Task.Presentation/CaseStudy.Presentation.csproj"
COPY . .
WORKDIR "/src/Task.Presentation"
RUN dotnet build "CaseStudy.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CaseStudy.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CaseStudy.Presentation.dll"]