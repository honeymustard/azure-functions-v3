# Azure Function Sample
A sample Azure Functions 3.0 project with dependency injection, github action deploy routine, ready for local development.

## How to run Azure functions locally
Azure Functions will run locally like they run in Azure, if you want to start a timer on demand you can trigger it with a [script](run.py) or use [Postman](https://www.postman.com/downloads/) to send requests.

* Download [azure-functions-core-tools](https://github.com/Azure/azure-functions-core-tools) to get the Func CLI
* Update AzureWebJobsStorage account in [local.settings.json](local.settings.json) with Azure blob storage credentials
* View source for example timer [HorseTimer](Functions/Horse/HorseTimer)

```
# Build the project
dotnet build

# Start function host with a single active function
func start --functions HorseTimer

# While function host is running, you can trigger functions on demand
http://localhost:7071/admin/functions/HorseTimer
```

## Use the Dependency Injection container
This works just like it does in ASP.NET Core applications
* Add a service to the DI-container in [Startup](Startup.cs)
* View an example service [FakeClient](Services/FakeClient.cs)

## Deploy functions to Azure with Github Actions
* Download publish settings from Azure Function in Azure Portal
* Paste publish settings in a Github secret, call it AZURE_FUNCTIONAPP_PUBLISH_PROFILE
* View example action workflow [Azure.yml](.github/workflows/azure.yml), update application name
* Deploy by committing to main branch
* All functions can be monitored in Azure Portal

## Related documentation
* [Azurite](https://github.com/Azure/Azurite)
* [Core tools](https://github.com/Azure/azure-functions-core-tools)
* [Class library](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-class-library)
* [Local functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=windows%2Ccsharp%2Cbash)
* [Github Actions](https://github.com/features/actions)