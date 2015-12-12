using System.Web;
using MeetEric.Properties;

namespace MeetEric.Web
{
    public class HttpApplicationWithTelemetry : HttpApplication
    {
        private readonly string _appInsightsConfig;

        /// <summary>
        /// Initializes a new instance of <see cref="HttpApplicationWithTelemetry"/>
        /// </summary>
        /// <param name="developersKey">An application insights key used for development purposes</param>
        /// <remarks>
        /// Ideally this class is overridden by common <see cref="HttpApplication"/> that all of the web applications
        /// in common company domain derive from. This provides a commmon developer application insights hub that can 
        /// be used during development and allows the Application Insights key to be overridden using application settings
        /// in production
        /// </remarks>
        protected HttpApplicationWithTelemetry(string developersKey)
            : this(developersKey, Resources.ApplicationInsights)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="HttpApplicationWithTelemetry"/>
        /// </summary>
        /// <param name="developersKey">An application insights key used for development purposes</param>
        /// <param name="configXml">The xml string representation of an application insights config</param>
        /// <remarks>
        /// Ideally this class is overridden by common <see cref="HttpApplication"/> that all of the web applications
        /// in common company domain derive from. This provides a commmon developer application insights hub that can 
        /// be used during development and allows the Application Insights key to be overridden using application settings
        /// in production
        /// </remarks>
        public HttpApplicationWithTelemetry(string developersKey, string configXml)
        {
            _appInsightsConfig = configXml.Replace("<DeveloperKey></DeveloperKey>", $"<DeveloperKey>{developersKey}</DeveloperKey>");
        }

        public override void Init()
        {
            base.Init();
            new AutomaticTelemetryHttpModule(_appInsightsConfig).Init(this);
        }
    }
}
