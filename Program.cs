using game_collection.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register Identity Services
// Inject classes IdentityUser and Identity Role
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => 
{
    // Configure username requirements
    options.User.RequireUniqueEmail = true;
    
    // Configure email requirements
    options.User.RequireUniqueEmail = true;
    
    // Configure Password requirements
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;    

    // Lockout requirements
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 3;
})
// Connect ApplicationDbContext to identity service
.AddEntityFrameworkStores<ApplicationDbContext>();

// Setting up Cookie authentication
builder.Services.ConfigureApplicationCookie(options => 
{
    // Configure the behaviour of the cookie
    options.Cookie.Name = "WebAppIdentityt";
    options.LoginPath = "/Account/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
