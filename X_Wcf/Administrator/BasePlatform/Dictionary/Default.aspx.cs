using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Dictionary
{
    public partial class Default : BasePage
    {
        DataSet source;
        E_Model.Dictionary model = new E_Model.Dictionary();
        E_BLL.Dictionary manage = new E_BLL.Dictionary();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = windowSourceCode.GetShowReference("Add.aspx", "添加字典信息", 600, 400);
                btnDelete.OnClientClick = windowSourceCode.GetShowReference("Delete.aspx", "删除字典信息", 600, 400);
                InitTree();
            }
        }

        private void InitTree()
        {
            tvList.Nodes.Clear();

            InitDictionary("00000000-0000-0000-0000-000000000000", tvList, (FineUI.TreeNode)null, windowSourceCode);
        }

        protected void tvList_NodeCommand(object sender, FineUI.TreeCommandEventArgs e)
        {
            txtID.Text = e.Node.NodeID;
            Bind(e.Node.NodeID);
            btnEdit.OnClientClick = windowSourceCode.GetShowReference("Modify.aspx?id=" + txtID.Text, "修改字典信息", 600, 400);
        }

        private void Bind(string ID)
        {
            model = manage.GetModel(ID);
            txtDeptName.Text = model.DICTIONARYNAME;
            txtID.Text = model.ID;
            txtParent.Text = model.PARENTID;
            txtDeptCode.Text = model.DICTIONARYVALUE;
            txtDescription.Text = model.DESCRIPTION;
            if (model.PARENTID != null)
            {
                model = new E_Model.Dictionary();
                txtParentID.Text = manage.GetModel(txtParent.Text).DICTIONARYNAME;
            }
        }

        protected void windowSourceCode_Close(object sender, EventArgs e)
        {
            
        }
    }
}