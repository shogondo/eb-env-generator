using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Generator.CLI
{
    public class Application
    {
        const string APPLICATION_NAME = "sample-app";

        private AmazonElasticBeanstalkClient client;

        public string Name
        {
            get
            {
                return APPLICATION_NAME;
            }
        }

        public Application()
        {
            client = new AmazonElasticBeanstalkClient();
        }

        public async Task<bool> IsExists()
        {
            var request = new DescribeApplicationsRequest
            {
                ApplicationNames = new List<string> { APPLICATION_NAME }
            };
            var response = await client.DescribeApplicationsAsync(request);
            return response.Applications.Count > 0;
        }

        public async Task Create()
        {
            var request = new CreateApplicationRequest(APPLICATION_NAME);
            await client.CreateApplicationAsync(request);
        }
    }
}
