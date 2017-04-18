using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
namespace X_Wcf.Administrator.BasePlatform.Dept
{
    public partial class Default : BasePage
    {
        DataSet source;
        E_Model.Dept model = new E_Model.Dept();
        E_BLL.Dept manage = new E_BLL.Dept();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = windowSourceCode.GetShowReference("Add.aspx", "添加部门信息", 600, 400);
                btnDelete.OnClientClick = windowSourceCode.GetShowReference("Delete.aspx", "删除部门信息", 600, 500);

            }

            InitTree();
        }
        private void InitTree()
        {
            tvList.Nodes.Clear();

            InitDept("00000000-0000-0000-0000-000000000000", tvList, (FineUI.TreeNode)null, windowSourceCode);
        }

        protected void tvList_NodeCommand(object sender, FineUI.TreeCommandEventArgs e)
        {
            txtID.Text = e.Node.NodeID;
            ViewState["DeptInfo"] = e.Node.NodeID;
            Bind(e.Node.NodeID);
            btnEdit.OnClientClick = windowSourceCode.GetShowReference("Modify.aspx?id=" + txtID.Text, "修改部门信息", 600, 400);
            //BindGrid();
        }

        private void Bind(string ID)
        {
            model = manage.GetModel(ID);
            txtDeptName.Text = model.DEPTNAME;
            txtID.Text = model.ID;
            txtParent.Text = model.PARENTID;
            txtDeptCode.Text = model.DEPTCODE;
            txtDescription.Text = model.DESCRIPTION;
            txtDeptList.Text = model.SORTLIST.ToString();
            if (model.PARENTID != null)
            {
                model = new E_Model.Dept();
                txtParentID.Text = manage.GetModel(txtParent.Text).DEPTNAME;
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
            source = new DataSet();
            source = manage.GetAccountListByDeptID(ViewState["DeptInfo"].ToString());
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
    }
}