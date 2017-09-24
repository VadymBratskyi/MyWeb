using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShopEntity.Controls
{
    public partial class TabsUserControl3 : System.Web.UI.UserControl
    {
        private List<string> _tabs = new List<string>();

        public List<string> Tabs
        {
            get { return _tabs; }
            set { _tabs = value; }
        }

        public Color BackColor
        {
            get
            {
                object color = ViewState["BackColor"];
                if (color == null)
                {
                    return Color.Silver;
                }
                return (Color) color;
            }
            set
            {
                ViewState["BackColor"] = value;
            }
        }

        public Color ForeColor
        {
            get
            {
                object color = ViewState["ForeColor"];
                if (color == null)
                {
                    return Color.Silver;
                }
                return (Color)color;
            }
            set
            {
                ViewState["ForeColor"] = value;
            }
        }

        public Color SelectTabColor
        {
            get
            {
                object color = ViewState["SelectTabColor"];
                if (color == null)
                {
                    return Color.Silver;
                }
                return (Color)color;
            }
            set
            {
                ViewState["SelectTabColor"] = value;
            }
        }

        public int CurrentTabIndex
        {
            get
            {
                object index = ViewState["CurrentTabIndex"];
                if (index == null)
                {
                    index = (int)0;
                }
                return (int)index;
            }
            set { ViewState["CurrentTabIndex"] = value; }
        }

        public void On_SelectChange(object sender, EventArgs args)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            tabRepetr.DataSource = _tabs;
            tabRepetr.DataBind();
        }

        protected Color GetBackColor(object obj)
        {
            RepeaterItem item = (RepeaterItem) obj;
            if (item.ItemIndex == CurrentTabIndex)
            {
                return SelectTabColor;
            }
            return BackColor;
        }

        public void SelectIndex(int tabIndex)
        {
            if (tabIndex <0||tabIndex > _tabs.Count)
            {
                tabIndex = 0;
            }
            ViewState["CurrentTabIndex"] = tabIndex;
            BindData();

            SelectionChanchedEventArgs e = new SelectionChanchedEventArgs();
            e.Position = tabIndex;
            OnSelectionChange(e);
        }

        protected void tabRepetr_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            SelectIndex(e.Item.ItemIndex);
        }

        public event EventHandler<SelectionChanchedEventArgs> SelectionChanged; 

        protected virtual void OnSelectionChange(SelectionChanchedEventArgs args)
        {
            if (SelectionChanged != null)
            {
                SelectionChanged.Invoke(this, args);
            }
        }



    }

    public class SelectionChanchedEventArgs : EventArgs
    {
        public int Position { get; set; }
    }
}