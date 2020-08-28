# Northwind app - MVC - Part I

This repo is a very basic MVC application to show Customers and their orders.

# Purpose
This repo is the solution for northwind-mvc-part-I.

https://op-gitlab.howest.be/TI/2019-2020/s4-.net-technology/cccp-ibc/exercises/webapps/northwind-mvc-i

# Build the solution
  - Remove the entity packages from the csproj file
  - Remove the Libray/Model folder
  - Add the entity packages for SQL expres (see cheat sheets)
  - Scaffold the models with the **force** and **no build** flag
    - Change the connection string of scaffold command.
    -   ```> dotnet ef dbcontext scaffold "Data Source=639GTQ2\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Library\Models -f --no-build```
  - Create a new NortwindContext object in the service classes.
  - Execute with dotnet run
  - surf to https://localhost:5001