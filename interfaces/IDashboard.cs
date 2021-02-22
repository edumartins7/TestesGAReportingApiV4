using System.Collections.Generic;
using Google.Apis.AnalyticsReporting.v4.Data;

public interface IDashboard
{
    IEnumerable<object> Requests { get; set; }
    IEnumerable<GetReportsResponse> Consultar();

}