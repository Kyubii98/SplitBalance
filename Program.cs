using Balance;
using Balance.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Supabase;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

var supabaseUrl = builder.Configuration["Supabase:Url"];
var supabaseKey = builder.Configuration["Supabase:Key"];

builder.Services.AddSingleton<SupabaseSessionHandler>();

builder.Services.AddSingleton<Supabase.Client>(sp =>
{
    var sessionHandler = sp.GetRequiredService<SupabaseSessionHandler>();

    var options = new SupabaseOptions
    {
        AutoConnectRealtime = true,
        AutoRefreshToken = true,
        SessionHandler = sessionHandler
    };

    return new Supabase.Client(
        supabaseUrl!,
        supabaseKey!,
        options
    );
});

builder.Services.AddSingleton<ExpenseService>();

var app = builder.Build();

var supabase = app.Services.GetRequiredService<Supabase.Client>();

await supabase.InitializeAsync();

supabase.Auth.LoadSession();

await app.RunAsync();