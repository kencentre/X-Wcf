using E_Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OracleDAL
{
    public class Duty: E_IDAL.IDuty
    {
        public Duty()
        { }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(E_Model.Duty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_DUTY(");
            strSql.Append("ID,DUTYNAME,DUTYCODE,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append(":ID,:DUTYNAME,:DUTYCODE,:SORTLIST,:STATUS,:DESCRIPTION,:CREATEDATE,:CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            db.AddInParameter(dbCommand, "DUTYNAME", DbType.String, model.DUTYNAME);
            db.AddInParameter(dbCommand, "DUTYCODE", DbType.String, model.DUTYCODE);
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
        public bool Update(E_Model.Duty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_DUTY set ");
            strSql.Append("ID=:ID,");
            strSql.Append("DUTYNAME=:DUTYNAME,");
            strSql.Append("DUTYCODE=:DUTYCODE,");
            strSql.Append("SORTLIST=:SORTLIST,");
            strSql.Append("DESCRIPTION=:DESCRIPTION");
            strSql.Append(" where ID=:ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            db.AddInParameter(dbCommand, "DUTYNAME", DbType.String, model.DUTYNAME);
            db.AddInParameter(dbCommand, "DUTYCODE", DbType.String, model.DUTYCODE);
            db.AddInParameter(dbCommand, "SORTLIST", DbType.Decimal, model.SORTLIST);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
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
            strSql.Append("delete from SYS_DUTY ");
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
            strSql.Append("delete from SYS_DUTY ");
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
        public E_Model.Duty GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,DUTYNAME,DUTYCODE,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER from SYS_DUTY ");
            strSql.Append(" where ID='" + ID + "'");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            DataSet DS = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            E_Model.Duty model = new E_Model.Duty();
            if (DS.Tables[0].Rows.Count == 1)
            {
                model.ID = DS.Tables[0].Rows[0]["ID"].ToString();
                model.DUTYNAME = DS.Tables[0].Rows[0]["DUTYNAME"].ToString();
                model.DUTYCODE = DS.Tables[0].Rows[0]["DUTYCODE"].ToString();
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
            strSql.Append("select ID,DUTYNAME,DUTYCODE,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_DUTY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by  SORTLIST");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public DataSet GetSearchList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,DUTYNAME,DUTYCODE,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_DUTY  where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  DUTYNAME like '%" + strWhere + "%' or DUTYCODE like '%" + strWhere + "%'");
            }
            strSql.Append(" order by  SORTLIST");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<E_Model.Duty> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,DUTYNAME,DUTYCODE,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_DUTY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Duty> list = new List<E_Model.Duty>();
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
        public E_Model.Duty ReaderBind(IDataReader dataReader)
        {
            E_Model.Duty model = new E_Model.Duty();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.DUTYNAME = dataReader["DUTYNAME"].ToString();
            model.DUTYCODE = dataReader["DUTYCODE"].ToString();
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
            strSql.Append("update SYS_DUTY set ");
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
            strSql.Append("update SYS_DUTY set ");
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

        public DataSet GetUserListByDutyID(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * from sys_desk ");
            strSql.Append(" ");
            strSql.Append(" where 1=1 ");
            if (ID != "")
            {
                strSql.Append(" and createuser ='" + ID + "'");
            }
            strSql.Append(" order by  createdate desc ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
    }
}
