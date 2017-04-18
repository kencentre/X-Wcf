using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Notice
{
    public partial class SearchList : BasePage
    {
        DataSet source;
        E_Model.Notice model = new E_Model.Notice();
        E_BLL.Notice manage = new E_BLL.Notice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


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
    }
}