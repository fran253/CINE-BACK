FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /CINE-BACk

COPY CineBack.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /CINE-BACk/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /CINE-BACk
EXPOSE 7000

COPY --from=build /CINE-BACk/publish .

ENTRYPOINT ["dotnet", "CineBack.dll"]