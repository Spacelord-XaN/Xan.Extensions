param (
    [Parameter(Mandatory=$true)]
    [string]$version,

    [Parameter(Mandatory=$true)]
    [string]$apiKey
)
dotnet build ./Xan.Extensions.sln --configuration Release
dotnet pack ./Xan.Extensions.sln --configuration Release
dotnet nuget push ./src/Xan.Extensions/bin/Release/Xan.Extensions.$version.nupkg --api-key $apiKey --source https://api.nuget.org/v3/index.json