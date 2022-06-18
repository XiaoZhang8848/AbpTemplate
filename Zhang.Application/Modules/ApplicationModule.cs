using Volo.Abp;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Zhang.Domain.Modules;

namespace Zhang.Application.Modules;

[DependsOn(
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
)]
[DependsOn(
    typeof(DomainModule)
)]
public class ApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var serivices = context.Services;
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ApplicationModule>();
        });
    }
}