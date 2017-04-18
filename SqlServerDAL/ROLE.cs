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
namespace SqlServerDAL
{
    public class Role:E_IDAL.IRole
    {
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ROLE(");
            strSql.Append("ID,ROLETYPE,ROLENAME,ROLECODE,PARENTID,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append("@ID,@ROLETYPE,@ROLENAME,@ROLECODE,@PARENTID,@SORTLIST,@STATUS,@DESCRIPTION,@CREATEDATE,@CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            db.AddInParameter(dbCommand, "ROLETYPE", DbType.String, model.ROLETYPE);
            db.AddInParameter(dbCommand, "ROLENAME", DbType.String, model.ROLENAME);
            db.AddInParameter(dbCommand, "ROLECODE", DbType.String, model.ROLECODE);
            db.AddInParameter(dbCommand, "PARENTID", DbType.String, model.PARENTID);
            db.AddInParameter(dbCommand, "SORTLIST", DbType.Decimal, model.SORTLIST);
            db.AddInParameter(dbCommand, "STATUS", DbType.Decimal, model.STATUS);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
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
        public bool Update(E_Model.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ROLE set ");
            strSql.Append("ROLETYPE=@ROLETYPE,");
            strSql.Append("ROLENAME=@ROLENAME,");
            strSql.Append("ROLECODE=@ROLECODE,");
            strSql.Append("PARENTID=@PARENTID,");
            strSql.Append("SORTLIST=@SORTLIST ");
            strSql.Append("DESCRIPTION=@DESCRIPTION,");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ROLETYPE", DbType.String, model.ROLETYPE);
            db.AddInParameter(dbCommand, "ROLENAME", DbType.String, model.ROLENAME);
            db.AddInParameter(dbCommand, "ROLECODE", DbType.String, model.ROLECODE);
            db.AddInParameter(dbCommand, "PARENTID", DbType.String, model.PARENTID);
            db.AddInParameter(dbCommand, "SORTLIST", DbType.Decimal, model.SORTLIST);
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
            strSql.Append("delete from SYS_ROLE ");
            strSql.Append(" where ID=@ID ");
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
            strSql.Append("delete from SYS_ROLE ");
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
        public E_Model.Role GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ROLETYPE,ROLENAME,ROLECODE,PARENTID,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER from SYS_ROLE ");
            strSql.Append(" where ID='" + ID + "' ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            DataSet DS = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            E_Model.Role model = new E_Model.Role();
            if (DS.Tables[0].Rows.Count == 1)
            {
                model.ID = DS.Tables[0].Rows[0]["ID"].ToString();
                model.ROLETYPE = DS.Tables[0].Rows[0]["ROLETYPE"].ToString();
                model.ROLENAME = DS.Tables[0].Rows[0]["ROLENAME"].ToString();
                model.ROLECODE = DS.Tables[0].Rows[0]["ROLECODE"].ToString();
                model.PARENTID = DS.Tables[0].Rows[0]["PARENTID"].ToString();
                model.DESCRIPTION = DS.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                if (model.SORTLIST != null)
                {
                    model.SORTLIST = decimal.Parse(DS.Tables[0].Rows[0]["SORTLIST"].ToString());
                }
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ROLETYPE,ROLENAME,ROLECODE,PARENTID,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_ROLE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by SORTLIST");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public DataSet GetSearchList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ROLETYPE,ROLENAME,ROLECODE,PARENTID,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_ROLE  where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  ROLENAME like '%" + strWhere + "%' or ROLECODE like '%" + strWhere + "%'");
            }
            strSql.Append(" order by  SORTLIST");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<E_Model.Role> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ROLETYPE,ROLENAME,ROLECODE,PARENTID,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_ROLE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Role> list = new List<E_Model.Role>();
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
        public E_Model.Role ReaderBind(IDataReader dataReader)
        {
            E_Model.Role model = new E_Model.Role();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.ROLETYPE = dataReader["ROLETYPE"].ToString();
            model.ROLENAME = dataReader["ROLENAME"].ToString();
            model.ROLECODE = dataReader["ROLECODE"].ToString();
            model.PARENTID = dataReader["PARENTID"].ToString();
            ojb = dataReader["SORTLIST"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SORTLIST = (decimal)ojb;
            }
            ojb = dataReader["STATUS"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.STATUS = (decimal)ojb;
            }
            model.DESCRIPTION = dataReader["DESCRIPTION"].ToString();

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
            strSql.Append("update SYS_ROLE set ");
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
            strSql.Append("update SYS_ROLE set ");
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
        #endregion  Method
    }
}
