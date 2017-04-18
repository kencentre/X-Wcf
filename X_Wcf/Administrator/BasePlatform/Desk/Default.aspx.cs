using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Desk
{
    public partial class Default : BasePage
    {
        DataSet source;
        E_Model.Desk model = new E_Model.Desk();
        E_BLL.Desk manage = new E_BLL.Desk();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = windowSourceCode.GetShowReference("Add.aspx", "添加模块信息");
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertInTopReference("请至少选择一项！");
                btnDelete.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", Grid1.GetSelectedCountReference());

                btnApproval.OnClientClick = Grid1.GetNoSelectionAlertInTopReference("请至少选择一项！");
                btnApproval.ConfirmText = String.Format("你确定要审核选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", Grid1.GetSelectedCountReference());

                BindGrid();

                ddlPageSize.SelectedValue = Grid1.PageSize.ToString();
            }
        }


        private void BindGrid()
        {
            ViewState["UseDataSource1"] = true;

            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            Grid1.RecordCount = GetTotalCount();

            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);

            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        private DataSet InitGrid()
        {
            if (txtSearch.Text.Trim() != "")
            {
                ViewState["Search"] = txtSearch.Text;
            }
            else
            {
                ViewState["Search"] = "";
            }
            if (ViewState["txtStart"] == null)
            {
                ViewState["txtStart"] = "";
            }
            if (ViewState["txtEnd"] == null)
            {
                ViewState["txtEnd"] = "";
            }
            source = new DataSet();
            source = manage.GetSearchList(ViewState["Search"].ToString(), ViewState["txtStart"].ToString(), ViewState["txtEnd"].ToString());
            return source;
        }

        /// <summary>
        /// 返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            return InitGrid().Tables[0].Rows.Count;
        }

        /// <summary>
        /// 数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {
            source = new DataSet();
            source = InitGrid();
            DataTable paged = source.Tables[0].Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Tables[0].Rows.Count)
            {
                rowend = source.Tables[0].Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Tables[0].Rows[i]);
            }

            return paged;
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            BindGrid();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid1.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            BindGrid();
        }

        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                bool rs = manage.Delete(Grid1.DataKeys[e.RowIndex][0].ToString());
                if (rs != false)
                {
                    Alert.ShowInParent("提交成功");
                    BindGrid();
                }
                else
                {
                    Alert.ShowInParent("提交失败");
                }
            }
            if (e.CommandName == "Approval")
            {
                bool rs = manage.UpdateStatus(Grid1.DataKeys[e.RowIndex][0].ToString(), decimal.Parse(Grid1.DataKeys[e.RowIndex][1].ToString()));
                if (rs != false)
                {
                    Alert.ShowInParent("提交成功");
                    BindGrid();
                }
                else
                {
                    Alert.ShowInParent("提交失败");
                }
            }
        }

        protected void Grid1_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                if (e.Values[3].ToString() == "0")
                {
                    e.Values[3] = "<span style='color:red'>停用</span>";
                }
                if (e.Values[3].ToString() == "1")
                {
                    e.Values[3] = "<span style='color:green'>启用</span>";
                }
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() != "")
            {
                ViewState["Search"] = txtSearch.Text;

            }
            if (txtStartDate.Text.Trim() == "")
            {
                ViewState["txtStart"] = "";
            }
            else
            {
                ViewState["txtStart"] = txtStartDate.Text.Trim();
            }
            if (txtEndDate.Text.Trim() == null)
            {
                ViewState["txtEnd"] = "";
            }
            else
            {
                ViewState["txtEnd"] = txtEndDate.Text.Trim();
            }

            BindGrid();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int[] selections = Grid1.SelectedRowIndexArray;
            foreach (int rowIndex in selections)
            {
                sb.Append("'" + Grid1.DataKeys[rowIndex][0].ToString() + "',");
            }
            bool rs = manage.DeleteList(sb.ToString().Remove(sb.ToString().LastIndexOf(",")));
            if (rs != false)
            {
                Alert.ShowInParent("提交成功");
                BindGrid();
            }
            else
            {
                Alert.ShowInParent("提交失败");
            }
        }

        protected void btnApproval_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int[] selections = Grid1.SelectedRowIndexArray;
            foreach (int rowIndex in selections)
            {
                sb.Append("'" + Grid1.DataKeys[rowIndex][0].ToString() + "',");
            }
            bool rs = manage.UpdateStatusList(sb.ToString().Remove(sb.ToString().LastIndexOf(",")));
            if (rs != false)
            {
                Alert.ShowInParent("提交成功");
                BindGrid();
            }
            else
            {
                Alert.ShowInParent("提交失败");
            }
        }

        protected void windowSourceCode_Close(object sender, EventArgs e)
        {
            BindGrid();
        }

    }
}