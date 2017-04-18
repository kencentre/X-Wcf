using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Dept
{
    public partial class Delete : BasePage
    {
        string str = "";
        E_Model.Dept model = new E_Model.Dept();
        E_BLL.Dept manage = new E_BLL.Dept();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tvList.Nodes.Clear();
                InitDeptWithCheckBox("00000000-0000-0000-0000-000000000000", tvList, (FineUI.TreeNode)null);
            }
        }


        private string SetTreeValue(FineUI.TreeNode pNode)
        {

            foreach (FineUI.TreeNode cNode in pNode.Nodes)
            {
                if (cNode.Checked == true)
                {
                    if (cNode.NodeID != "")
                    {
                        str += "'" + cNode.NodeID + "',";
                    }

                }
                SetTreeValue(cNode);
            }
            return str;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            FineUI.TreeNode Node = tvList.Nodes[0];
            string ListID = SetTreeValue(Node);
            if (ListID.Contains(","))
            {
                ListID = ListID.Remove(ListID.LastIndexOf(","));
            }
            if (ListID == "")
            {
                Alert.ShowInParent("请选择要删除的项");
                return;
            }
            bool rs = manage.DeleteList(ListID);
            if (rs != false)
            {
                Alert.ShowInParent("保存成功。", string.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInParent("提交失败");
            }
        }

        protected void MainList_NodeCheck(object sender, TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                tvList.CheckAllNodes(e.Node.Nodes);
            }
            else
            {
                tvList.UncheckAllNodes(e.Node.Nodes);
            }
        }
    }
}