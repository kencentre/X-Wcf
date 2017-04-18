using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.CMSPlatform.NewsChannel
{
    public partial class Delete : BasePage
    {
        string str = "";
        E_Model.NewsChannel model = new E_Model.NewsChannel();
        E_BLL.NewsChannel manage = new E_BLL.NewsChannel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MainList.Nodes.Clear();
                InitChannelWithCheckBox("00000000-0000-0000-0000-000000000000", MainList, (FineUI.TreeNode)null);
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

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            FineUI.TreeNode Node = MainList.Nodes[0];
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
                MainList.CheckAllNodes(e.Node.Nodes);
            }
            else
            {
                MainList.UncheckAllNodes(e.Node.Nodes);
            }
        }
    }
}