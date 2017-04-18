﻿using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Duty
{
    public partial class Modify : BasePage
    {
        E_Model.Duty model = new E_Model.Duty();
        E_BLL.Duty manage = new E_BLL.Duty();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                Bind();
            }
        }

        private void Bind()
        {
            model = manage.GetModel(Request["ID"].ToString());
            txtDutyName.Text = model.DUTYNAME;
            txtDutyCode.Text = model.DUTYCODE;
            txtDutyList.Text = model.SORTLIST.ToString();
            txtDescription.Text = model.DESCRIPTION;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDutyName.Text.Trim() == "")
            {
                Alert.Show("职务名称不能为空");
                return;
            }
            if (txtDutyCode.Text.Trim() == "")
            {
                Alert.Show("职务代码不能为空");
                return;
            }
            if (txtDutyList.Text.Trim() == "")
            {
                Alert.Show("请对职务进行排序");
                return;
            }
            if (E_Common.FormValidate.IsNumber(txtDutyList.Text.Trim()) == false)
            {
                Alert.Show("请对输入正确的数字");
                return;
            }
            model.ID = Request["ID"].ToString();
            model.DUTYNAME = txtDutyName.Text;
            model.DUTYCODE = txtDutyCode.Text;
            model.SORTLIST = decimal.Parse(txtDutyList.Text);
            model.DESCRIPTION = txtDescription.Text;
            bool rs = manage.Update(model);
            if (rs != false)
            {
                Alert.ShowInParent("保存成功。", string.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInParent("提交失败");
            }
        }
    }
}