using Business.Containers;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().AddFluentValidation();
builder.Services.MyServiceInstance();

builder.Services.AddAuthentication("Cookies").AddCookie(x =>
{
    x.LoginPath = "/admin/Giris";// Giri� yap�lan sayfalara grirldi�inde y�nlendirilecek olan sayfa
    x.LogoutPath = "/admin/Cikis";//��k�� yap�lmas�n� sa�layan sayfa
    x.AccessDeniedPath = "/admin/Giris"; // YEtkissiz Giril Yap�ld��� zaman Y�nlendirilecek sayfa

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