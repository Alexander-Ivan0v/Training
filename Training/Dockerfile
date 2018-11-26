FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Training/Training.csproj", "Training/"]
RUN dotnet restore "Training/Training.csproj"
COPY . .
WORKDIR "/src/Training"
RUN dotnet build "Training.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Training.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Training.dll"]