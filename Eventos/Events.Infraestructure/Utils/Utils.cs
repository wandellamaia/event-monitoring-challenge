using System;
using System.Diagnostics.CodeAnalysis;

namespace Events.Infraestructure.Utils
{
    [ExcludeFromCodeCoverage]
    public class Utils
    {
        public static string GetSensor()
        {
            Random rnd = new Random();
            return Constants.Constants.Sensor[rnd.Next(2)];
        }
        public static long GetTimeStamp()
        {
            long unixTimestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;
        }
        
        public static DateTime GetDate(long timeStamp)
        {
            DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds( timeStamp ).ToLocalTime();
            return dtDateTime;
        }
        
        public static string GetRegion()
        {
            Random rnd = new Random();
            return Constants.Constants.Regions[rnd.Next(5)];
        }


    }
}