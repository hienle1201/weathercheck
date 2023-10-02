using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.Domain.Options
{
    public class ApplicationOptions
    {
        public DataProvider WeatherProvider { get; set; }
    }

    public class DataProvider
    {
        public string Url { get; set; }
        public string AccessKey { get; set; }
        public int Timeout { get; set; }
    }
}
