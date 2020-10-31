# Azure Functions v3
A sample Azure Functions 3.0 project with dependency injection, github action deploy routine, ready for local development.

## Notes
* Ignore the version 2.0 in [hosts.json](hosts.json), it is not related to the runtime version
* Timeout limit and other settings can be specified in [hosts.json](hosts.json)

## How to run Azure functions locally
Azure Functions will run locally like they run in Azure, if you want to start a timer on demand you can trigger it with a [script](run.py) or use [Postman](https://www.postman.com/downloads/) to send requests. Azure blob storage credentials can be added to [local.settings.json](local.settings.json) if you don't like the additional step of starting Azurite manually.

* Install [azure-functions-core-tools](https://github.com/Azure/azure-functions-core-tools) to get the Func CLI
* Install [azurite](https://github.com/Azure/Azurite) to get local blob storage

```
# Prerequisites
npm i -g azure-functions-core-tools@3 --unsafe-perm true
npm i -g azurite

# Build the project
dotnet build

# Run the blob storage emulator
azurite-blob

# Start function host with a single active function
func start --functions HorseTimer

# While function host is running, you can trigger functions with a POST request
http://localhost:7071/admin/functions/HorseTimer
```

## Use the Dependency Injection container
This works just like it does in ASP.NET Core applications
* Add a service to the DI-container in [Startup](Startup.cs)
* View an example service [FakeClient](Services/FakeClient.cs)
* View an example function [HorseTimer](Functions/HorseTimer.cs)

## Deploy functions to Azure with Github Actions
* Create an Azure blob storage account in Azure Portal
* Create an App setting named AzureWebJobsStorage with blob account connection string
* Download publish settings from Azure Function App in Azure Portal
* Create a Github secret named AZURE_FUNCTIONAPP_PUBLISH_PROFILE, paste publish settings
* Insert application name in Github action workflow [Azure.yml](.github/workflows/azure.yml)
* Deploy to Azure by pushing a commit to main branch
* All functions can be monitored in Azure Portal

## Related documentation
* [Azurite](https://github.com/Azure/Azurite)
* [Core tools](https://github.com/Azure/azure-functions-core-tools)
* [Class library](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-class-library)
* [Local functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=windows%2Ccsharp%2Cbash)
* [Github Actions](https://github.com/features/actions)