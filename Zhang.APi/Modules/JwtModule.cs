using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Volo.Abp.Modularity;
using Zhang.APi.Options;

namespace Zhang.APi.Modules;

public class JwtModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;
        var config = services.GetConfiguration();

        Configure<JwtOption>(config.GetSection("Jwt"));
        var jwtOption = config.GetSection("Jwt").Get<JwtOption>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
        {
            // 地址是否为https 开发环境false,生产环境true
            opts.RequireHttpsMetadata = false;

            // 授权后是否存储令牌
            opts.SaveToken = true;
            opts.TokenValidationParameters = new()
            {
                ClockSkew = TimeSpan.Zero, // 缓冲时间
                ValidIssuer = jwtOption.Issuer,
                ValidAudience = jwtOption.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.Key))
            };

            // 鉴权失败触发
            opts.Events = new JwtBearerEvents
            {
                OnChallenge = x =>
                {
                    // 停止响应 此处终止代码
                    x.HandleResponse();
                    var res = "{\"code\":401,\"error\":\"无权限\"}";
                    x.Response.ContentType = "application/json";
                    x.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    x.Response.WriteAsync(res);
                    return Task.FromResult(0);
                }
            };
        });
    }
}