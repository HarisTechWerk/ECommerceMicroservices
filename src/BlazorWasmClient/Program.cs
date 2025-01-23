using Blazored.LocalStorage;
using BlazorWasmClient;
using BlazorWasmClient.Auth;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 1. UserService HttpClient
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5003") // Replace with your actual UserService URL
});
//.WithName("UserServiceClient");

// 2. ProductService HttpClient
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5003") // Replace with your actual ProductService URL
});
//.WithName("ProductServiceClient");

// 3. Add custom AuthenticationStateProvider
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>(
    provider => provider.GetRequiredService<CustomAuthStateProvider>()
);

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
