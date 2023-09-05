using System.Configuration;

namespace wsSanMartin.Data
{
    public class Conection
    {
        public static string connection = ConfigurationManager.AppSettings["conection"];
    }
}