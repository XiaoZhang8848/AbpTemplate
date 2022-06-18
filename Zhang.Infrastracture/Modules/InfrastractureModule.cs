using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;
using Zhang.Domain.Modules;

namespace Zhang.Infrastracture.Modules;

[DependsOn(
    typeof(AbpEntityFrameworkCoreMySQLModule)
)]
[DependsOn(
    typeof(DomainModule)
)]
public class InfrastractureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;
        services.AddAbpDbContext<MyDbContext>(opts => opts.AddDefaultRepositories(includeAllEntities: true));

        Configure<AbpDbContextOptions>(opts =>
        {
            opts.Configure<MyDbContext>(x => x.UseMySQL());
        });
    }
}