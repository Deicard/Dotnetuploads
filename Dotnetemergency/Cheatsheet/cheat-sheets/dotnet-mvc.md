# MVC

# Controllers

```csharp
// - PLEASE GENERATE controllers with the proper command (see dotnet-commands.md).
// - Views return a IActionResult type.
// - The Action must equal the view name.
namespace northwind_app.Controllers
{
    [Route("")] // Make an action or controller default..
    [Route("[controller]")] // The route contains the controller name.
    public class OverviewController : Controller // Extends Controller
    {
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();
        
        [Route("")] // Default action
        [Route("[action]")] // The route contains the action name.
        public IActionResult Index()
        {
            // Passing data to the view.
            return View(categoryService.AllCategories());
        }

        [Route("Categories/{categoryId}/Products")] // Path parameters in {}.
        // Path parameters and actions parameters have the same name.
        public IActionResult GetProductsByCategoryId(int categoryId) {
            return View(productService.GetProductsByCategoryId(categoryId));
        }

        // Create a route with a different name than the action.
        [Route("Products")]
        // By default action parameters are query parameters.
        // Action parameter name =  query parameter name.
        public List<Products> GetProducts(int bottomPrice) {
            // Objects are automatically converted to their json representation.
            return productService
                .AllProducts()
                .Where(p => p.UnitPrice >= bottomPrice)
                .ToList();
        }
    }
}
```

# Views
```csharp
// Views are .cshtml files
// A mix of HTML and dotnet razor syntax.
// Views belong in a folder with the same name as the controller name.

// Razor syntax always starts with a @.

// Import the type which you want to use in this view.
// Mind the small letter m

@model northwind_app.Library.ViewModels.CategoriesVM>

<h1>Overview</h1>
<table class="table">
    <thead>
        <tr>
            // A html helper to display the property of an object.
            // E.g. in this case it will display CategoryName.
            <th>@Html.DisplayNameFor(Model => Model.CategoryName)</th>
            <th>@Html.DisplayNameFor(Model => Model.Description)</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
// The data that is passed with the View(object) function in the controller
// is available through the Model variable.
// Each view has a Model (capital M) variable.

// Iterate through all item of Model (IEnumerable<northwind_app.Library.Models.Categories>)
// Each category is available in the variable item (name of item does not matter).
@foreach (var item in Model.Categories) {
        <tr>
            // Access the property CategoryName of the Category object.
            <td>@item.CategoryName</td>
            <td>@item.Description</td>
            <td>
                // Annotate the html link tag with tag helpers.
                // Link to a controller / action passing a path parameter ID
                // See route at the top of this page.
                <a  asp-controller="Overview" 
                    asp-action="GetProductsByCategoryId" 
                    asp-route-categoryId="@item.CategoryId">
                    Products
                </a>
            </td>
        </tr>
}
    </tbody>
</table>
```
# Form
### The view
```csharp
 <form 
    asp-controller="Overview"  // Link to the controller.
    asp-action="SaveProduct"  // Link to the action of that controller;
    method="Post">
    // When extra errors are set (ModelState.AddError) use a asp-validation-summary.
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>
    <div class="form-group">
        // asp-for === html for attribute
        <label asp-for="Name" class="control-label"></label>
        // Make sure the name of the input field matches the property of the viewmodel (see controller).
        <input asp-for="Name" class="form-control" />
        // If the validation fails on the the property show a span with what is wrong.
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Price" class="control-label"></label>
        <input asp-for="Price" class="form-control" />
        <span asp-validation-for="Price" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="CategoryId" class="control-label"></label>
        <input asp-for="CategoryId" class="form-control" />
        <span asp-validation-for="CategoryId" class="text-danger"></span>
    </div>
    <div class="form-group">
        <input type="submit" value="Save" class="btn btn-primary" />
    </div>
</form>
```
### The ViewModel
```csharp
// In the model the validation rules are defined.
    public class ProductViewModel {
        [Required]
        [Range(typeof(float), "1", "1000")]
        public float? Price {get; set;}

        [Required]
        [MinLength(3), MaxLength(50)]
        public string Name {get; set;}

        [Required]
        public short CategoryId {get; set;}
    }
```
### The Controller
```csharp
    [HttpPost] // HttpPost attribute is required because HttpGet is default.
    [ValidateAntiForgeryToken] // Prevent csrf
    [Route("[action]")]
    // If the name of the input fields match the property names then the object will be auto filled.
    public IActionResult SaveProduct(ProductViewModel product)
    {
        // ModelState is always available to check if there are any validation exceptions.
        if (ModelState.IsValid)
        {
            productService.Add(product.Name, product.Price, product.CategoryId);
            // Redirecting is also possible instead of returning a view (same return type).
            return RedirectToAction("GetProductsByCategoryId",
                "Overview",
                new { CategoryId = product.CategoryId });
        }

        // Add custom errors that will be displayed in a html element with an asp-validation-summary tag helper.
        ModelState.AddModelError("", "Please fill in all required fields.");
        return View("CreateProduct", product);
    }
```
# Sessions

### Startup.cs file
```csharp
// Enable sessions in the startup.cs file Configure method.
app.UseSession();

// Configure sessions in the startup.cs ConfigureServices method.
services.AddDistributedMemoryCache();
    services.AddSession(options => {
        options.Cookie.Name = ".Northwind.Session";
        options.Cookie.IsEssential = true;
});
```
### Controller
```csharp
// Needed to use the session store.
using Microsoft.AspNetCore.Http;
// Needed to use Json.
using System.Text.Json;

// Create some helper functions
private List<string> StoreSearchQuery(string query) {
    // Add the search string to the session state to remember it.
    List<string> previousQueries = GetPreviousQueries();

    if (!previousQueries.Contains(query)) {
        previousQueries.Add(query);
    }

    // Overwrite the current searchQueries with the new results.
    HttpContext.Session.SetString("searchQueries", JsonSerializer.Serialize(previousQueries));

    return previousQueries;
}

private List<String> GetPreviousQueries(){
    // Get the raw json from the session store.
    string previousQueriesJson = HttpContext.Session.GetString("searchQueries");
    List<string> previousQueries = new List<string>();

    if (!string.IsNullOrEmpty(previousQueriesJson)) {
        // When the searchQueries key is available deserialize into a list of strings.
        previousQueries = JsonSerializer.Deserialize<List<string>>(previousQueriesJson);
    }

    return previousQueries;
}
```

