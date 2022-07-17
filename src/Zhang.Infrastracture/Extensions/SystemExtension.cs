namespace System;

public static class SystemExtension
{
    /// <summary>
    /// 随机(保留三位小数)
    /// </summary>
    /// <param name="random"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static double NextDouble(this Random random, int time)
    {
        return Math.Round(random.Next(time, time * 3) + random.NextDouble(), 3);
    }
}
