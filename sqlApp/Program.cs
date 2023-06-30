using sqlApp.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Endpoint=https://appconfigurationjz.azconfig.io;Id=e7KP;Secret=PcO2s2imqV5cy8HnbHkZ0M4JCPkCfjWY+E4cTUp+PJc=";
builder.Host.ConfigureAppConfiguration(app =>
 app.AddAzureAppConfiguration(connectionString));

builder.Services.AddTransient<IProductService, ProductService>();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
