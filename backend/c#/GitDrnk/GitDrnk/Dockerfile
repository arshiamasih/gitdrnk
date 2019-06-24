FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["GitDrnk/GitDrnk.csproj", "GitDrnk/"]
RUN dotnet restore "GitDrnk/GitDrnk.csproj"
COPY . .
WORKDIR "/src/GitDrnk"
RUN dotnet build "GitDrnk.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GitDrnk.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GitDrnk.dll"]