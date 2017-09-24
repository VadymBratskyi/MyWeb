using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace ControlsLibrary
{
    class MyControlBt : Control
    {
        protected override void Render(HtmlTextWriter writer)
        {            
            writer.Write("<input type='button' title='testBt'>");
        }
    }
}
