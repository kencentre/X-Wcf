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
	/// <summary>
	/// NOTICE
	/// </summary>
	public  class Notice:E_IDAL.INotice
	{
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Notice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_NOTICE(");
            strSql.Append("ID,TITLE,KEYWORD,DESCRIPTION,STATUS,ANNEXGROUP,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append("@ID,@TITLE,@KEYWORD,@DESCRIPTION,@STATUS,@ANNEXGROUP,@CREATEDATE,@CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            db.AddInParameter(dbCommand, "TITLE", DbType.String, model.TITLE);
            db.AddInParameter(dbCommand, "KEYWORD", DbType.String, model.KEYWORD);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "STATUS", DbType.String, model.STATUS);
            db.AddInParameter(dbCommand, "ANNEXGROUP", DbType.String, model.ANNEXGROUP);
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
        public bool Update(E_Model.Notice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_NOTICE set ");
            strSql.Append("TITLE=@TITLE,");
            strSql.Append("KEYWORD=@KEYWORD,");
            strSql.Append("DESCRIPTION=@DESCRIPTION");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "TITLE", DbType.String, model.TITLE);
            db.AddInParameter(dbCommand, "KEYWORD", DbType.String, model.KEYWORD);
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
            strSql.Append("delete from SYS_NOTICE ");
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
            strSql.Append("delete from SYS_NOTICE ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Model.Notice GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_NOTICE ");
            strSql.Append(" where ID='" + ID + "' ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            DataSet DS = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            E_Model.Notice model = new E_Model.Notice();
            if (DS.Tables[0].Rows.Count == 1)
            {
                model.ID = DS.Tables[0].Rows[0]["ID"].ToString();
                model.TITLE = DS.Tables[0].Rows[0]["TITLE"].ToString();
                model.KEYWORD = DS.Tables[0].Rows[0]["KEYWORD"].ToString();
                model.DESCRIPTION = DS.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                model.ANNEXGROUP = DS.Tables[0].Rows[0]["ANNEXGROUP"].ToString();

                model.STATUS = DS.Tables[0].Rows[0]["STATUS"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM SYS_NOTICE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" order by createdate desc ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<E_Model.Notice> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SYS_NOTICE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Notice> list = new List<E_Model.Notice>();
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
        public E_Model.Notice ReaderBind(IDataReader dataReader)
        {
            E_Model.Notice model = new E_Model.Notice();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.TITLE = dataReader["TITLE"].ToString();
            model.KEYWORD = dataReader["KEYWORD"].ToString();
            model.DESCRIPTION = dataReader["DESCRIPTION"].ToString();

            model.STATUS = dataReader["STATUS"].ToString();
            model.ANNEXGROUP = dataReader["ANNEXGROUP"].ToString();
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
            strSql.Append("update SYS_NOTICE set ");
            if (Status == 0)
            {
                strSql.Append(" STATUS  = '1'");
            }
            else
            {
                strSql.Append(" STATUS = '0'");
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
            strSql.Append("update SYS_NOTICE set ");
            strSql.Append(" STATUS = '1' ");
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
            strSql.Append("select * ");
            strSql.Append(" FROM SYS_NOTICE where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  (SYS_NOTICE.TITLE like '%" + strWhere + "%' or SYS_NOTICE.KEYWORD like '%" + strWhere + "%' )");
            }
            if (startDate != "" && endDate == "")
            {
                strSql.Append(" and SYS_NOTICE.createdate between to_date('" + startDate + " 00:00:00','yyyy-MM-dd hh24:mi:ss') and to_date('" + DateTime.Now.ToShortDateString() + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            if (startDate == "" && endDate != "")
            {
                strSql.Append(" and SYS_NOTICE.createdate < to_date('" + DateTime.Now.ToShortDateString() + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            if (startDate != "" && endDate != "")
            {
                strSql.Append(" and SYS_NOTICE.createdate between to_date('" + startDate + " 00:00:00','yyyy-MM-dd E_Model.School') and to_date('" + endDate + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            strSql.Append(" order by  SYS_NOTICE.createdate desc");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public DataSet GetTopList(string strWhere, int rowNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top "+ rowNum + " *  FROM SYS_NOTICE where status = '1' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("  and  (SYS_NOTICE.TITLE like '%" + strWhere + "%' or SYS_NOTICE.KEYWORD like '%" + strWhere + "%' ) ");
            }

            strSql.Append("  order by createdate desc ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        #endregion  Method
    }
}

