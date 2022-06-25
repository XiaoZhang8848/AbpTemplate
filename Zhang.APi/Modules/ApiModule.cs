using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Zhang.Application.Modules;
using Zhang.Infrastracture.Modules;

namespace Zhang.APi.Modules;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule)
)]
[DependsOn(
    typeof(ApplicationModule),
    typeof(InfrastractureModule)
)]
[DependsOn(
    typeof(SwaggerModule),
    typeof(JwtModule),
    typeof(LogModule)
)]
public class ApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;

        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddCors(opts => opts.AddPolicy("any", x =>
            x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
        ));

        services.AddMemoryCache();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = (WebApplication)context.GetApplicationBuilder();

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseCors("any");

        app.MapControllers();

        app.Run();
    }
}