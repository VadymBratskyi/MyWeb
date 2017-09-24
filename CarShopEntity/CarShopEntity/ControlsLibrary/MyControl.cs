using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace ControlsLibrary
{
    class MyControl : Control
    {
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            writer.Write("I'm specional control");
        }
    }
}
