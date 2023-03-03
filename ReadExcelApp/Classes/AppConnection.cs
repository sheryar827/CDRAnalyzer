 using System.Configuration;

namespace ReadExcelApp.Classes
{
    public class AppConnection
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["cdr"].ConnectionString;
        }

        public static string GetSubConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["sub"].ConnectionString;
        }

        public static string GetDLMSConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["dlms"].ConnectionString;
        }
    }
}
