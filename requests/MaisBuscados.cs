using System.Collections.Generic;
using Google.Apis.AnalyticsReporting.v4.Data;

namespace TestesGAReportingApiV4.Requests
{
    public class MaisBuscados : ReportRequest
    {
        public MaisBuscados(string viewId, DateRange dateRange, int limit = 15)
        {
            ViewId = viewId;
            DateRanges = new List<DateRange> { dateRange };
            PageSize = limit;

            Dimensions = new List<Dimension>()
            {
                new Dimension { Name = "ga:eventLabel" }
            };

            Metrics = new List<Metric>()
            {
                new Metric { Expression = "ga:totalEvents", Alias = "Total events" }
            };

            DimensionFilterClauses = new List<DimensionFilterClause>()
            {
                new DimensionFilterClause()
                {
                    Filters = new List<DimensionFilter>()
                    {
                        new DimensionFilter { DimensionName = "ga:eventAction", Operator__ = "EXACT", Expressions = new List<string>{ "search" } }
                    }
                }
            };
        }
    }
}