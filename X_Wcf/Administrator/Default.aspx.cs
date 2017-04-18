using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace X_Wcf.Administrator
{
    public partial class Default : BasePage
    {
        DataSet ds = new DataSet();
        DataSet dv = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                framePanel.EnableIFrame = true;
                framePanel.IFrameUrl = "userdesk/default.aspx";
                btnResource.OnClientClick = windowSourceCode.GetShowReference("Tools/RetroactionPage.aspx", "反馈", 600, 450);
                btnHelp.OnClientClick = windowSourceCode.GetShowReference("../grid/grid_iframe_window.aspx", "帮助", 800, 450);
                btnModifyPwd.OnClientClick = windowSourceCode.GetShowReference("BasePlatform/Account/UpdatePassword.aspx", "修改密码", 500, 200);
                btnModifyInfo.OnClientClick = windowSourceCode.GetShowReference("BasePlatform/Account/ChangeUserInfo.aspx", "修改个人信息", 500, 350);
                InitSystem();
                InitThemeMenuButton();
                litOnlineUserCount.Text = Application["OnlineUserCount"].ToString();
            }
        }


        private void InitThemeMenuButton()
        {
            string themeMenuID = "MenuThemeNeptune";

            string themeValue = PageManager1.Theme.ToString().ToLower();
            switch (themeValue)
            {
                case "classic":
                case "blue":
                    themeMenuID = "MenuThemeBlue";
                    break;
                case "gray":
                    themeMenuID = "MenuThemeGray";
                    break;
                case "neptune":
                    themeMenuID = "MenuThemeNeptune";
                    break;
                case "crisp":
                    themeMenuID = "MenuThemeCrisp";
                    break;
                case "triton":
                    themeMenuID = "MenuThemeTriton";
                    break;
            }

            SetSelectedMenuID(MenuTheme, themeMenuID);
        }

        private void SetSelectedMenuID(MenuButton menuButton, string selectedMenuID)
        {
            foreach (FineUI.MenuItem item in menuButton.Menu.Items)
            {
                MenuCheckBox menu = (item as MenuCheckBox);
                if (menu != null && menu.ID == selectedMenuID)
                {
                    menu.Checked = true;
                }
                else
                {
                    menu.Checked = false;
                }
            }
        }



        private void InitSystem()
        {
            ds = GetMainListByAccountID(Session["AccountID"].ToString(), "00000000-0000-0000-0000-000000000000");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    Tree t = new Tree();
                    t.EnableLines = true;
                    t.CssClass = "treeCursor";
                    t.ShowHeader = false;
                    t.Title = ds.Tables[0].Rows[i]["MainName"].ToString();
                    t.Icon = GetIcon(ds.Tables[0].Rows[i]["MainIcon"].ToString()).Icon;
                    t.AutoScroll = true;
                    FineUI.TreeNode root = new FineUI.TreeNode();
                    root.Text = ds.Tables[0].Rows[i]["MainName"].ToString();
                    root.Expanded = true;

                    t.Nodes.Add(root);
                    AddTree(t, ds.Tables[0].Rows[i]["id"].ToString(), root);

                    leftPanel.Items.Add(t);
                    //Region1.Items.Add(a);
                }

            }
        }

        public void AddTree(FineUI.Tree pcx, string ParentID, FineUI.TreeNode pNode)
        {
            btnUserName.Text = Session["AccountName"].ToString();
            dv = GetMainListByAccountID(Session["AccountID"].ToString(), ParentID);
            //dv = manage.GetUserMainList(ParentID, "f7f510c1-d10f-4bf4-ad13-941808a0d5ae");
            System.Data.DataView dvTree = new System.Data.DataView(dv.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["MainName"].ToString();
                Node.Target = Row["MainURL"].ToString();//Row["SystemURL"].ToString(); ;
                Node.Icon = GetIcon(Row["MainIcon"].ToString()).Icon;
                Node.Expanded = true;
                if (Node.Target != "#")
                {
                    Node.Expanded = true;
                    Node.OnClientClick = mainTabStrip.GetAddTabReference(Node.Text, Node.Target, Node.Text, IconHelper.GetIconUrl(GetIcon(Row["MainIcon"].ToString()).Icon), true);
                    Node.Icon = GetIcon(Row["MainIcon"].ToString()).Icon;
                }
                pNode.Nodes.Add(Node);
                AddTree(pcx, Row["id"].ToString(), Node);//再次递归  

            }
        }

    }
}