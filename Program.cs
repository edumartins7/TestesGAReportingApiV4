using System;
using System.IO;
using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.AnalyticsReporting.v4.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;

namespace TestesGAReportingApiV4
{
    class Program
    {
        private static string _viewId = "235071939";
        // private static string _caminhoCredenciais = @"C:\credentials\3e74795e54e4.json";
        public static string de = "2020-12-20";
        public static string ate = "2021-01-20";
        public static string _credenciaisJson = File.ReadAllText(@"C:\credentials\3e74795e54e4.json");

        static void Main(string[] args)
        {
            AnalyticsReportingService service = AutenticarComServiceAccount(_credenciaisJson);

            var dateRange = new DateRange() {
                StartDate = "2020-12-20",
                EndDate = "2021-01-20"
            };         

            Console.WriteLine("Hello World!");
        }

        public static AnalyticsReportingService AutenticarComServiceAccount(string credenciaisJson)
        {
            var credenciais = GoogleCredential.FromJson(credenciaisJson);

            return new AnalyticsReportingService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credenciais,
                ApplicationName = "Analyticsreporting Service account Authentication Sample",
            });
        }

    }
}
