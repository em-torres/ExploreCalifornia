# Project Notes
---------------------

## Chapter 1: The Basics
#### Module 4:
* Installation of `Microsoft.AspNetCore.StaticFiles` through the **NuGet Package Manager** to manage Static Files on the project.
* I can use `Ctrl + .` to install from the context menu when the IDE recognizes the package I'm trying to install.

#### Module 5:
* Adding the Static Files to the `wwwroot` folder of the application.
* Serving the Static Files with the `app.UseFileServer()` call from the `Microsoft.AspNetCore.StaticFiles` Middleware.

#### Module 6:
* Implementing and Understanding Error Handlers for Development and Production Envs.
* Using the `app.UseExceptionHandler()` to set a Production Custom Error Page.

#### Module 7:
* Working on custom Configuration.
* Installation of Configuration Package and creating the instance.
* Adding the environment variables dictionary with the configuration setting `new ConfigurationBuilder().AddEnvironmentVariables().Build();`.
* Adding Environment Variables through the App Properties.

#### Module 8:
* Adding Json File to the configuration variables with `.AddJsonFile(file_location)`. For Example:
```
var configuration = new ConfigurationBuilder()
							.AddEnvironmentVariables()
							.AddJsonFile(env.ContentRootPath + "/config.json")
							.Build();
```
* Learning how to use the Debugger
* The second parameter in the `.AddJsonFile()` method allows the Configuration instance to look for a file and if doesn't exists it continues running the program.

#### Module 9:
* Creating a `FeatureToggles` Class to decouple the environments from the configuration setting to prevent injection.
* Defining the Injection Options in the `ConfigureServices` method adding a **Transient** (creating an instance every time is requested).
* In ASP.NET MVC we use the **Scoped** (a single instance for each scope).
* The **Singleton** creates a single instance for the entire application.
* We created a **Startup** Method which creates the new custom configurations instance for the app on startup for dependency injection.

---------------------
## Chapter 2: The MVC Pattern
