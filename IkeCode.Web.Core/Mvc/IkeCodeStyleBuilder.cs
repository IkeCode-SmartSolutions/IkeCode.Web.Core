using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Optimization;

namespace IkeCode.Web.Core.Mvc
{
    public class IkeCodeStyleBuilder : IBundleBuilder
    {
        public virtual string BuildBundleContent(Bundle bundle, BundleContext context, IEnumerable<BundleFile> files)
        {
            var content = new StringBuilder();
            foreach (var file in files)
            {
                FileInfo f = new FileInfo(HttpContext.Current.Server.MapPath(file.VirtualFile.VirtualPath));
                CssSettings settings = new CssSettings();
                settings.IgnoreAllErrors = true;
                settings.CommentMode = CssComment.Important;
                var minifier = new Minifier();
                string readFile = Read(f);
                string res = minifier.MinifyStyleSheet(readFile, settings);
                content.Append(res);
            }

            return content.ToString();
        }

        public static string Read(FileInfo file)
        {
            using (var r = file.OpenText())
            {
                return r.ReadToEnd();
            }
        }
    }
}
