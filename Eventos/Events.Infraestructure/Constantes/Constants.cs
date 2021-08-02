using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Events.Infraestructure.Constants
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public static List<string> Regions = new List<string> {"sudeste", "sul", "norte", "nordeste","centro-oeste"};
        
        public static List<string> Sensor = new List<string> {"sensor1", "sensor2"};
       
    }
}