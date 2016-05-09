using Metrics;

namespace AspNet.KickStart.Api
{
    public static class SampleApiMetrics
    {
        public static readonly Timer GetValuesTimer = Metric.Timer("Get All Values", Unit.Requests);
    }
}