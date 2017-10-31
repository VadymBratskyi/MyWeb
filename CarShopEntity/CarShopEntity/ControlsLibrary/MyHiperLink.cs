using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ControlsLibrary
{
    public class MyHiperLink : HyperLink
    {
        public new string NavigateUrl
        {
            get { return base.NavigateUrl; }
            set { base.NavigateUrl = value + "?test=hello"; }
        }
    }
}
