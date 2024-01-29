using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using WebFront.ConfigModels;
using WebFront.Interfaces;
using WebFront.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Scoped services (One instance per scope, e.g., per request)
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICookieService, CookieService>();
builder.Services.AddScoped<IMongoDBService, MongoDBService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IMatchMakingServices, MatchMakingServices>();

// SignalR (Hub instances managed by SignalR)
builder.Services.AddSignalR();

// Transient services (A new instance every time it's requested)
// AddControllersWithViews internally registers controllers as transient
builder.Services.AddControllersWithViews();

// Registration of configuration sections
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.Configure<LogonServerSettings>(builder.Configuration.GetSection("LogonServerSettings"));
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
//builder.Services.AddDataProtection()
//  .SetApplicationName("ChessGame")
//  .PersistKeysToFileSystem(new DirectoryInfo(@"C:\temp-keys\"))
//  .ProtectKeysWithDpapi();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.HttpOnly = HttpOnlyPolicy.None; // Adjust based on your security requirements
    options.Secure = CookieSecurePolicy.None; // Adjust based on your security requirements
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // Map SignalR hub
    endpoints.MapHub<GameHub>("/gameHub");
    endpoints.MapFallbackToFile("index.html");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Lobby}/{action=Index}/{id?}");

app.Run();
