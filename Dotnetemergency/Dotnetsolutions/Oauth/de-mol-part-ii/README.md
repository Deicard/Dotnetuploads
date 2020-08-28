# DE MOL - IDENTITY
This MVC application shows how to create a dotnet app with **OAuth2** sign-in functionality.
  - Focus
    - authentication: google sign-in

# How to run this solution
  - Replace the connection string in appsettings.json with your connection string.

  - Build the project with dotnet build.
    - Will give errors, but this is ok.
  
  - Apply the migrations
    - dotnet ef migrations add Initial -o Data/Migrations

  - Add the following package
    - dotnet add package Microsoft.AspNetCore.Authentication.Google

  - Create a new google project:
    - https://developers.google.com/identity/sign-in/web/sign-in#before_you_begin
  
  - Set the client id en secret
    - Execute the following commands in the root folder of the project
    - dotnet user-secrets set "Authentication:Google:ClientId" "<client-id>"
    - dotnet user-secrets set "Authentication:Google:ClientSecret" "<client-secret>"
    - If the commands above do not work:
      - https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=linux

  - dotnet build
  - dotnet run
  



 