using System.Collections.Generic;
using System.Web.Optimization;

namespace IkeCode.Web.Core.Mvc
{
    public class AsDefinedBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
