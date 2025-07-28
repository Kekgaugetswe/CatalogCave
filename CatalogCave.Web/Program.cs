using CatalogCave.Web.Domain.Products;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient<IProductApiService, ProductApiService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddRazorPages();




   //acountfilow
var app = builder.Build();

// Enable session middleware

// Enable routing
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
 
if (app.Environment.IsDevelopment())
{

    app.UseDeveloperExceptionPage();
}
//ability to navigate through the pages
app.MapDefaultControllerRoute();

app.Run();
