#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["../chatBot/chatBot.csproj", "../chatBot/"]
COPY ["../Service/Service.csproj", "../Service/"]
RUN dotnet restore "../chatBot/chatBot.csproj"
WORKDIR "/src/."
COPY . .
RUN dotnet build "chatBot.csproj" -c Release

FROM build AS publish
RUN dotnet publish "chatBot.csproj" -c Release -o out

FROM base AS final
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "chatBot.dll"]