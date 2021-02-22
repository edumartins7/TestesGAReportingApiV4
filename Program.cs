using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.AnalyticsReporting.v4.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Newtonsoft.Json;
using TestesGAReportingApiV4.Requests;

namespace TestesGAReportingApiV4
{
    class Program
    {
        private static string _viewId = "235071939";
        public static string _jsonCredenciaisSA = File.ReadAllText(@"C:\credentials\3e74795e54e4.json");

        static void Main(string[] args)
        {
            AnalyticsReportingService service = AutenticarComServiceAccount(_jsonCredenciaisSA);

            var dateRange = new DateRange() {
                StartDate = "2020-12-20",
                EndDate = "2021-01-20"
            };

            //máximo 5
            var requests = new List<ReportRequest>() {
              new TotalClicksWhatsapp(_viewId, dateRange),
              new TotalClicksWhatsapp(_viewId, dateRange, "O BOTICÁRIO"),
              new MaisBuscados(_viewId, dateRange)
            };

            var getReportsRequest = new GetReportsRequest { ReportRequests = requests };

            GetReportsResponse response = service.Reports.BatchGet(getReportsRequest).Execute();

            foreach (var report in response.Reports)
            {
                Console.WriteLine("------------------------------------------------------------------------------------");

                foreach(var row in report.Data.Rows){
                    string dimensions = row.Dimensions.Aggregate((x, y) => x + ", " + y);

                    foreach(var metric in row.Metrics){
                        Console.WriteLine($"{dimensions}, {metric.Values.Aggregate((a, y) => a + ", " + y)}");
                    }
                }
            }

        }

        static AnalyticsReportingService AutenticarComServiceAccount(string credenciaisJson)
        {
            var credenciais = GoogleCredential.FromJson(credenciaisJson);

            return new AnalyticsReportingService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credenciais,
                ApplicationName = "Testes",
            });
        }

    }
}
