# BlazeDapper

Welcome to BlazeDapper. A .net 7 [blazor-server](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-7.0) app that consists of a generic **datatable component** (providing sorting, paging and filtering) and a **dynamic sql query builder** for data access via the [Dapper ORM](https://www.learndapper.com/).

The solution was created to provide a read only data portal to view and query multiple recordsets. It relies heavily on generics and refelction as you will see. I'm aware there are several datatable components and dapper nuget packages available, but none provided the flexibility and/or features i needed for the project.

This code base is very minimal in features as it's purpose is to demonstrate the datatable component and the query builder. A lot of standard multistack-code ceremony has been discarded (entity mapping, unit tests, etc etc) to allow focus on just these 2 features so bear that in mind when viewing the code. That being said, all **CONSTRUCTIVE** feedback is welcome.

The code is presented as is. I may make code changes periodically based on feedback, purely for educational (mine and hopefuly others) purposes. To this end, i welcome contributions/discussions to the code that improves code quality without changing it's primary directive.

The structure of the code is very basic and consists of the following projects:

* **Web** standard BlazorServer project
* **Components** Razor library with generic datatable component and it's child components
* **Models** Class library containing entities, utility and transport classes
* **DAL** Class library housing data access to SQL server via dapper. Also includes the Querygenerator

Setup:
1. Pull/fork the repo
2. Run the scripts in the BlazeDapper.DAL\DBSetup folder to setup your db
3. Update the connection string in BlazeDapper.Web\appsettings.json
4. Update BlazeDapper.DAL\SQLConstants to match your database name (I might move this to appsetting.json...maybe)
4. Put a breakpoint somewhere (BlazeDapper.COMPONENTS\PagedDataSet\OnInitializedAsync would be a good shout) and lets see what we can learn/improve on with this code.

If you find this solution of use, please consider [buying me a coffee](https://www.buymeacoffee.com/iKnowNothing) or better yet, [hire me](https://www.linkedin.com/in/david-apomah-87043025/ "David Apomah on LinkedIn") for any full stack **Microsoft** cloud projects you may have coming up.

Thanks for getting involved.

Catch you on code mountain :)

credits:
DotFactory for the sample data: https://www.dofactory.com/sql/sample-database
