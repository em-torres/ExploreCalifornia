# Project Notes
---------------------

## Chapter 1:
#### Module 4:
* Installation of `Microsoft.AspNetCore.StaticFiles` through the **NuGet Package Manager** to manage Static Files on the project.
* I can use `Ctrl + .` to install from the context menu when the IDE recognizes the package I'm trying to install.

#### Module 5:
* Adding the Static Files to the `wwwroot` folder of the application.
* Serving the Static Files with the `app.UseFileServer()` call from the `Microsoft.AspNetCore.StaticFiles` Middleware.

#### Module 6:
* Implementing and Understanding Error Handlers for Development and Production Envs.
* Using the `app.UseExceptionHandler()` to set a Production Custom Error Page.
