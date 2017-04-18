using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Account
{
    public partial class Modify : BasePage
    {
        DataSet ds = new DataSet();
        E_BLL.Account manage = new E_BLL.Account();
        E_Model.Account model = new E_Model.Account();
        E_BLL.Duty mDuty = new E_BLL.Duty();
        E_BLL.Role mRole = new E_BLL.Role();
        E_BLL.Code mCode = new E_BLL.Code();
        E_Model.Code CModel = new E_Model.Code();
        E_BLL.AccountDuty mAccountDuty = new E_BLL.AccountDuty();
        E_Model.AccountDuty AccountDutyModel = new E_Model.AccountDuty();
        E_BLL.AccountRole mAccountRole = new E_BLL.AccountRole();
        E_Model.AccountRole AccountRoleModel = new E_Model.AccountRole();
        E_BLL.Dept mDept = new E_BLL.Dept();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDept.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtDept.ClientID, txtDeptCode.ClientID) + windowSourceCode.GetShowReference("../tools/DeptChoose.aspx", "选择部门");
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                Bind();
            }
        }

        private void Bind()
        {
            model = manage.GetModel(Request["ID"].ToString());
            txtUserName.Text = model.USERNAME;
            txtUserCode.Text = model.USERCODE;
            txtDeptCode.Text = model.DEPT;
            txtDept.Text = mDept.GetModel(model.DEPT).DEPTNAME;
            txtAdress.Text = model.ADRESS;
            txtDescription.Text = model.DESCRIPTION;
            txtIDCard.Text = model.EMAIL;
            txtMail.Text = model.EMAIL;
            txtPhone.Text = model.PHONE;
            txtTrueName.Text = model.TRUENAME;

            ds = new DataSet();
            ds = mDuty.GetList(" status = 1");
            ddlDuty.DataSource = ds.Tables[0].DefaultView;
            ddlDuty.DataTextField = "DutyName";
            ddlDuty.DataValueField = "ID";
            ddlDuty.DataBind();

            DataSet source = new DataSet();
            source = mAccountDuty.GetList(" accountid = '" + Request["ID"].ToString() + "'");
            if (source.Tables[0].Rows.Count > 0)
            {
                foreach (FineUI.ListItem DutyItem in ddlDuty.Items)
                {
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        if (source.Tables[0].Rows[i]["DUTYID"].ToString() == DutyItem.Value)
                        {
                            DutyItem.Selected = true;
                        }
                    }
                }
            }

            ds = new DataSet();
            ds = mRole.GetList(" status = 1");
            ddlRole.DataSource = ds.Tables[0].DefaultView;
            ddlRole.DataTextField = "RoleName";
            ddlRole.DataValueField = "ID";
            ddlRole.DataBind();

            source = new DataSet();
            source = mAccountRole.GetList(" accountid = '" + Request["ID"].ToString() + "'");
            if (source.Tables[0].Rows.Count > 0)
            {
                foreach (FineUI.ListItem RoleItem in ddlRole.Items)
                {
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        if (source.Tables[0].Rows[i]["ROLEID"].ToString() == RoleItem.Value)
                        {
                            RoleItem.Selected = true;
                        }
                    }
                }
            }
        }

        protected void txtUserCode_TriggerClick(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds = mCode.GetTopId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                CModel.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString()) + 1;
                CModel.CODE = int.Parse(ds.Tables[0].Rows[0]["CODE"].ToString()) + 1;
                bool rs = mCode.Add(CModel);
                if (rs != false)
                {
                    ViewState["CODE"] = rs;
                    txtUserCode.Text = mCode.CreateCode(CModel.CODE);
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                Alert.ShowInTop("用户帐号不能为空");
                return;
            }
            if (txtUserCode.Text.Trim() == "")
            {
                Alert.ShowInTop("用户工号不能为空");
                return;
            }
            if (ddlDuty.SelectedItemArray.Length == 0)
            {
                Alert.ShowInTop("用户职务不能为空");
                return;
            }
            if (txtDeptCode.Text.Trim() == "")
            {
                Alert.ShowInTop("请选择用户所在部门");
                return;
            }
            if (ddlRole.SelectedItemArray.Length == 0)
            {
                Alert.ShowInTop("请选择用户角色");
                return;
            }
            if (txtTrueName.Text.Trim() == "")
            {
                Alert.ShowInTop("真实姓名不能为空");
                return;
            }
            if (txtIDCard.Text.Trim() != "")
            {
                if (E_Common.IDCardValid.CheckIDCard(txtIDCard.Text.Trim()) == false)
                {
                    Alert.ShowInTop("请输入正确的身份证号码");
                    return;
                }
            }
            if (txtPhone.Text.Trim() == "")
            {
                Alert.ShowInTop("联系电话不能为空");
                return;
            }
            if (E_Common.FormValidate.IsPhone(txtPhone.Text.Trim()) == false)
            {
                Alert.ShowInTop("请输入正确的电话号码");
                return;
            }
            if (txtMail.Text.Trim() != "")
            {
                if (E_Common.FormValidate.IsEmail(txtMail.Text.Trim()) == false)
                {
                    Alert.ShowInTop("请输入正确的电子邮箱");
                    return;
                }
            }
            model.ID = Request["ID"].ToString();
            model.USERCODE = txtUserCode.Text;
            model.USERNAME = txtUserName.Text;
            model.PASSWORDS = E_Common.DEScrypt.Base64Encrypt("888888");
            model.TRUENAME = txtTrueName.Text;
            model.STATUS = 1;
            model.PHONE = txtPhone.Text;
            model.IDCARD = txtIDCard.Text;
            model.ADRESS = txtAdress.Text;
            model.CREATEDATE = DateTime.Now;
            model.CREATEUSER = "";
            model.DESCRIPTION = txtDescription.Text;
            model.DEPT = txtDeptCode.Text;
            bool rs = manage.Update(model);
            if (rs != false)
            {
                mAccountDuty.Delete(Request["ID"].ToString());
                ///写入帐号职务信息
                foreach (FineUI.ListItem DutyItem in ddlDuty.SelectedItemArray)
                {
                    AccountDutyModel.ACCOUNTID = model.ID;
                    AccountDutyModel.DUTYID = DutyItem.Value;
                    mAccountDuty.Add(AccountDutyModel);
                }
                mAccountRole.Delete(Request["ID"].ToString());
                ///写入帐号角色信息
                foreach (FineUI.ListItem RoleItem in ddlRole.SelectedItemArray)
                {
                    AccountRoleModel.ACCOUNTID = model.ID;
                    AccountRoleModel.ROLEID = RoleItem.Value;
                    mAccountRole.Add(AccountRoleModel);
                    //item.Text;
                    //item.Value;
                }
                Alert.ShowInParent("保存成功。", string.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInParent("提交失败");
            }
        }
    }
}