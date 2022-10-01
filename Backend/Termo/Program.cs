using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Configuration;
using Termo.Core.Middleware;
using Termo.Core.Repositories.Interfaces;
using Termo.Core.Repositories;
using Termo.Data;
using Termo.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Termo");
builder.Services.AddDbContext<TermoDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IMailSender, MailSender>();
builder.Services.AddTransient<IEmailSender>(e => new EmailSender(builder.Configuration.GetValue<string>("MailSettings:Host"), builder.Configuration.GetValue<int>("MailSettings:Port"), builder.Configuration.GetValue<string>("MailSettings:Mail")));
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var folder = Directory.GetCurrentDirectory();
app.UseStaticFiles(new StaticFileOptions(){
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(),"Email"))
});

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
