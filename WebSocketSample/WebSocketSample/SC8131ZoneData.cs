using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketSample
{
    public class Source
    {
        public DateTime ReportTime { get; set; }
        public string GroupID { get; set; }
        public string DeviceID { get; set; }
        public string ModelName { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public string TimeZone { get; set; }
        public string DST { get; set; }
    }

    public class CountingInfo
    {
        public string RuleName { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class ZoneInfo
    {
        public string RuleName { get; set; }
        public int NewEnterCount { get; set; }
        public int TotalLeaveTime { get; set; }
        public int TotalCount { get; set; }
        public double AvgWaitTime { get; set; }
        public double AvgWaitCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class Datum
    {
        public string RuleType { get; set; }
        public List<CountingInfo> CountingInfo { get; set; }
        public List<ZoneInfo> ZoneInfo { get; set; }
    }
    public class RootObject
    {
        public string Tag { get; set; }
        public Source Source { get; set; }
        public List<Datum> Data { get; set; }
    }
}
