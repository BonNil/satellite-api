using Sitecore.LayoutService.ItemRendering.Pipelines.GetLayoutServiceContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace satellite_api.Processors
{
    public class LayoutServiceProcessor : IGetLayoutServiceContextProcessor
    {
        public void Process(GetLayoutServiceContextArgs args)
        {
            Sitecore.Diagnostics.Log.Info("layoutService patch executes!", this);
        }
    }
}