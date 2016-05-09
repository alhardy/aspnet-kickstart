using Metrics;
using Metrics.Core;

namespace AspNet.KickStart.Api.HealthChecks
{
    public class SampleHealthCheck : HealthCheck
    {
        public SampleHealthCheck() : base("Sample Health Check")
        {
        }

        protected override HealthCheckResult Check()
        {
            return HealthCheckResult.Healthy("OK");
        }
    }
}