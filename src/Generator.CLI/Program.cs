using System;
using System.Threading.Tasks;

namespace Generator.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Execute().Wait();
        }

        async Task Execute()
        {
            var app = new Application();
            Console.WriteLine("Checking EB app...");
            if (!await app.IsExists())
            {
                Console.WriteLine("Creating EB app '{0}'...", app.Name);
                await app.Create();
            }

            var env = new Environment(app);
            Console.WriteLine("Creating EB env '{0}'...", env.Name);
            await env.Create();
        }
    }
}
