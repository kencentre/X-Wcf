using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.CMSPlatform.Code
{
    public partial class Default : BasePage
    {
        DataSet source;
        E_Model.ECode model = new E_Model.ECode();
        E_BLL.ECode manage = new E_BLL.ECode();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = windowSourceCode.GetShowReference("Add.aspx", "添加二维码信息");
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertInTopReference("请至少选择一项！");
                btnDelete.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", Grid1.GetSelectedCountReference());

                btnApproval.OnClientClick = Grid1.GetNoSelectionAlertInTopReference("请至少选择一项！");
                btnApproval.ConfirmText = String.Format("你确定要启用选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", Grid1.GetSelectedCountReference());
                ddlPageSize.SelectedValue = Grid1.PageSize.ToString();
                Bind();


            }
        }

        private int GetTotalCount()
        {
            return InitGrid();
        }

        private int InitGrid()
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
            Grid1.RecordCount = manage.GetListByPage(ViewState["Search"].ToString(), ViewState["txtStart"].ToString(), ViewState["txtEnd"].ToString(), "", "").Tables[0].Rows.Count;
            return Grid1.RecordCount;
        }


        private void Bind()
        {

            Grid1.RecordCount = GetTotalCount();
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

            string startIndex, endIndex;
            if (Grid1.PageIndex == 0)
            {
                startIndex = "1";
                endIndex = ((Grid1.PageIndex + 1) * Grid1.PageSize).ToString();
            }
            else
            {
                startIndex = ((Grid1.PageIndex) * Grid1.PageSize + 1).ToString();
                endIndex = ((Grid1.PageIndex + 1) * Grid1.PageSize).ToString();
            }


            DataSet source1 = new DataSet();
            source1 = manage.GetListByPage(ViewState["Search"].ToString(), ViewState["txtStart"].ToString(), ViewState["txtEnd"].ToString(), startIndex, endIndex);
            Grid1.DataSource = source1;
            Grid1.DataBind();
        }
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            Bind();
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid1.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            Bind();
        }

        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                bool rs = manage.Delete(Grid1.DataKeys[e.RowIndex][0].ToString());
                if (rs != false)
                {
                    Alert.ShowInParent("提交成功");
                    Bind();
                }
                else
                {
                    Alert.ShowInParent("提交失败");
                }
            }
            if (e.CommandName == "Approval")
            {
                bool rs = manage.UpdateStatus(Grid1.DataKeys[e.RowIndex][0].ToString(), Grid1.DataKeys[e.RowIndex][1].ToString());
                if (rs != false)
                {
                    Alert.ShowInParent("提交成功");
                    Bind();
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
                if (e.Values[1].ToString() == "0")
                {
                    e.Values[1] = "<span style='color:red'>停用</span>";
                }
                if (e.Values[1].ToString() == "1")
                {
                    e.Values[1] = "<span style='color:green'>启用</span>";
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

            Bind();
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
                Bind();
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
                Bind();
            }
            else
            {
                Alert.ShowInParent("提交失败");
            }
        }

        protected void windowSourceCode_Close(object sender, EventArgs e)
        {
            Bind();
        }
    }
}