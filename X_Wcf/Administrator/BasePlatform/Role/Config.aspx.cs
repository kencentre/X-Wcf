using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Role
{
    public partial class Config : BasePage
    {
        string str = "";
        E_BLL.MainRole manage = new E_BLL.MainRole();
        E_Model.MainRole model = new E_Model.MainRole();
        E_BLL.Main mm = new E_BLL.Main();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tvList.Nodes.Clear();
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                InitMainWithCheckBoxValue("00000000-0000-0000-0000-000000000000", tvList, (FineUI.TreeNode)null);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            manage.Delete(Request["ID"].ToString());
            FineUI.TreeNode Node = tvList.Nodes[0];
            SetTreeValue(Node);
            Alert.ShowInParent("授权成功。", string.Empty, ActiveWindow.GetHidePostBackReference());
        }

        protected void tvList_NodeCheck(object sender, TreeCheckEventArgs e)
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

        private void SetTreeValue(FineUI.TreeNode pNode)
        {
            model.MAINID = pNode.NodeID;
            model.ROLEID = Request["ID"].ToString();
            manage.Add(model);
            foreach (FineUI.TreeNode cNode in pNode.Nodes)
            {
                if (cNode.Checked == true)
                {
                    SetTreeValue(cNode);
                }
            }
        }


        protected void InitMainWithCheckBoxValue(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
        {
            ds = mm.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["MainName"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.Icon = GetIcon(Row["MainIcon"].ToString()).Icon;
                Node.EnableCheckBox = true;
                Node.Expanded = false;
                Node.EnableCheckEvent = true;

                DataSet dt = new DataSet();
                dt = manage.GetList(" ROLEID= '" + Request["ID"].ToString() + "' AND  MAINID ='" + Node.NodeID + "'");
                if (dt.Tables[0].Rows.Count == 1)
                {
                    Node.Checked = true;
                }
                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitMainWithCheckBoxValue(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }
    }
}