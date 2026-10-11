using System.Globalization;
using Tienda_WEB.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Aplica a cada petición el idioma guardado en la cookie, para que
// Recursos\Textos devuelva los textos en ese idioma.
app.Use(async (context, next) =>
{
    var idioma = IdiomaController.NormalizarIdioma(context.Request.Cookies[IdiomaController.CookieIdioma]);

    CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(idioma);

    await next();
});

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
