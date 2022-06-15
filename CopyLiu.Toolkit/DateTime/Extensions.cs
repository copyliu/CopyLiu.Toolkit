using System;

namespace CopyLiu.Toolkit.DateTime
{
    public static class Extensions
    {
        /// <summary>
        ///     取整时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="roundTicks">如 TimeSpan.TicksPerDay</param>
        /// <returns></returns>
        public static System.DateTime Trim(this System.DateTime date, long roundTicks)
        {
            return date.AddTicks(-date.Ticks % roundTicks);
        }

        /// <summary>
        ///     取整时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="roundTicks">如 TimeSpan.TicksPerDay</param>
        /// <returns></returns>
        public static DateTimeOffset Trim(this DateTimeOffset date, long roundTicks)
        {
            return date.AddTicks(-date.Ticks % roundTicks);
        }
    }
}