using Business.Containers;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().AddFluentValidation();
builder.Services.MyServiceInstance();

builder.Services.AddAuthentication("Cookies").AddCookie(x =>
{
    x.LoginPath = "/admin/Giris";// Giriþ yapýlan sayfalara grirldiðinde yönlendirilecek olan sayfa
    x.LogoutPath = "/admin/Cikis";//Çýkýþ yapýlmasýný saðlayan sayfa
    x.AccessDeniedPath = "/admin/Giris"; // YEtkissiz Giril Yapýldýðý zaman Yönlendirilecek sayfa

});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(x =>
{
    x.MapDefaultControllerRoute();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Giris}/{action=Index}/{id?}"
    );
});

app.Run();