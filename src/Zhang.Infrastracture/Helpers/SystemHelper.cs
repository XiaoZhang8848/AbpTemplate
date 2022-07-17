namespace System;

public class SystemHelper
{
    /// <summary>
    /// 是否开发环境
    /// </summary>
    public static bool IsDevelopment()
    {
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    }
}
