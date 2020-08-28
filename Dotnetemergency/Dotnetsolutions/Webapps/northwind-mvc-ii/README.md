# Northwind app - MVC - Part II
This MVC application shows the basic of MVC in dotnet core.
  - Focus
    - **ViewModels**: Specific models for a view.
    - **Tag helpers**: Custom dotnet core html attributes.
    - **Forms**: Submitting forms in dotnet core mvc.
    - **Sessions**: Store temporally data.

# Purpose
Solution for **northwind_mvc_part_II**
Create a very basic MVC application with some submission form.

# Build the solution
## Please execute in order!
  - Remove the packages from the csproj file.
  - Add the necessary entity packages (see cheat sheet)
  - Remove the **obj** folder if you have one.
  - Build the solution with **dotnet build**
  - Remove any previous models in Library/Models
  - Scaffold the models with the **force** and **no build** flag
    - **Change the connection** string of scaffold command.
    -   ```> dotnet ef dbcontext scaffold "Data Source=639GTQ2\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Library/Models -f --no-build```
  - Use the proper NortwindContext object in the service classes.
  - Execute with dotnet run
  - surf to https://localhost:5001