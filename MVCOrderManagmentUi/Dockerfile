#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MVCOrderManagmentUi/MVCOrderManagmentUi.csproj", "MVCOrderManagmentUi/"]
RUN dotnet restore "MVCOrderManagmentUi/MVCOrderManagmentUi.csproj"
COPY . .
WORKDIR "/src/MVCOrderManagmentUi"
RUN dotnet build "MVCOrderManagmentUi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MVCOrderManagmentUi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVCOrderManagmentUi.dll"]