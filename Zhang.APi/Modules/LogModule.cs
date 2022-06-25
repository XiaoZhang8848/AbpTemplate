using Serilog;
using Serilog.Events;
using Volo.Abp.Modularity;

namespace Zhang.APi.Modules;

public class LogModule : AbpModule
{
    private string LogFilePath(string level)
    {
        return $"Logs/{DateTime.Today.ToString("yyyy-MM-dd")}/{level}.txt";
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;
        var outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()

            .MinimumLevel.Information() // 最小输出级别

            .MinimumLevel.Override("Default", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)

            .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Information)
                .WriteTo.File(
                    LogFilePath("Information"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: outputTemplate
                )
            )

            .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Warning)
                .WriteTo.File(
                    LogFilePath("Warning"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: outputTemplate
                )
            )

            .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Error)
                .WriteTo.File(
                    LogFilePath("Error"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: outputTemplate
                )
            )

            .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Fatal)
                .WriteTo.File(
                    LogFilePath("Fatal"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: outputTemplate
                )
            )

            .WriteTo.Console() // 输出到控制台
            .CreateLogger();
    }
}