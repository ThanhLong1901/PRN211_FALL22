using SE1634_Group5_A3.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();



//===============Code Th�m===============
builder.Services.AddDbContext<MusicStoreContext>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
//=======================================



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



//===============Code Th�m===============
app.UseSession();
//=======================================



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
