using Sitecore.Pipelines.HttpRequest;

namespace satellite_api.Processors
{
    public class HttpReqProcessor : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            Sitecore.Diagnostics.Log.Info("HttpRequest patch executes!", this);

            var userPrincipal = args.Context.User;
            var user = Sitecore.Security.Accounts.User.FromPrincipal(userPrincipal);

            Sitecore.Data.Items.Item item = null;
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {

                item = Sitecore.Data.Database.GetDatabase("master").GetItem("/sitecore/content/satellite/en/banan");
            }

            var userCanRead = false;
            if (item != null)
            {
                userCanRead = item.Security.CanRead(user);
            }
        }
    }
}