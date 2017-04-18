using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using E_IDAL;
using E_Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace OracleDAL
{
    public class Account : E_IDAL.IAccount
    {
        public Account()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Account model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ACCOUNT(");
            strSql.Append("ID,USERCODE,USERNAME,PASSWORDS,DEPT,TRUENAME,IDCARD,EMAIL,PHONE,ADRESS,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append(":ID,:USERCODE,:USERNAME,:PASSWORDS,:DEPT,:TRUENAME,:IDCARD,:EMAIL,:PHONE,:ADRESS,:DESCRIPTION,:STATUS,:CREATEDATE,:CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            db.AddInParameter(dbCommand, "USERCODE", DbType.String, model.USERCODE);
            db.AddInParameter(dbCommand, "USERNAME", DbType.String, model.USERNAME);
            db.AddInParameter(dbCommand, "PASSWORDS", DbType.String, model.PASSWORDS);
            db.AddInParameter(dbCommand, "DEPT", DbType.String, model.DEPT);
            db.AddInParameter(dbCommand, "TRUENAME", DbType.String, model.TRUENAME);
            db.AddInParameter(dbCommand, "IDCARD", DbType.String, model.IDCARD);
            db.AddInParameter(dbCommand, "EMAIL", DbType.String, model.EMAIL);
            db.AddInParameter(dbCommand, "PHONE", DbType.String, model.PHONE);
            db.AddInParameter(dbCommand, "ADRESS", DbType.String, model.ADRESS);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "STATUS", DbType.Decimal, model.STATUS);
            db.AddInParameter(dbCommand, "CREATEDATE", DbType.DateTime, model.CREATEDATE);
            db.AddInParameter(dbCommand, "CREATEUSER", DbType.String, model.CREATEUSER);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_Model.Account model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ACCOUNT set ");
            strSql.Append("DEPT=:DEPT,");
            strSql.Append("TRUENAME=:TRUENAME,");
            strSql.Append("IDCARD=:IDCARD,");
            strSql.Append("EMAIL=:EMAIL,");
            strSql.Append("PHONE=:PHONE,");
            strSql.Append("ADRESS=:ADRESS,");
            strSql.Append("DESCRIPTION=:DESCRIPTION ");
            strSql.Append(" where ID=:ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "DEPT", DbType.String, model.DEPT);
            db.AddInParameter(dbCommand, "TRUENAME", DbType.String, model.TRUENAME);
            db.AddInParameter(dbCommand, "IDCARD", DbType.String, model.IDCARD);
            db.AddInParameter(dbCommand, "EMAIL", DbType.String, model.EMAIL);
            db.AddInParameter(dbCommand, "PHONE", DbType.String, model.PHONE);
            db.AddInParameter(dbCommand, "ADRESS", DbType.String, model.ADRESS);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_ACCOUNT ");
            strSql.Append(" where ID=:ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, ID);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_ACCOUNT ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, IDlist);
            int rows = db.ExecuteNonQuery(dbCommand);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Model.Account GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,USERCODE,USERNAME,PASSWORDS,DEPT,TRUENAME,IDCARD,EMAIL,PHONE,ADRESS,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER from SYS_ACCOUNT ");
            strSql.Append(" where ID= '" + ID + "' ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            DataSet DS = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            E_Model.Account model = new E_Model.Account();
            if (DS.Tables[0].Rows.Count == 1)
            {
                model.ID = DS.Tables[0].Rows[0]["ID"].ToString();
                model.USERCODE = DS.Tables[0].Rows[0]["USERCODE"].ToString();
                model.USERNAME = DS.Tables[0].Rows[0]["USERNAME"].ToString();
                model.PASSWORDS = DS.Tables[0].Rows[0]["PASSWORDS"].ToString();
                model.DEPT = DS.Tables[0].Rows[0]["DEPT"].ToString();
                model.TRUENAME = DS.Tables[0].Rows[0]["TRUENAME"].ToString();
                model.IDCARD = DS.Tables[0].Rows[0]["IDCARD"].ToString();
                model.EMAIL = DS.Tables[0].Rows[0]["EMAIL"].ToString();
                model.PHONE = DS.Tables[0].Rows[0]["PHONE"].ToString();
                model.ADRESS = DS.Tables[0].Rows[0]["ADRESS"].ToString();
                model.DESCRIPTION = DS.Tables[0].Rows[0]["DESCRIPTION"].ToString();

                if (model.STATUS != null)
                {
                    model.STATUS = decimal.Parse(DS.Tables[0].Rows[0]["STATUS"].ToString());
                }
                if (model.CREATEDATE != null)
                {
                    model.CREATEDATE = DateTime.Parse(DS.Tables[0].Rows[0]["CREATEDATE"].ToString());
                }
                model.CREATEUSER = DS.Tables[0].Rows[0]["CREATEUSER"].ToString();
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Model.Account DataRowToModel(DataRow row)
        {
            E_Model.Account model = new E_Model.Account();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["USERCODE"] != null)
                {
                    model.USERCODE = row["USERCODE"].ToString();
                }
                if (row["USERNAME"] != null)
                {
                    model.USERNAME = row["USERNAME"].ToString();
                }
                if (row["PASSWORDS"] != null)
                {
                    model.PASSWORDS = row["PASSWORDS"].ToString();
                }
                if (row["DEPT"] != null)
                {
                    model.DEPT = row["DEPT"].ToString();
                }
                if (row["TRUENAME"] != null)
                {
                    model.TRUENAME = row["TRUENAME"].ToString();
                }
                if (row["IDCARD"] != null)
                {
                    model.IDCARD = row["IDCARD"].ToString();
                }
                if (row["EMAIL"] != null)
                {
                    model.EMAIL = row["EMAIL"].ToString();
                }
                if (row["PHONE"] != null)
                {
                    model.PHONE = row["PHONE"].ToString();
                }
                if (row["ADRESS"] != null)
                {
                    model.ADRESS = row["ADRESS"].ToString();
                }
                //model.DESCRIPTION=row["DESCRIPTION"].ToString();
                if (row["STATUS"] != null && row["STATUS"].ToString() != "")
                {
                    model.STATUS = decimal.Parse(row["STATUS"].ToString());
                }
                if (row["CREATEDATE"] != null && row["CREATEDATE"].ToString() != "")
                {
                    model.CREATEDATE = DateTime.Parse(row["CREATEDATE"].ToString());
                }
                if (row["CREATEUSER"] != null)
                {
                    model.CREATEUSER = row["CREATEUSER"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,USERCODE,USERNAME,PASSWORDS,DEPT,TRUENAME,IDCARD,EMAIL,PHONE,ADRESS,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_ACCOUNT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CREATEDATE desc");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }



        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<E_Model.Account> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,USERCODE,USERNAME,PASSWORDS,DEPT,TRUENAME,IDCARD,EMAIL,PHONE,ADRESS,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_ACCOUNT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Account> list = new List<E_Model.Account>();
            Database db = DatabaseFactory.CreateDatabase();
            using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public E_Model.Account ReaderBind(IDataReader dataReader)
        {
            E_Model.Account model = new E_Model.Account();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.USERCODE = dataReader["USERCODE"].ToString();
            model.USERNAME = dataReader["USERNAME"].ToString();
            model.PASSWORDS = dataReader["PASSWORDS"].ToString();
            model.DEPT = dataReader["DEPT"].ToString();
            model.TRUENAME = dataReader["TRUENAME"].ToString();
            model.IDCARD = dataReader["IDCARD"].ToString();
            model.EMAIL = dataReader["EMAIL"].ToString();
            model.PHONE = dataReader["PHONE"].ToString();
            model.ADRESS = dataReader["ADRESS"].ToString();
            model.DESCRIPTION = dataReader["DESCRIPTION"].ToString();

            ojb = dataReader["STATUS"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.STATUS = (decimal)ojb;
            }
            ojb = dataReader["CREATEDATE"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CREATEDATE = (DateTime)ojb;
            }
            model.CREATEUSER = dataReader["CREATEUSER"].ToString();
            return model;
        }

        public bool UpdateStatus(string ID, decimal Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ACCOUNT set ");
            if (Status == 0)
            {
                strSql.Append(" STATUS  = 1");
            }
            else
            {
                strSql.Append(" STATUS = 0");
            }

            strSql.Append(" where ID  = '" + ID + "' ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateStatusList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ACCOUNT set ");
            strSql.Append(" STATUS = 1 ");
            strSql.Append(" where ID  in (" + IDlist + ") ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataSet GetSearchList(string strWhere, string startDate, string endDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sys_account.*,sys_dept.deptname ");
            strSql.Append(" FROM sys_account left join  sys_dept on sys_account.DEPT = sys_dept.id  where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  (sys_account.USERCODE like '%" + strWhere + "%' or sys_account.USERNAME like '%" + strWhere + "%' or sys_account.TRUENAME like '%" + strWhere + "%')");
            }
            if (startDate != "" && endDate == "")
            {
                strSql.Append(" and sys_Account.createdate between to_date('" + startDate + " 00:00:00','yyyy-MM-dd hh24:mi:ss') and to_date('" + DateTime.Now.ToShortDateString() + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            if (startDate == "" && endDate != "")
            {
                strSql.Append(" and sys_Account.createdate < to_date('" + DateTime.Now.ToShortDateString() + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            if (startDate != "" && endDate != "")
            {
                strSql.Append(" and sys_Account.createdate between to_date('" + startDate + " 00:00:00','yyyy-MM-dd hh24:mi:ss') and to_date('" + endDate + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            strSql.Append(" order by  sys_account.Createdate desc");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public bool UpdateUserInfo(E_Model.Account model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ACCOUNT set ");
            strSql.Append("IDCARD=:IDCARD,");
            strSql.Append("EMAIL=:EMAIL,");
            strSql.Append("PHONE=:PHONE,");
            strSql.Append("ADRESS=:ADRESS,");
            strSql.Append("DESCRIPTION=:DESCRIPTION ");
            strSql.Append(" where ID=:ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "IDCARD", DbType.String, model.IDCARD);
            db.AddInParameter(dbCommand, "EMAIL", DbType.String, model.EMAIL);
            db.AddInParameter(dbCommand, "PHONE", DbType.String, model.PHONE);
            db.AddInParameter(dbCommand, "ADRESS", DbType.String, model.ADRESS);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePwd(E_Model.Account model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ACCOUNT set ");
            strSql.Append("PASSWORDS=:PASSWORDS");
            strSql.Append(" where ID=:ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "PASSWORDS", DbType.String, model.PASSWORDS);
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AccountLogin(string UserName, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM SYS_ACCOUNT where (USERCODE = '" + UserName + "' or USERNAME ='" + UserName + "') and PASSWORDS = '" + Password + "'");
            Database db = DatabaseFactory.CreateDatabase();
            DataSet ds = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            if (ds.Tables[0].Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ResetPwd(E_Model.Account model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ACCOUNT set ");
            strSql.Append("PASSWORDS=:PASSWORDS");
            strSql.Append(" where ID=:ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "PASSWORDS", DbType.String, model.PASSWORDS);
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataSet GetAccountMainList(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct Sys_Main.MainName,Sys_Main.MAINURL,Sys_Main.SORTLIST,Sys_Main.PARENTID , Sys_Main.ID,Sys_Main.MainIcon");
            strSql.Append(" from Sys_Main left join SYS_MAIN_ROLE on Sys_Main.ID = SYS_MAIN_ROLE.MainID");
            strSql.Append(" left join Sys_Role on SYS_MAIN_ROLE.RoleID = Sys_Role.ID");
            strSql.Append(" left join SYS_ACCOUNT_ROLE on SYS_ACCOUNT_ROLE.RoleID = Sys_Role.ID");
            strSql.Append(" where SYS_ACCOUNT_ROLE.AccountID = '" + ID + "'");
            strSql.Append(" group by Sys_Main.MainName,Sys_Main.SortList,Sys_Main.MainUrl,Sys_Main.SortList,Sys_Main.ParentID, Sys_Main.ID,Sys_Main.MainIcon");
            strSql.Append(" order by Sys_Main.SortList ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public DataSet GetAccountMainListByPID(string ID, string ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct Sys_Main.MainName,Sys_Main.MAINURL,Sys_Main.SORTLIST,Sys_Main.PARENTID , Sys_Main.ID,Sys_Main.MainIcon");
            strSql.Append(" from Sys_Main left join SYS_MAIN_ROLE on Sys_Main.ID = SYS_MAIN_ROLE.MainID");
            strSql.Append(" left join Sys_Role on SYS_MAIN_ROLE.RoleID = Sys_Role.ID");
            strSql.Append(" left join SYS_ACCOUNT_ROLE on SYS_ACCOUNT_ROLE.RoleID = Sys_Role.ID");
            strSql.Append(" where SYS_ACCOUNT_ROLE.AccountID = '" + ID + "' and Sys_Main.ParentID = '" + ParentID + "'");
            strSql.Append(" group by Sys_Main.MainName,Sys_Main.SortList,Sys_Main.MainUrl,Sys_Main.SortList,Sys_Main.ParentID, Sys_Main.ID,Sys_Main.MainIcon");
            strSql.Append(" order by Sys_Main.SortList ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }


        #endregion  Method
    }
}
