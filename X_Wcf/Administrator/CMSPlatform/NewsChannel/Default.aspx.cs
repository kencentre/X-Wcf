using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.CMSPlatform.NewsChannel
{
    public partial class Default : BasePage
    {
        E_BLL.NewsChannel manage = new E_BLL.NewsChannel();
        E_Model.NewsChannel model = new E_Model.NewsChannel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = windowSourceCode.GetShowReference("Add.aspx", "添加栏目信息", 600, 400);
                btnDelete.OnClientClick = windowSourceCode.GetShowReference("Delete.aspx", "删除栏目信息", 600, 500);

            }

            InitTree();
        }
        private void InitTree()
        {
            tvList.Nodes.Clear();

            InitChannel("00000000-0000-0000-0000-000000000000", tvList, (FineUI.TreeNode)null, windowSourceCode);
        }

        protected void tvList_NodeCommand(object sender, FineUI.TreeCommandEventArgs e)
        {
            txtID.Text = e.Node.NodeID;
            Bind(e.Node.NodeID);
            btnEdit.OnClientClick = windowSourceCode.GetShowReference("Modify.aspx?id=" + txtID.Text, "修改栏目信息", 600, 400);
        }

        private void Bind(string ID)
        {
            model = new E_Model.NewsChannel();
            model = manage.GetModel(ID);
            txtChannelName.Text = model.CHANNELNAME;
            txtChannelCode.Text = model.CHANNELCODE;
            txtParent.Text = model.PARENTID;
            txtDescription.Text = model.DESCRIPTION;
            txtMainList.Text = model.SORTLIST.ToString();

            if (model.STATUS == "0")
            {
                cblStatus.Checked = false;
            }
            if (model.STATUS == "1")
            {
                cblStatus.Checked = true;
            }
            if (model.PARENTID != "00000000-0000-0000-0000-000000000000")
            {
                model = new E_Model.NewsChannel();
                txtParentID.Text = manage.GetModel(txtParent.Text).CHANNELNAME;
            }
        }
    }
}