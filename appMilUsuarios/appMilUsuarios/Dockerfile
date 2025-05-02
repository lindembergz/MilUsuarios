FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0.100 AS build
RUN mkdir -p /src && chmod -R 755 /src
WORKDIR /src

COPY Program.cs .
COPY UsuariosController.cs .
COPY UsuarioContext.cs .

RUN dotnet new webapi -o AppMilUsuarios

RUN dotnet add AppMilUsuarios/AppMilUsuarios.csproj package Microsoft.EntityFrameworkCore --version 8.0.8
RUN dotnet add AppMilUsuarios/AppMilUsuarios.csproj package Microsoft.EntityFrameworkCore.InMemory --version 8.0.8
RUN dotnet add AppMilUsuarios/AppMilUsuarios.csproj package prometheus-net.AspNetCore --version 8.2.1
RUN dotnet add AppMilUsuarios/AppMilUsuarios.csproj package Microsoft.Extensions.DependencyInjection --version 8.0.0
RUN dotnet add AppMilUsuarios/AppMilUsuarios.csproj package Swashbuckle.AspNetCore --version 6.7.3

COPY Program.cs AppMilUsuarios/
COPY UsuariosController.cs AppMilUsuarios/
COPY UsuarioContext.cs AppMilUsuarios/

WORKDIR /src/AppMilUsuarios
RUN dotnet build AppMilUsuarios.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish AppMilUsuarios.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppMilUsuarios.dll"]