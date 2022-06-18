using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Zhang.APi.Modules;

public class SwaggerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;
        services.AddSwaggerGen(opts =>
        {
            // 添加安全定义
            opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "格式: Bearer {token}",
                Name = "Authorization",             // 默认参数名
                In = ParameterLocation.Header,      // 默认放在请求头中
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            // 添加安全要求
            opts.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}