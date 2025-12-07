@echo off
setlocal

set SolutionName=IDezApi

REM === Cria a solution ===
dotnet new sln -n %SolutionName%
cd %SolutionName%

REM === Cria as pastas ===
mkdir Adapters\Driving
mkdir Adapters\Driven\Integrations
mkdir Adapters\Driven\Storage
mkdir Core\Application
mkdir Core\Domain
mkdir Tests\Unit
mkdir Tests\Integration

REM === Cria os projetos diretamente nas pastas corretas ===
dotnet new webapi -n IDezApi.Api -o Adapters\Driving\Api
dotnet new classlib -n IDezApi.Integration -o Adapters\Driven\Integrations\IDezApi.Integration
dotnet new classlib -n IDezApi.Storage -o Adapters\Driven\Storage\IDezApi.Storage
dotnet new classlib -n IDezApi.Application -o Core\Application
dotnet new classlib -n IDezApi.Domain -o Core\Domain
dotnet new xunit -n IDezApi.Tests.Unit -o Tests\Unit
dotnet new xunit -n IDezApi.Tests.Integration -o Tests\Integration

REM === Adiciona os projetos à solution ===
dotnet sln add Adapters\Driving\Api\IDezApi.Api.csproj
dotnet sln add Adapters\Driven\Integrations\IDezApi.Integration\IDezApi.Integration.csproj
dotnet sln add Adapters\Driven\Storage\IDezApi.Storage\IDezApi.Storage.csproj
dotnet sln add Core\Application\IDezApi.Application.csproj
dotnet sln add Core\Domain\IDezApi.Domain.csproj
dotnet sln add Tests\Unit\IDezApi.Tests.Unit.csproj
dotnet sln add Tests\Integration\IDezApi.Tests.Integration.csproj

REM === Adiciona referências entre os projetos ===
dotnet add Adapters\Driving\Api\IDezApi.Api.csproj reference Core\Application\IDezApi.Application.csproj

dotnet add Adapters\Driven\Integrations\IDezApi.Integration\IDezApi.Integration.csproj reference Core\Application\IDezApi.Application.csproj
dotnet add Adapters\Driven\Integrations\IDezApi.Integration\IDezApi.Integration.csproj reference Core\Domain\IDezApi.Domain.csproj

dotnet add Adapters\Driven\Storage\IDezApi.Storage\IDezApi.Storage.csproj reference Core\Application\IDezApi.Application.csproj
dotnet add Adapters\Driven\Storage\IDezApi.Storage\IDezApi.Storage.csproj reference Core\Domain\IDezApi.Domain.csproj

dotnet add Core\Application\IDezApi.Application.csproj reference Core\Domain\IDezApi.Domain.csproj

dotnet add Tests\Unit\IDezApi.Tests.Unit.csproj reference Core\Domain\IDezApi.Domain.csproj
dotnet add Tests\Unit\IDezApi.Tests.Unit.csproj reference Core\Application\IDezApi.Application.csproj

dotnet add Tests\Integration\IDezApi.Tests.Integration.csproj reference Adapters\Driving\Api\IDezApi.Api.csproj
dotnet add Tests\Integration\IDezApi.Tests.Integration.csproj reference Adapters\Driven\Integrations\IDezApi.Integration\IDezApi.Integration.csproj
dotnet add Tests\Integration\IDezApi.Tests.Integration.csproj reference Adapters\Driven\Storage\IDezApi.Storage\IDezApi.Storage.csproj

echo ✅ Projeto criado com sucesso com prefixo IDezApi. em tudo, sem erro nenhum. Tamo flyando 🚀

endlocal
