using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Taller/Login";
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=taller_eva3;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

void InitializeDatabase()
{
    using SqlConnection connection = new(_connectionString);
    string query = "IF OBJECT_ID('dbo.danielTorrealba_PERFILES', 'U') IS NULL BEGIN CREATE TABLE danielTorrealba_PERFILES ( Rut NVARCHAR(10) NOT NULL PRIMARY KEY, Nombre NVARCHAR(30) NOT NULL, ApPat NVARCHAR(30) NOT NULL, ApMat NVARCHAR(30) NOT NULL, Edad INT NOT NULL, Clave NVARCHAR(250) NOT NULL, Nivel INT NOT NULL CHECK (Nivel IN (1, 2))); INSERT INTO danielTorrealba_PERFILES (Rut, Nombre, ApPat, ApMat, Edad, Clave, Nivel) VALUES ('11111111-1','LUIS','YAÑEZ','CARREÑO',49,CONCAT(LEFT('LUIS', 1), LEFT('YAÑEZ', 1), LEFT('CARREÑO', 1), '11111111-1'),1); END ELSE BEGIN PRINT 'La tabla danielTorrealba_PERFILES ya existe.'; END IF OBJECT_ID('dbo.danielTorrealba_FRASES', 'U') IS NULL BEGIN CREATE TABLE danielTorrealba_FRASES (id INT IDENTITY(1,1) PRIMARY KEY,frase NVARCHAR(MAX) NOT NULL); INSERT INTO danielTorrealba_FRASES (frase) VALUES ('Primero resuelve el problema, despues escribve el codigo.'),('Siempre hay más de una forma de resolver un problema.'),('Algoritmo: Palabra que usan los programadores cuando no quieren explicar lo que hicieron.'),('Un código limpio es un código mantenible.'), ('Hablar no es suficiente, muestrame el codigo.'); END ELSE BEGIN PRINT 'La tabla danielTorrealba_FRASES ya existe.';END";
    SqlCommand command = new(query, connection);

    try
    {
        connection.Open();
        command.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

InitializeDatabase();

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
