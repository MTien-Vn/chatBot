#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["../chatBot/chatBot.csproj", "chatBot/"]
COPY ["../Service/Service.csproj", "Service/"]
RUN dotnet restore "chatBot/chatBot.csproj"
COPY . .
WORKDIR "/src/chatBot"
RUN dotnet build "chatBot.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "chatBot.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "chatBot.dll"]