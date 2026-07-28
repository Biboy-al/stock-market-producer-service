# This is a multi stage docker file

# Stage 1: Use this stage to compile the program
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /app
COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /out

# Stage 2: Takes the compiled program and runs it on a smaller image
FROM mcr.microsoft.com/dotnet/runtime:10.0

WORKDIR /app

COPY --from=build /out .

ENTRYPOINT ["dotnet", "stock-market-producer-service.dll"]

