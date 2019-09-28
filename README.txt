dotnet cli creation commands:

dotnet new sln -o himumsaiddad

dotnet new webapi -o hmsd.encryption

dotnet sln add ./hmsd.encryption/hmsd.encryption.csproj

dotnet new mstest -o hmsd.encryption.tests

dotnet sln add ./hmsd.encryption.tests/hmsd.encryption.tests.csproj


----------------------------------------------------

postman collection in the gateway and encryption project folders

----------------------------------------------------

INITIAL SETUP

1 deploy the encryption webapi or run it locally 
2 update the appsettings.json in the hmsd.gateway project with the baseurl of the hmsd.encryption webapi
3 deploy the gateway webapi or run it locally