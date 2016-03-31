using System.Web.Optimization;

namespace IkeCode.Web.Core.Mvc
{
    public class IkeCodeStyleBundle : Bundle
    {
        public IkeCodeStyleBundle(string virtualPath)
        : base(virtualPath)
        {
            this.Builder = new IkeCodeStyleBuilder();
        }

        public IkeCodeStyleBundle(string virtualPath, string cdnPath)
        : base(virtualPath, cdnPath)
        {
            this.Builder = new IkeCodeStyleBuilder();
        }
    }
}
