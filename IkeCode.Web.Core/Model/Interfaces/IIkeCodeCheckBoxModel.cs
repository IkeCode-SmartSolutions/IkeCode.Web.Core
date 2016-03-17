using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkeCode.Web.Core.Model.Interfaces
{
    public interface IIkeCodeCheckBoxModel
    {
        string Id { get; set; }
        bool Selected { get; set; }
        string Name { get; set; }
        string Title { get; set; }
    }
}
