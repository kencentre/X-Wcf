using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.Tools
{
    public partial class TemplateChoose : BasePage
    {
        DataSet source;
        E_Model.Template model = new E_Model.Template();
        E_BLL.Template manage = new E_BLL.Template();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
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
        
        protected void Grid1_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                if (e.Values[2].ToString() == "0")
                {
                    e.Values[2] = "<span style='color:red'>停用</span>";
                }
                if (e.Values[2].ToString() == "1")
                {
                    e.Values[2] = "<span style='color:green'>启用</span>";
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


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Grid1.SelectedRowIndex != -1)
            {
                if (Grid1.DataKeys[Grid1.SelectedRowIndex][2].ToString() == "0")
                {
                    Alert.ShowInTop("该模版未启用");
                    return;
                }
                else
                { 
                    PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(Grid1.DataKeys[Grid1.SelectedRowIndex][2].ToString(), Grid1.DataKeys[Grid1.SelectedRowIndex][0].ToString()) + ActiveWindow.GetHideReference());
                }
            }
            else
            {
                Alert.ShowInTop("请选择模版");
                return;
            }
        }
    }
}