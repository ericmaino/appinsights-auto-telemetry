using MeetEric.Properties;
using Microsoft.ApplicationInsights.Web;
using System;
using System.IO;
using System.Text;
using System.Web;

namespace MeetEric.Web
{
    class AutomaticTelemetryHttpModule : IHttpModule
    {
        private readonly string _configContents;

        public AutomaticTelemetryHttpModule(string configXml)
        {
            _configContents = configXml;
        }

        public void Init(HttpApplication context)
        {
            DeployConfigFile();
            new ApplicationInsightsHttpModule().Init(context);
        }

        private void DeployConfigFile()
        {
            // HACK: This should go away soon once application insights doesn't 
            // require reading configuration from a specific file on disk

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ApplicationInsights.config"), _configContents, Encoding.UTF8);
        }

        public void Dispose()
        {
        }
    }
}
