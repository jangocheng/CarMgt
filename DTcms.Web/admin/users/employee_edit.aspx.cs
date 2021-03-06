﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.users
{
    public partial class employee_edit : DTcms.Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.manager().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                BLL.user_deptbll deptbll = new BLL.user_deptbll();
                DataTable depttb = deptbll.GetList(1000, "", " id").Tables[0];
                this.ddlDept.Items.Clear();
                this.ddlDept.Items.Add(new ListItem("请选择部门...", ""));
                foreach (DataRow dr in depttb.Rows)
                {
                    this.ddlDept.Items.Add(new ListItem(dr["Dept_Name"].ToString(), dr["Dept_Code"].ToString()));
                }
                BLL.user_rolebll rolebll = new BLL.user_rolebll();
                DataTable roletb = rolebll.GetList(1000, "", " id").Tables[0];
                this.ddlRole.Items.Clear();
                this.ddlRole.Items.Add(new ListItem("请选择职位...", ""));
                foreach (DataRow dr in roletb.Rows)
                {
                    this.ddlRole.Items.Add(new ListItem(dr["Role_Name"].ToString(), dr["Role_Code"].ToString()));
                }
                //取得员工信息
                Model.manager model = GetAdminInfo();
                TreeBind(ddlRoleId, model.role_type);
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.manager bll = new BLL.manager();
            Model.manager model = bll.GetModel(_id);
            //if (model.role_id.ToString()=="0") 
            //{
            //    ddlRoleId.SelectedIndex =0;
            //}
            //else 
            //{
                ddlRoleId.SelectedValue = model.role_id.ToString();
            //}

            rblIsLock.SelectedValue = model.is_lock.ToString();
            ddlDept.SelectedValue = model.DeptInfo.Dept_Code;
            ddlRole.SelectedValue = model.RoleInfo.Role_Code;
            txtUserName.Text = model.user_name;
            txtUserName.ReadOnly = true;
            if (!string.IsNullOrEmpty(model.user_pwd))
            {
                txtUserPwd.Attributes["value"] = txtUserPwd1.Attributes["value"] = defaultpassword;
            }
            txtRealName.Text = model.real_name;
            txtTelephone.Text = model.telephone;
            txtEmail.Text = model.email;
        }
        #endregion

        #region 绑定模型=================================
        private void TreeBind(DropDownList ddl, int role_type)
        {
            BLL.manager_role bll = new BLL.manager_role();
            DataTable dt = bll.GetList("").Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择角色...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["role_type"]) >= role_type)
                {
                    ddl.Items.Add(new ListItem(dr["role_name"].ToString(), dr["id"].ToString()));
                }
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.manager model = new Model.manager();
            BLL.manager bll = new BLL.manager();
            if (ddlRoleId.SelectedIndex == 0)
            {
                model.role_id = 3;
                model.role_type = 2;
            }
            else
            {
                model.role_id = int.Parse(ddlRoleId.SelectedValue);
                model.role_type = new BLL.manager_role().GetModel(model.role_id).role_type;
            }
            model.is_lock = int.Parse(rblIsLock.SelectedValue);
            model.DeptInfo = new Model.user_deptinfo();
            model.DeptInfo.Dept_Code = ddlDept.SelectedValue;
            model.RoleInfo = new Model.user_roleinfo();
            model.RoleInfo.Role_Code = ddlRole.SelectedValue;
            if (txtUserName.Text.Trim()=="")
            {
                model.user_name = Hz2Py.Convert(this.txtRealName.Text.Trim());
            }
            else
            {
                model.user_name = txtUserName.Text.Trim();
            }
            model.user_pwd = DESEncrypt.Encrypt(txtUserPwd.Text.Trim());
            model.real_name = txtRealName.Text.Trim();
            model.telephone = txtTelephone.Text.Trim();
            model.email = txtEmail.Text.Trim();
            model.add_time = DateTime.Now;

            if (bll.Add(model) < 1)
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = true;
            BLL.manager bll = new BLL.manager();
            Model.manager model = bll.GetModel(_id);
            if (ddlRoleId.SelectedIndex == 0)
            {
                model.role_id = 3;
                model.role_type = 2;
            }
            else
            {
                model.role_id = int.Parse(ddlRoleId.SelectedValue);
                model.role_type = new BLL.manager_role().GetModel(model.role_id).role_type;
            }
            model.is_lock = int.Parse(rblIsLock.SelectedValue);
            model.DeptInfo = new Model.user_deptinfo();
            model.DeptInfo.Dept_Code = ddlDept.SelectedValue;
            model.RoleInfo = new Model.user_roleinfo();
            model.RoleInfo.Role_Code = ddlRole.SelectedValue;
            if (txtUserName.Text.Trim() == "")
            {
                model.user_name = Hz2Py.Convert(this.txtRealName.Text.Trim());
            }
            else
            {
                model.user_name = txtUserName.Text.Trim();
            }
            //判断密码是否更改
            if (txtUserPwd.Text.Trim() != defaultpassword)
            {
                model.user_pwd = DESEncrypt.Encrypt(txtUserPwd.Text.Trim());
            }
            model.real_name = txtRealName.Text.Trim();
            model.telephone = txtTelephone.Text.Trim();
            model.email = txtEmail.Text.Trim();

            if (!bll.Update(model))
            {
                result = false;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("sys_manager", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改员工成功啦！", "employee_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("sys_manager", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加员工成功啦！", "employee_list.aspx", "Success");
            }
        }

    }
}