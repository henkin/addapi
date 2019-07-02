# Add API 
_Paul Henkin_

This is a sample .NET core web api for adding 3 numbers. By default, when run, it is exposed on http://localhost:5000/api/add

## Requirements
- [dotnet core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- optional: Docker 
- optional: Kubernetes

## Building
`dotnet build`

## Running Locally
`dotnet run --project Nortal.WebApi/Nortal.WebApi.csproj`

## Docker Build
```
cd Nortal.WebApi
docker build . -t add_api:local
```

## Kubernetes Deploy

## Tests

## Notes
