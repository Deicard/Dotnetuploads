# dotnet commands
## Creating projects
*Creates a new project, configuration file, or solution based on the specified template.*
- ```> dotnet new console ```
- ```> dotnet new console -o <foldername>```
- ```> dotnet new console --help ```
- ```> dotnet new classlib -o name-of-classlib```
- ```> dotnet new mvc ```
- ```> dotnet new sln ```

## package and version info
- ```> dotnet --info ```
- ```> dotnet --version```

## Running and building
*Runs source code without any explicit compile or launch commands.*

*The run command runs **dotnet build** first.*
- ```> dotnet build ``` Build the source.
- ```> dotnet run ```
- ```> dotnet run -- <argument(s) space-delimited>```

## Libraries
*Build and import libraries.*

*Execute these commands from the root of the project.*
- ```> dotnet pack ``` Pack the current source files into a **nupkg** file.
- ```> dotnet add package package_id``` Import the library defined in the cproj file.

*The project that wants to import a package must add a reference to the source in the csproj file*
```xml
 <RestoreSources>$(RestoreSources);/home/matthias/Documents/modules/dotnet/traceroute-lib/bin/Debug;https://api.nuget.org/v3/index.json</RestoreSources>
 ```

*Add the following properties in the csproj file in the projectGroup*
 ```xml
 <PackageId>lab-traceroute-lib</PackageId>
 <Version>1.2.1</Version>
 <Authors>Matthias Blomme</Authors>
 ```

## Entity Framework
*Scaffold existing or new databases.*
-  Check if the entity framework cli is available.
    - ```> dotnet ef``` Should not give the error command not found.
    - ```> dotnet tool install --global dotnet-ef``` Install the entitfy framework cli.

- SqlExpress: scaffold an existing database
  -  ```> dotnet ef dbcontext scaffold "Data Source=639GTQ2\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Library\Models```

- Postgres: scaffold an existing database
  - ```> dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Database=northwindDB;Username=username;Password=password" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Library\Models```

- Force regeneration of models & context: add the flags: **--no-build -f**
  - **-f** allows override of existing models
  - **--no-build** allows model generation without building or running the project first.
  - example:
  -  ```> dotnet ef dbcontext scaffold "Data Source=639GTQ2\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Library\Models```
  - **-t** choose the tables you want to scaffold
  - example:
  - ```> dotnet ef dbcontext scaffold "Host=localhost;Port=54320;Database=de_mol;Username=homestead;Password=secret" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Library\Models -t "app_players" -t "app_votes"```

*new project with entity framework*

- ```> dotnet new <app-type>```
- ```> dotnet add package Microsoft.EntityFrameworkCore.SqlServer```
- ```> dotnet add package Microsoft.EntityFrameworkCore.Design```
- ```> dotnet ef dbcontext scaffold "Data Source=639GTQ2\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Library/Models```

*new project with entity framework in PostgreSQL*

- ```> dotnet new <app-type>```
- ```> dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design```
- ```> dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL```
- ```> dotnet add package Microsoft.EntityFrameworkCore.Design```
- ```> dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Database=northwindDB;Username=username;Password=password" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Library\Models```

## MVC
- ```> dotnet new mvc -o outputFolderName```
- ```> dotnet new mvc``` Turn existing folder into a mvc project

*To easily create controllers and views add the following package*
- ```> dotnet tool install --global dotnet-aspnet-codegenerator```
- ```> dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design```
 
*Create a controller*
- ```> dotnet aspnet-codegenerator controller -name SomeController -outDir Controllers```// execute at project root (controller name must include Controller)

*Create a view*
- ```> dotnet aspnet-codegenerator view GetProductsByCategoryId Empty -outDir Views/Overview```// execute at project root

