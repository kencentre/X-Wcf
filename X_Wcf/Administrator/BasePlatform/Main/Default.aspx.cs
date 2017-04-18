using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;    

namespace X_Wcf.Administrator.BasePlatform.Main
{
    public partial class Default : BasePage
    {
        E_Model.Main model = new E_Model.Main();
        E_BLL.Main manage = new E_BLL.Main();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = windowSourceCode.GetShowReference("Add.aspx", "添加菜单信息", 600, 400);
                btnDelete.OnClientClick = windowSourceCode.GetShowReference("Delete.aspx", "删除菜单信息", 600, 500);

            }

            InitTree();
        }
        private void InitTree()
        {
            tvList.Nodes.Clear();

            InitMain("00000000-0000-0000-0000-000000000000", tvList, (FineUI.TreeNode)null, windowSourceCode);
        }

        protected void tvList_NodeCommand(object sender, FineUI.TreeCommandEventArgs e)
        {
            txtID.Text = e.Node.NodeID;
            Bind(e.Node.NodeID);
            btnEdit.OnClientClick = windowSourceCode.GetShowReference("Modify.aspx?id=" + txtID.Text, "修改菜单信息", 600, 400);
        }

        private void Bind(string ID)
        {
            model = new E_Model.Main();
            model = manage.GetModel(ID);
            txtMainName.Text = model.MAINNAME;
            txtIcon.Text = model.MAINICON;
            txtParent.Text = model.PARENTID;
            txtMainUrl.Text = model.MAINURL;
            txtDescription.Text = model.DESCRIPTION;
            txtMainList.Text = model.SORTLIST.ToString();
            if (model.PARENTID != "00000000-0000-0000-0000-000000000000")
            {
                model = new E_Model.Main();
                txtParentID.Text = manage.GetModel(txtParent.Text).MAINNAME;
            }
        }
    }
}