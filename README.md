# Add API 
_Paul Henkin_

This is a sample .NET core web api for adding 3 numbers. By default, when run, it is exposed on http://localhost:5000/api/add

## Requirements
- (for local) [dotnet core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- Docker 
- Kubernetes

## Local
- `dotnet build`
- `dotnet run --project Nortal.WebApi/Nortal.WebApi.csproj`

## Docker 
- build: `docker build . -t addapi:local`
- run: `docker run -d -p 8080:80 --name addapi addapi:local`
- verify: `curl -X POST -d '{ "a": "1", "b": "2", "c": "3"}' -H 'Content-Type: application/json' localhost:8080/api/add`
- stop: `docker stop addapi`

## Kubernetes Deploy
```
cd deploy
kubectl apply -f addapi.yaml
kubectl apply -f addapi_service.yaml
```
expose: `kubectl expose deployment addapi --type=LoadBalancer --name=addapi-frontend`

verify: `curl -X POST -d '{ "a": "1", "b": "2", "c": "3"}' -H 'Content-Type: application/json' <SERVICE_EXTERNAL_ADDRESS>:8090/api/add`

## Tests
`dotnet test Nortal.WebApi.Tests/Nortal.WebApi.Tests.csproj`

## Notes
not shown (direction for improvement): 
- good test coverage (integration tests (http errors, post deployment), unit tests)
- makefiles, other build/deploy commands, environments, etc.
