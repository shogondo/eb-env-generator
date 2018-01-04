using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Generator.CLI
{
    public class Environment
    {
        const string ENVIRONMENT_NAME_PREFIX = "sample-env";

        private Application application;

        private AmazonElasticBeanstalkClient client;

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Environment(Application application)
        {
            this.application = application;
            client = new AmazonElasticBeanstalkClient();
            name = String.Format("{0}-{1}", ENVIRONMENT_NAME_PREFIX, DateTime.Now.ToString("yyyyMMddhhmmss"));
        }

        public async Task Create()
        {
            var request = new CreateEnvironmentRequest
            {
                ApplicationName = application.Name,
                EnvironmentName = name,
                SolutionStackName = "64bit Windows Server 2016 v1.2.0 running IIS 10.0"
            };
            await client.CreateEnvironmentAsync(request);
        }
    }
}
