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
#### Module 1:
* Introduction to MVC (Model-View-Controller) pattern
* Introduction ASP.NET MVC Framework

#### Module 2:
* Using the `UseMvc()` method to install the MVC package on the application.
* Inserting the routing as second parameter of the `UseMvc()` method.
* Adding the `UseMVC()` method to the `ConfigureServices` method.

#### Module 3:
* Handling Requests with Controllers and separate them in their own folder.
* Added new MVC Controller Class to the Controllers folder.
* In ASP Controllers are containers for actions since every method in the controller class is an action.
* Controllers classes not necessarily need to derive from the Controller class.
* On the Controllers classes we will be returning `Action Results Objects`.
* We can also send `Content Results` to the controller.

#### Module 4:
* Controller Actions are just methods and we can pass data through paramaters on the method.
* The parameter `id` in the `Post` method of the **Blog Controller** is linked to the `routes -> Default -> {id?}` parameter we defined in the `Configure Method`.
* We learnt to catch the value on the router to the Controller.
* We can use a query string (`?id=`) to achieve the same result. This feature is called **Model Binding** and can be used to populate entire objects.

#### Module 5:
* We can register as many routes as we want.
* We added the type to the Blogs Route expecting a value.

#### Module 6:
* Cuztomizing application's URL's
* Implementing Global Routes and Routing approach

---------------------
## Chapter 3: Render HTML with Views
#### Module 1:

