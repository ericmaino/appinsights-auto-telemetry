using System.Web;

namespace MeetEric.Web
{
    public class HttpApplicationWithTelemetry : HttpApplication
    {
        public override void Init()
        {
            base.Init();
            new AutomaticTelemetryHttpModule().Init(this);
        }
    }
}
