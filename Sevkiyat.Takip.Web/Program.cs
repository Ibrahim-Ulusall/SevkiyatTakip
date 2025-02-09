using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Sevkiyat.Takip.Core.Extensions;
using Sevkiyat.Takip.Core.Models.Settings.Sessions;
using Sevkiyat.Takip.Persistance.Extensions;
using Sevkiyat.Takip.Application.Extensions;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Sevkiyat.Takip.Core.Utilities.Interceptors;
using Sevkiyat.Takip.Persistance.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCoreLayerDependencyResolvers();

builder.Services.AddApplicationLayerDependencyResolvers();

builder.Services.AddPersistanceLayerDependencyResolvers(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSession(options =>
{
    SessionSettings sessionSettings = builder.Configuration.GetSection("SessionSettings").Get<SessionSettings>()
                                     ?? throw new ArgumentNullException($"{nameof(SessionSettings)} not found");

    options.IdleTimeout = TimeSpan.FromDays(sessionSettings.IdleTimeout);
    options.Cookie.Name = sessionSettings.CookieName ?? ".sevkiyat.Session";
    options.Cookie.IsEssential = sessionSettings.IsEssential;
});

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

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new PersistanceAutofacModule());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseCustomExceptionMiddleware();

app.UseCors("SevkiyatCors");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();

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
