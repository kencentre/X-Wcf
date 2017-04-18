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
    public partial class BasePage : System.Web.UI.Page
    {
        DataSet ds = new System.Data.DataSet();
        DataSet dv = new System.Data.DataSet();
        E_BLL.Main mm = new E_BLL.Main();
        E_BLL.Dept md = new E_BLL.Dept();
        E_BLL.Account ma = new E_BLL.Account();
        E_BLL.Dictionary mDict = new E_BLL.Dictionary();
        E_BLL.DeskAccount Mda = new E_BLL.DeskAccount();
        E_BLL.NewsChannel mChannel = new E_BLL.NewsChannel();
        E_BLL.WebSite mWebSite = new E_BLL.WebSite();
        protected override void OnInit(EventArgs e)
        {
            if (Session["AccountID"] == null || Session["AccountID"].ToString().Trim().Length == 0)
            {
                Alert.ShowInParent("登陆超时。", "消息", "top.location.href='login.aspx'");
                //Response.Redirect("login.html");
            }
            var pm = PageManager.Instance;

            // 如果不是FineUI的AJAX回发（两种情况：1.页面第一个加载 2.页面非AJAX回发）
            if (pm != null && !pm.IsFineUIAjaxPostBack)
            {
                HttpCookie themeCookie = Request.Cookies["Theme_v6"];
                if (themeCookie != null)
                {
                    try
                    {
                        string themeValue = themeCookie.Value;
                        pm.Theme = (Theme)Enum.Parse(typeof(Theme), themeValue, true);
                    }
                    catch (Exception)
                    {
                        pm.Theme = FineUI.Theme.Neptune;
                    }
                }

                HttpCookie langCookie = Request.Cookies["Language_v6"];
                if (langCookie != null)
                {
                    try
                    {
                        string langValue = langCookie.Value;
                        pm.Language = (Language)Enum.Parse(typeof(Language), langValue, true);
                    }
                    catch (Exception)
                    {
                        pm.Language = Language.ZH_CN;
                    }
                }

                HttpCookie loadingCookie = Request.Cookies["Loading_v6"];
                if (loadingCookie != null)
                {
                    int loadingNumber = Convert.ToInt32(loadingCookie.Value);
                    pm.LoadingImageNumber = loadingNumber;
                }

            }


            // 为所有页面添加公共的：<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
            System.Web.UI.HtmlControls.HtmlGenericControl metaCtrl = new System.Web.UI.HtmlControls.HtmlGenericControl("meta");
            metaCtrl.Attributes["http-equiv"] = "Content-Type";
            metaCtrl.Attributes["content"] = "text/html; charset=utf-8";
            Header.Controls.AddAt(0, metaCtrl);


            // 为所有页面添加公共的：<link rel="stylesheet" type="text/css" href="res/css/common.css"></link>
            System.Web.UI.HtmlControls.HtmlGenericControl linkCtrl = new System.Web.UI.HtmlControls.HtmlGenericControl("link");
            linkCtrl.Attributes["rel"] = "stylesheet";
            linkCtrl.Attributes["type"] = "text/css";
            linkCtrl.Attributes["href"] = ResolveClientUrl("~/res/css/common.css");
            Header.Controls.Add(linkCtrl);



            base.OnInit(e);
        }

        private bool IsSystemTheme(string themeName)
        {
            themeName = themeName.ToLower();
            string[] themes = Enum.GetNames(typeof(Theme));
            foreach (string theme in themes)
            {
                if (theme.ToLower() == themeName)
                {
                    return true;
                }
            }
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region 设置图标
        protected FineUI.TreeNode GetIcon(string icon)
        {
            FineUI.TreeNode tn = new FineUI.TreeNode();
            switch (icon)
            {
                case "Application":
                    tn.Icon = Icon.Application;
                    break;
                case "ApplicationForm":
                    tn.Icon = Icon.ApplicationForm;
                    break;
                case "ApplicationOsx":
                    tn.Icon = Icon.ApplicationOsx;
                    break;
                case "Book":
                    tn.Icon = Icon.Book;
                    break;
                case "BookOpen":
                    tn.Icon = Icon.BookOpen;
                    break;
                case "BulletDisk":
                    tn.Icon = Icon.BulletDisk;
                    break;
                case "ChartBar":
                    tn.Icon = Icon.ChartBar;
                    break;
                case "Comment":
                    tn.Icon = Icon.Comment;
                    break;
                case "DataBaseYellow":
                    tn.Icon = Icon.DatabaseYellow;
                    break;
                case "Folder":
                    tn.Icon = Icon.Folder;
                    break;
                case "House":
                    tn.Icon = Icon.House;
                    break;
                case "Mail":
                    tn.Icon = Icon.Mail;
                    break;
                case "Map":
                    tn.Icon = Icon.Map;
                    break;
                case "Page":
                    tn.Icon = Icon.Page;
                    break;
                case "Report":
                    tn.Icon = Icon.Report;
                    break;
                case "Table":
                    tn.Icon = Icon.Table;
                    break;
                case "User":
                    tn.Icon = Icon.User;
                    break;
                case "Vcard":
                    tn.Icon = Icon.Vcard;
                    break;
                case "Zoom":
                    tn.Icon = Icon.Zoom;
                    break;
                case "Pencil":
                    tn.Icon = Icon.Pencil;
                    break;
                case "Printer":
                    tn.Icon = Icon.Printer;
                    break;
                case "Smartphone":
                    tn.Icon = Icon.Smartphone;
                    break;
                case "Star":
                    tn.Icon = Icon.Star;
                    break;
                case "World":
                    tn.Icon = Icon.World;
                    break;
            }
            return tn;
        }

        #endregion
        #region 初始化菜单
        protected void InitMain(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode, Window x)
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
                Node.EnableCheckEvent = true;
                Node.Expanded = true;
                if (Node.NodeID != "A8C9876A-7ECB-495C-836A-EC69143A63DE")
                {
                    //Node.OnClientClick = x.GetShowReference("modify.aspx?id=" + Node.NodeID, "修改菜单",550,450);
                    Node.EnableClickEvent = true;
                    Node.Expanded = true;
                }
                Node.Expanded = false;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    Node.EnableClickEvent = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    Node.Expanded = true;
                    pNode.Nodes.Add(Node);
                }
                InitMain(Row["id"].ToString(), treelist, Node, x);//再次递归 
            }
        }

        protected void InitMainWithCheckBox(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
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
                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitMainWithCheckBox(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }

        protected void InitMainWithCheckBox(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode, string ID)
        {
            ds = mm.GetList("");
            DataView dvTree = new DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["MainName"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.Icon = GetIcon(Row["MainIcon"].ToString()).Icon;
                Node.EnableCheckEvent = true;
                if (ID != null)
                {
                    //dv = mrm.GetList(" roleid = '" + ID + "'");
                    //if (dv.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dv.Tables[0].Rows.Count; i++)
                    //    {
                    //        if (Node.NodeID == dv.Tables[0].Rows[i]["mainid"].ToString())
                    //        {
                    //            Node.Checked = true;
                    //        }
                    //    }
                    //}
                }
                Node.EnableCheckBox = true;
                Node.Expanded = false;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitMainWithCheckBox(Row["id"].ToString(), treelist, Node, ID);//再次递归  
            }
        }

        protected void InitMain(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
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
                Node.Expanded = false;
                Node.Icon = GetIcon(Row["MainIcon"].ToString()).Icon;
                Node.EnableCheckEvent = true;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    Node.EnableCheckEvent = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitMain(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }
        #endregion
        #region 初始化部门
        protected void InitDept(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode, Window x)
        {
            ds = md.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["DeptName"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.EnableCheckEvent = true;
                Node.EnableClickEvent = true;
                if (Node.NodeID != "2abe5d4e-3c71-43c0-83b0-a4e2b560aeb0")
                {
                    //Node.OnClientClick = x.GetShowReference("modify.aspx?id=" + Node.NodeID, "修改菜单",550,450);
                    Node.EnableClickEvent = true;
                }
                Node.Expanded = false;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    Node.EnableClickEvent = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitDept(Row["id"].ToString(), treelist, Node, x);//再次递归 
            }
        }

        protected void InitDeptWithCheckBox(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
        {
            ds = md.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["DeptName"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.EnableCheckBox = true;
                Node.Expanded = false;
                Node.EnableCheckEvent = true;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitDeptWithCheckBox(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }

        protected void InitDeptWithCheckBox(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode, string ID)
        {
            ds = md.GetList("");
            DataView dvTree = new DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["DeptName"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.EnableCheckEvent = true;
                if (ID != null)
                {
                    //dv = mrm.GetList(" roleid = '" + ID + "'");
                    //if (dv.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dv.Tables[0].Rows.Count; i++)
                    //    {
                    //        if (Node.NodeID == dv.Tables[0].Rows[i]["mainid"].ToString())
                    //        {
                    //            Node.Checked = true;
                    //        }
                    //    }
                    //}
                }
                Node.EnableCheckBox = true;
                Node.Expanded = false;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitDeptWithCheckBox(Row["id"].ToString(), treelist, Node, ID);//再次递归  
            }
        }

        protected void InitDept(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
        {
            ds = md.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["DeptName"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.Expanded = false;
                Node.EnableCheckEvent = true;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    Node.EnableCheckEvent = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitDept(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }
        #endregion
        #region  初始化用户菜单
        protected DataSet GetMainListByAccountID(string ID)
        {
            return ma.GetAccountMainList(ID);
        }
        protected DataSet GetMainListByAccountID(string ID, string ParentID)
        {
            return ma.GetAccountMainListByPID(ID, ParentID);
        }
        protected void InitAccountMain(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
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
                Node.Expanded = true;

                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitAccountMain(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }
        #endregion
        #region 初始化字典
        protected void InitDictionary(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
        {
            ds = mDict.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["DictionaryName"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.Target = Row["DictionaryValue"].ToString();
                Node.Expanded = false;
                Node.EnableCheckEvent = true;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    Node.EnableCheckEvent = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitDictionary(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }

        protected void InitDictionary(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode, Window x)
        {
            ds = mDict.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["DictionaryName"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.Target = Row["DictionaryValue"].ToString();
                Node.EnableCheckEvent = true;
                if (Node.NodeID != "2abe5d4e-3c71-43c0-83b0-a4e2b560aeb0")
                {
                    //Node.OnClientClick = x.GetShowReference("modify.aspx?id=" + Node.NodeID, "修改菜单",550,450);
                    Node.EnableClickEvent = true;
                }
                Node.Expanded = false;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    Node.EnableClickEvent = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitDictionary(Row["id"].ToString(), treelist, Node, x);//再次递归 
            }
        }

        protected void InitDictionaryWithCheckBox(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
        {
            ds = mDict.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["DictionaryName"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.Target = Row["DictionaryValue"].ToString();
                Node.EnableCheckBox = true;
                Node.Expanded = false;
                Node.EnableCheckEvent = true;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitDictionaryWithCheckBox(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }

        protected void InitDictionaryWithCheckBox(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode, string ID)
        {
            ds = mDict.GetList("");
            DataView dvTree = new DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["DictionaryName"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.Target = Row["DictionaryValue"].ToString();
                Node.EnableCheckEvent = true;
                if (ID != null)
                {
                    //dv = mrm.GetList(" roleid = '" + ID + "'");
                    //if (dv.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dv.Tables[0].Rows.Count; i++)
                    //    {
                    //        if (Node.NodeID == dv.Tables[0].Rows[i]["mainid"].ToString())
                    //        {
                    //            Node.Checked = true;
                    //        }
                    //    }
                    //}
                }
                Node.EnableCheckBox = true;
                Node.Expanded = false;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitDictionaryWithCheckBox(Row["id"].ToString(), treelist, Node, ID);//再次递归  
            }
        }
        #endregion
        #region 初始化系统桌面
        protected DataSet InitDeskByUserId(string UserID)
        {
            return ds = Mda.GetSearchList("", UserID);
        }
        #endregion
        #region 桌面显示

        protected void BindDesk(FineUI.Panel px, int col, string AccountID)
        {
            px.Items.Clear();
            switch (col)
            {
                case 1: px.ColumnWidth = "100%"; break;
                case 2: px.ColumnWidth = "50%"; break;
                case 3: px.ColumnWidth = "33%"; break;
            }

            ds = InitDeskByUserId(AccountID);

            FineUI.Panel p;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    p = new FineUI.Panel();
                    p.ID = "DeskPanel" + i.ToString();
                    p.Title = ds.Tables[0].Rows[i]["DESKNAME"].ToString();
                    p.EnableIFrame = true;
                    p.IFrameUrl = ds.Tables[0].Rows[i]["DESKURL"].ToString();
                    //p.AutoScroll = true;
                    p.ShowBorder = true;
                    p.ShowHeader = true;
                    p.Margin = "4";
                    p.Width = Unit.Pixel(int.Parse(ds.Tables[0].Rows[i]["DESKWIDTH"].ToString()));
                    p.Height = Unit.Pixel(int.Parse(ds.Tables[0].Rows[i]["DESKHEIGHT"].ToString()));
                    if (ds.Tables[0].Rows[i]["ENABLECOL"].ToString() == "0")
                    {
                        p.EnableCollapse = false;
                    }
                    else
                    {
                        p.EnableCollapse = true;
                    }

                    px.Items.Add(p);
                }
            }
        }

        #endregion
        #region 初始化新闻栏目
        protected void InitChannel(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode, Window x)
        {
            ds = mChannel.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["CHANNELNAME"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.EnableCheckEvent = true;
                Node.Expanded = true;
                if (Node.NodeID != "A8C9876A-7ECB-495C-836A-EC69143A63DE")
                {
                    //Node.OnClientClick = x.GetShowReference("modify.aspx?id=" + Node.NodeID, "修改菜单",550,450);
                    Node.EnableClickEvent = true;
                    Node.Expanded = true;
                }
                Node.Expanded = false;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    Node.EnableClickEvent = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    Node.Expanded = true;
                    pNode.Nodes.Add(Node);
                }
                InitChannel(Row["id"].ToString(), treelist, Node, x);//再次递归 
            }
        }

        protected void InitChannelWithCheckBox(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
        {
            ds = mChannel.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["CHANNELNAME"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.EnableCheckBox = true;
                Node.Expanded = false;
                Node.EnableCheckEvent = true;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitChannelWithCheckBox(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }

        protected void InitChannelWithCheckBox(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode, string ID)
        {
            ds = mChannel.GetList("");
            DataView dvTree = new DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["CHANNELNAME"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.EnableCheckEvent = true;
                if (ID != null)
                {
                    //dv = mrm.GetList(" roleid = '" + ID + "'");
                    //if (dv.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dv.Tables[0].Rows.Count; i++)
                    //    {
                    //        if (Node.NodeID == dv.Tables[0].Rows[i]["mainid"].ToString())
                    //        {
                    //            Node.Checked = true;
                    //        }
                    //    }
                    //}
                }
                Node.EnableCheckBox = true;
                Node.Expanded = false;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitChannelWithCheckBox(Row["id"].ToString(), treelist, Node, ID);//再次递归  
            }
        }

        protected void InitChannel(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
        {
            ds = mChannel.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["CHANNELNAME"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.Expanded = false;
                Node.EnableCheckEvent = true;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    Node.EnableCheckEvent = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitChannel(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }
        #endregion
        #region 初始化webSite
        protected void InitWebsite(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode, Window x)
        {
            ds = mWebSite.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["WEBNAME"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.EnableCheckEvent = true;
                Node.Expanded = true;
                if (Node.NodeID != "A8C9876A-7ECB-495C-836A-EC69143A63DE")
                {
                    //Node.OnClientClick = x.GetShowReference("modify.aspx?id=" + Node.NodeID, "修改菜单",550,450);
                    Node.EnableClickEvent = true;
                    Node.Expanded = true;
                }
                Node.Expanded = false;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    Node.EnableClickEvent = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    Node.Expanded = true;
                    pNode.Nodes.Add(Node);
                }
                InitWebsite(Row["id"].ToString(), treelist, Node, x);//再次递归 
            }
        }

        protected void InitWebsiteWithCheckBox(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
        {
            ds = mWebSite.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["WEBNAME"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.EnableCheckBox = true;
                Node.Expanded = false;
                Node.EnableCheckEvent = true;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitWebsiteWithCheckBox(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }

        protected void InitWebsiteWithCheckBox(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode, string ID)
        {
            ds = mWebSite.GetList("");
            DataView dvTree = new DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[WEBNAME]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["CHANNELNAME"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.EnableCheckEvent = true;
                if (ID != null)
                {
                    //dv = mrm.GetList(" roleid = '" + ID + "'");
                    //if (dv.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dv.Tables[0].Rows.Count; i++)
                    //    {
                    //        if (Node.NodeID == dv.Tables[0].Rows[i]["mainid"].ToString())
                    //        {
                    //            Node.Checked = true;
                    //        }
                    //    }
                    //}
                }
                Node.EnableCheckBox = true;
                Node.Expanded = false;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitWebsiteWithCheckBox(Row["id"].ToString(), treelist, Node, ID);//再次递归  
            }
        }

        protected void InitWebsite(string ParentID, FineUI.Tree treelist, FineUI.TreeNode pNode)
        {
            ds = mWebSite.GetList("");
            System.Data.DataView dvTree = new System.Data.DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点  
            dvTree.RowFilter = "[ParentID]   =   '" + ParentID + "'";

            foreach (DataRowView Row in dvTree)
            {
                FineUI.TreeNode Node = new FineUI.TreeNode();
                Node.Text = Row["WEBNAME"].ToString();
                Node.NodeID = Row["id"].ToString();
                Node.Expanded = false;
                Node.EnableCheckEvent = true;
                if (pNode == null)
                {
                    Node.Expanded = true;
                    Node.EnableCheckEvent = true;
                    treelist.Nodes.Add(Node);
                }
                else
                {
                    pNode.Nodes.Add(Node);
                }
                InitWebsite(Row["id"].ToString(), treelist, Node);//再次递归 
            }
        }
        #endregion
        #region 验证格式
        protected bool ValidateFileType(string fileName, List<string> VALID_FILE_TYPES)
        {
            string fileType = String.Empty;
            int lastDotIndex = fileName.LastIndexOf(".");
            if (lastDotIndex >= 0)
            {
                fileType = fileName.Substring(lastDotIndex + 1).ToLower();
            }

            if (VALID_FILE_TYPES.Contains(fileType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}