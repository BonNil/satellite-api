using Sitecore.Diagnostics;
using Sitecore.LayoutService.Mvc.Routing;
using Sitecore.Mvc.Presentation;
using Sitecore.Owin.Authentication.Pipelines.CookieAuthentication.ApplyRedirect;

namespace satellite_api.Processors
{
    public class SkipLayoutServiceRequest : ApplyRedirectProcessor
    {
        protected readonly IRouteMapper RouteMapper;

        public SkipLayoutServiceRequest(IRouteMapper routeMapper)
        {
            Assert.ArgumentNotNull(routeMapper, "routeMapper");
            RouteMapper = routeMapper;
        }

        public override void Process(ApplyRedirectArgs args)
        {
            Assert.ArgumentNotNull(args, nameof(args));

            if (PageContext.Current != null && PageContext.Current.RequestContext != null && RouteMapper.IsLayoutServiceRoute(PageContext.Current.RequestContext))
            {
                args.Context.RedirectUri = null;
                args.AbortPipeline();
            }
        }
    }
}