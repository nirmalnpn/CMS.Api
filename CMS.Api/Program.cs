using CMS.Api.Controllers.Comman;
using Microsoft.Extensions.Options;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add controllers with XML formatter support
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
})
.AddXmlDataContractSerializerFormatters();

// Configure Swagger and API explorer
builder.Services.AddEndpointsApiExplorer();


// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .WithExposedHeaders("Content-Disposition");
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAnyOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
