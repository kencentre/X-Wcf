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
    public class WebSite : E_IDAL.IWebSite
    {
        public WebSite()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.WebSite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_WEBSITE(");
            strSql.Append("ID,WEBNAME,PARENTID,TEMPLATEID,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER,WEBCODE)");

            strSql.Append(" values (");
            strSql.Append("@ID,@WEBNAME,@PARENTID,@TEMPLATEID,@STATUS,@DESCRIPTION,@CREATEDATE,@CREATEUSER,@WEBCODE)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, model.ID);
            db.AddInParameter(dbCommand, "WEBNAME", DbType.AnsiString, model.WEBNAME);
            db.AddInParameter(dbCommand, "PARENTID", DbType.AnsiString, model.PARENTID);
            db.AddInParameter(dbCommand, "TEMPLATEID", DbType.AnsiString, model.TEMPLATEID);
            db.AddInParameter(dbCommand, "STATUS", DbType.AnsiString, model.STATUS);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.AnsiString, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "CREATEDATE", DbType.DateTime, model.CREATEDATE);
            db.AddInParameter(dbCommand, "CREATEUSER", DbType.AnsiString, model.CREATEUSER);
            db.AddInParameter(dbCommand, "WEBCODE", DbType.AnsiString, model.WEBCODE);
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
        public bool Update(E_Model.WebSite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_WEBSITE set ");
            strSql.Append("WEBNAME=@WEBNAME,");
            strSql.Append("PARENTID=@PARENTID,");
            strSql.Append("TEMPLATEID=@TEMPLATEID,");
            strSql.Append("DESCRIPTION=@DESCRIPTION");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "WEBNAME", DbType.AnsiString, model.WEBNAME);
            db.AddInParameter(dbCommand, "PARENTID", DbType.AnsiString, model.PARENTID);
            db.AddInParameter(dbCommand, "TEMPLATEID", DbType.AnsiString, model.TEMPLATEID);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.AnsiString, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, model.ID);
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
            strSql.Append("delete from CMS_WEBSITE ");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, ID);
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
            strSql.Append("delete from CMS_WEBSITE ");
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
        public E_Model.WebSite GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CMS_WEBSITE ");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, ID);
            E_Model.WebSite model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Model.WebSite DataRowToModel(DataRow row)
        {
            E_Model.WebSite model = new E_Model.WebSite();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["WEBNAME"] != null)
                {
                    model.WEBNAME = row["WEBNAME"].ToString();
                }
                if (row["PARENTID"] != null)
                {
                    model.PARENTID = row["PARENTID"].ToString();
                }
                if (row["TEMPLATEID"] != null)
                {
                    model.TEMPLATEID = row["TEMPLATEID"].ToString();
                }
                if (row["STATUS"] != null)
                {
                    model.STATUS = row["STATUS"].ToString();
                }
                if (row["DESCRIPTION"] != null)
                {
                    model.DESCRIPTION = row["DESCRIPTION"].ToString();
                }
                if (row["CREATEDATE"] != null && row["CREATEDATE"].ToString() != "")
                {
                    model.CREATEDATE = DateTime.Parse(row["CREATEDATE"].ToString());
                }
                if (row["CREATEUSER"] != null)
                {
                    model.CREATEUSER = row["CREATEUSER"].ToString();
                }
                if (row["WEBCODE"] != null)
                {
                    model.WEBCODE = row["WEBCODE"].ToString();
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
            strSql.Append("select * from CMS_WEBSITE ");
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string startDate, string endDate, string startIndex, string endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.CREATEDATE desc");
            strSql.Append(")AS Row, T.*  from CMS_WEBSITE T where 1=1  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND WEBNAME like '%" + strWhere + "%' ");
            }
            if (startDate != "" && endDate == "")
            {
                strSql.Append(" and CREATEDATE between '" + startDate + " 00:00:00' and '" + DateTime.Now.ToShortDateString() + " 23:59:59'");
            }
            if (startDate == "" && endDate != "")
            {
                strSql.Append(" and CREATEDATE < '" + DateTime.Now.ToShortDateString() + " 23:59:59'");
            }
            if (startDate != "" && endDate != "")
            {
                strSql.Append(" and CREATEDATE between '" + startDate + " 00:00:00' and '" + endDate + " 23:59:59'");
            }
            strSql.Append(" ) TT");
            if (string.IsNullOrEmpty(startIndex.ToString()) != true && string.IsNullOrEmpty(endIndex.ToString()) != true)
            {
                strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "CMS_BRAND");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<E_Model.WebSite> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from CMS_WEBSITE ");
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.WebSite> list = new List<E_Model.WebSite>();
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
        public E_Model.WebSite ReaderBind(IDataReader dataReader)
        {
            E_Model.WebSite model = new E_Model.WebSite();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.WEBNAME = dataReader["WEBNAME"].ToString();
            model.PARENTID = dataReader["PARENTID"].ToString();
            model.TEMPLATEID = dataReader["TEMPLATEID"].ToString();
            model.STATUS = dataReader["STATUS"].ToString();
            model.DESCRIPTION = dataReader["DESCRIPTION"].ToString();
            ojb = dataReader["CREATEDATE"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CREATEDATE = (DateTime)ojb;
            }
            model.CREATEUSER = dataReader["CREATEUSER"].ToString();
            model.WEBCODE = dataReader["WEBCODE"].ToString();
            return model;
        }



        public bool UpdateStatus(string ID, string Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_WEBSITE set ");
            if (Status == "0")
            {
                strSql.Append(" STATUS  = '1'");
            }
            else
            {
                strSql.Append(" STATUS = '0' ");
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
            strSql.Append("update CMS_WEBSITE set ");
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

        public DataSet GetSearchList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT	CMS_WEBSITE.WEBCODE,CMS_WEBSITE.ID,	CMS_WEBSITE.PARENTID,	CMS_WEBSITE.WEBNAME,	CMS_TEMPLATE.TEMPLATEURL,	CMS_TEMPLATE.ID AS TEMPLATEID FROM	CMS_WEBSITE ");
            strSql.Append("LEFT JOIN CMS_TEMPLATE ON CMS_WEBSITE.TEMPLATEID = CMS_TEMPLATE.ID WHERE	");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" order by CMS_WEBSITE.CREATEDATE");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        #endregion  Method
    }
}
