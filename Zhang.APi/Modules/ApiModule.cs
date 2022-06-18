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
    typeof(SwaggerModule)
)]
public class ApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;
        services.AddControllers();
        services.AddEndpointsApiExplorer();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = (WebApplication)context.GetApplicationBuilder();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}