﻿using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.Tools
{
    public partial class WebSiteChoose : BasePage
    {
        string str = "";
        E_BLL.NewsChannel manage = new E_BLL.NewsChannel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tvList.Nodes.Clear();
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                InitWebsite("00000000-0000-0000-0000-000000000000", tvList, (FineUI.TreeNode)null);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(tvList.SelectedNode.Text, tvList.SelectedNode.NodeID) + ActiveWindow.GetHideReference());
        }
    }
}