using System.Collections.Generic;

namespace AspNet.KickStart.Api
{
    public interface ISampleService
    {
        string Find(int id);

        IEnumerable<string> FindAll();
    }

    public class SampleService : ISampleService
    {
        public SampleService()
        {
        }

        public string Find(int id)
        {
            return string.Format("value{0}", id);
        }

        public IEnumerable<string> FindAll()
        {
            return new[] { "value1", "value2" };
        }
    }
}