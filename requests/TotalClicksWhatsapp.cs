using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.AnalyticsReporting.v4.Data;

namespace TestesGAReportingApiV4.Requests
{

    public class TotalClicksWhatsapp : ReportRequest
    {
        public TotalClicksWhatsapp(string viewId, DateRange dateRange, string filtro = "")
        {
            ViewId = viewId;
            DateRanges = new List<DateRange> { dateRange };

            Dimensions = new List<Dimension>() {
                new Dimension { Name = "ga:eventLabel"}
            };

            Metrics = new List<Metric>()
            {
                new Metric { Expression = "ga:totalEvents", Alias = "Total events"},
                new Metric { Expression = "ga:avgEventValue", Alias = "Avg. Value" }
            };

            DimensionFilterClauses = new List<DimensionFilterClause>()
            {
                new DimensionFilterClause()
                {
                    Filters = new List<DimensionFilter>()
                    {
                        new DimensionFilter { DimensionName = "ga:eventAction", Operator__ = "EXACT", Expressions = new List<string>{ "clicou_whatsapp" } },
                    }
                }
            };

            if(string.IsNullOrEmpty(filtro) == false){
                DimensionFilterClauses.First().Filters.Add(
                        new DimensionFilter { DimensionName = "ga:eventLabel", Operator__ = "EXACT", Expressions = new List<string>{ filtro } }
                );
            }
        }    
    }

}