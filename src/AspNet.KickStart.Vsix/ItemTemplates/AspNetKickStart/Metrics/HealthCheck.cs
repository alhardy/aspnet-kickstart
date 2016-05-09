using Metrics;
using Metrics.Core;

namespace $rootnamespace$
{
    public class $safeitemname$ : HealthCheck
    {
        public $safeitemname$() : base("$safeitemname$ Health Check")
        {
        }

        protected override HealthCheckResult Check()
        {
            return HealthCheckResult.Healthy("OK");
        }
    }
}
