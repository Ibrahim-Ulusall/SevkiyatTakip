using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Sevkiyat.Takip.Core.Models.Settings.Sessions;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;
using Sevkiyat.Takip.Persistance.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddPersistanceDependencyInjection(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSession(options =>
{
    SessionSettings sessionSettings = builder.Configuration.GetSection("SessionSettings").Get<SessionSettings>()
                                     ?? throw new ArgumentNullException($"{nameof(SessionSettings)} not found");

    options.IdleTimeout = TimeSpan.FromDays(sessionSettings.IdleTimeout);
    options.Cookie.Name = sessionSettings.CookieName ?? ".sevkiyat.Session";
    options.Cookie.IsEssential = sessionSettings.IsEssential;
});

builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sevkiyat API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Email = "ulusall.ibrahim@gmail.com",
            Name = "Ibrahim ULUSAL",
        }
    });
    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        var actionApiSettings = apiDesc.ActionDescriptor.EndpointMetadata
            .OfType<ApiControllerAttribute>()
            .Any();
        return actionApiSettings;
    });

    c.AddSecurityDefinition("Güvenlik", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        Description = "Bearer kullanarak verilen tokeni girin",
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Name = "Authorization"

    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("SevkiyatCors", policy =>
    {
        policy.WithOrigins("https://localhost:7050",
            "http://localhost:5187", "http://localhost:5187")
               .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("SevkiyatCors");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sevkiyat API V1");
    c.RoutePrefix = "api";
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
