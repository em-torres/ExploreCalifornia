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
* A **Razor** file is an ASP.NET programming syntax used to create dynamic web pages with C# or VB.NET. It's characterized by the `.cshtml` or `.vbhtml` extensions files (A mix of HTML and C# or Visual Basic).
* Thew `View()` method in the controllers allow ASP.NET to render an HTML file in the browser.
* It looks in the **/Views/[controller_name]** or **/Vies/Shared** folders for a `.cshtml` file with the name of the method in the controller.
* We created a Home inside a Views folder, sent the `index.html` file and changed its name to `index.cshtml`.
* `.cshtml` extension belongs to HTML files with C# code on it.

#### Module 2:
* To add a code in **Razor** Syntax just add the `@` symbol followed by the language code (C# or VB) you want to add.
* We added the actual year to the index.
* The real power of **Razor** lies in the HTML Helpers (we can make entire sections of dynamic HTML with a single method call).
* The `@Html.ActionLink` helper will be the most used to generate anchortypes based on the controller and action name. It receives 3 parameters: _the text to show in the link_, _the name of the action to be linked_ and the third one is the _name of the controller_.
* The `ActionLink` helper has another overload that accepts 2 parameters: _a route data object_ and an _html attribute object_.
* The `@Url.Action` helper unlike the `Action Link` method, only renders the value of the URL itself and no additional HTML.

#### Module 3:
* We created a **Shared** folder on the Views and added a `_Layout.cshtml` file on it.
* We replaced the `mainContent` HTML with the `@RenderBody()` helper.
* Changed the Home View **index** to use the **_Layout** with the content using the `@{ layout = ""; }` helper.
* Created the Blog Index View with the previous layout.
* We can also add sections with the `@RenderSection()` helper which requires a paramater: the name of the section. Now, in the views that needs the section, I can call them using the `@section name_of_section { }` helper.
* `@RenderSection()` accepts a second parameter which tells ASP if the section is needed or not.
* We can also set a preset section and call it whenever is needed using the `@if` helper and the `IsSectionDefined()` method.

#### Module 4:
* The `ViewBag` property which is a dynamic object that is accesible in the Controller and the View.
* Is a must to type Strongly Type Data in the models from the controllers to the view in order to get full intellisense and time checking.

#### Module 5:
* The `ViewBag` property is a convenient way to pass data but its dynamic method is not the best approach. We will se another approach to pass strongly typed models from the controller to the view.
* We first need to create a type that will be used as our model. We created the Models folder and a **Post** Model class and added the Title, Posted, Author and Body properties with its own type.
* Then, we changed the Blog Controller to create an instance of the Post Model and save the data on its properties and send it to the View as a parameter of the `View()` method in the controller.
* With the `@model ProjectName.Models.NameOfModel` helper in the View we tell the view to use the specified model as default and now we have full Intellisense of the values with the `@Model.Parameter`

#### Module 6:
* Reusing Sections of Razor Markup for multiple views with the **Partial View Technique**.
* We created a partial view in the **Shared** views folder called `_Post.cshtml` and in the View **Post.cshtml** file we called it with the `@Html.partial("")` helper and the name of the partial view.
* In the `Index.cshtml` view of the Blog section we added a `@model` helper with the `IEnumerable<>` type refering to the Post Models since we are going to receive a collection of models from the controller.
* We added a `@foreach` loop through the **IEnumerable Model** constructor with the name **post** and send each one as a second parameter of the `@Html.Partial()` helper in order to render each post coming from the controller.
* We created dummy data on the **Index** method of the **Blog** controller to simulate several posts.

#### Module 7:
* ASP allows us to create Formatting presets for the views and reuse the view logic with injectable services.
* We added a new class to the models called **FormattingService** and added the method `AsReadableDate` which will receive a date as parameter to return it formatted with the `ToString()` method.
* Added the `@inject` helper in the View which accepts 2 parameters: the type to be injected (in this case the Model **FormattingService** that we created) and the name of the property that we want MVC to create for us dynamically (in this case **Format**).
* We added the `@Format.AsReadableDate()` helper and added the `Model.Posted` parameter.
* In order for the View to recognize the Format we added, we need to register it in the **Startup** Class as a Transient in the `ConfigureServices` method.

#### Module 8:
* We are going to use **ViewComponents** in order to separate the _Monthly Specials_ section of the webpage and render it separately.
* We created a folder called **ViewComponents** and added a `MonthlySpecialsViewComponent.cs` file where we are going to add the logic of this component.
* Although MVC doesn't care how you name your folder or files for a component, it requires at least 1 of the following things to recognize a class as a ViewComponent: a) The end of the class must end with **ViewComponent**; b) The class must be decorated with the ViewComponent attribute (ex. `[ViewComponent]`) or c) The class can extend from the ViewComponent base class.
* When the component is invoked, MVC will look for a public method in the components class named **Invoke** that will accept the same number of parameters as the component invoked with and return an instance of `IViewComponentResult`.
* We setted a `View()` method in the Invoke public method in the **MonthlySpecialsViewComponent** class.
* On the `_Layout.cshtml` view we changed the section to be rendered with the `@await` helper followed by the generic reference of the `Component.InvokeAsync` method wrapped in parenthesis to not confuse Razor with it (ex. `@await (Component.InvokeAsync<ExploreCalifornia.ViewComponents.MonthlySpecialsViewComponent>())`).
* ASP MVC look for ViewComponents in a different way as Views. It looks for them on the **Components/ViewComponent** folder inside the _Controller_ or the _Shared_ folders views (ex. `Views/ControllerView/Components/MonthlySpecials/Default.cshtml`).

#### Module 9:
* The forte of ViewComponents comes when they can retrieve their own data without Views or Controller knowing where is it coming from.
* We are going to create a class for the ViewComponent to retrieve the MonthlySpecials data.
* We used the built-in dependency injection `SpecialsDataContext` to inject it into the component of the View Constructor and added it in the startup for this injection to work.
* Added the Model data in the `MonthlySpecialsViewComponent`.

#### Challenge:
* Created new `_SimpleLayout.cshtml` file in the Shared folder with a section and rendering the previous layout.
* Modified the layouts using the `_Layout.cshtml` file to use the `_SimpleLayout.cshtml`.
* Set a condition on the `_Layout.cshtml` if the section **secondaryContent** is available, to render that section; else, to render the left side template (with the monthly specials).
