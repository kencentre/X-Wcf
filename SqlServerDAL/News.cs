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
    public class News : E_IDAL.INews
    {
        public News()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_NEWS(");
            strSql.Append("ID,TITLE,KEYWORDS,CHANNEL,BRANDID,SCHOOLID,IMAGESHOW,NEWSTEXT,NEWSURL,STATUS,CREATEDATE,CREATEUSER,VIDEOSHOW)");

            strSql.Append(" values (");
            strSql.Append("@ID,@TITLE,@KEYWORDS,@CHANNEL,@BRANDID,@SCHOOLID,@IMAGESHOW,@NEWSTEXT,@NEWSURL,@STATUS,@CREATEDATE,@CREATEUSER,@VIDEOSHOW)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, model.ID);
            db.AddInParameter(dbCommand, "TITLE", DbType.AnsiString, model.TITLE);
            db.AddInParameter(dbCommand, "KEYWORDS", DbType.AnsiString, model.KEYWORDS);
            db.AddInParameter(dbCommand, "CHANNEL", DbType.AnsiString, model.CHANNEL);
            db.AddInParameter(dbCommand, "BRANDID", DbType.AnsiString, model.BRANDID);
            db.AddInParameter(dbCommand, "SCHOOLID", DbType.AnsiString, model.SCHOOLID);
            db.AddInParameter(dbCommand, "IMAGESHOW", DbType.AnsiString, model.IMAGESHOW);
            db.AddInParameter(dbCommand, "NEWSTEXT", DbType.AnsiString, model.NEWSTEXT);
            db.AddInParameter(dbCommand, "NEWSURL", DbType.AnsiString, model.NEWSURL);
            db.AddInParameter(dbCommand, "STATUS", DbType.AnsiString, model.STATUS);
            db.AddInParameter(dbCommand, "CREATEDATE", DbType.DateTime, model.CREATEDATE);
            db.AddInParameter(dbCommand, "CREATEUSER", DbType.AnsiString, model.CREATEUSER);
            db.AddInParameter(dbCommand, "VIDEOSHOW", DbType.AnsiString, model.VIDEOSHOW);
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
        public bool Update(E_Model.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_NEWS set ");
            strSql.Append("TITLE=@TITLE,");
            strSql.Append("KEYWORDS=@KEYWORDS,");
            strSql.Append("CHANNEL=@CHANNEL,");
            strSql.Append("BRANDID=@BRANDID,");
            strSql.Append("SCHOOLID=@SCHOOLID,");
            strSql.Append("IMAGESHOW=@IMAGESHOW,");
            strSql.Append("NEWSTEXT=@NEWSTEXT,");
            strSql.Append("NEWSURL=@NEWSURL,");
            strSql.Append("VIDEOSHOW=@VIDEOSHOW ");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "TITLE", DbType.AnsiString, model.TITLE);
            db.AddInParameter(dbCommand, "KEYWORDS", DbType.AnsiString, model.KEYWORDS);
            db.AddInParameter(dbCommand, "CHANNEL", DbType.AnsiString, model.CHANNEL);
            db.AddInParameter(dbCommand, "BRANDID", DbType.AnsiString, model.BRANDID);
            db.AddInParameter(dbCommand, "SCHOOLID", DbType.AnsiString, model.SCHOOLID);
            db.AddInParameter(dbCommand, "IMAGESHOW", DbType.AnsiString, model.IMAGESHOW);
            db.AddInParameter(dbCommand, "NEWSTEXT", DbType.AnsiString, model.NEWSTEXT);
            db.AddInParameter(dbCommand, "NEWSURL", DbType.AnsiString, model.NEWSURL);
            db.AddInParameter(dbCommand, "VIDEOSHOW", DbType.AnsiString, model.VIDEOSHOW);
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
            strSql.Append("delete from CMS_NEWS ");
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
            strSql.Append("delete from CMS_NEWS ");
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
        public E_Model.News GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CMS_NEWS ");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, ID);
            E_Model.News model = null;
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
        public E_Model.News DataRowToModel(DataRow row)
        {
            E_Model.News model = new E_Model.News();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["TITLE"] != null)
                {
                    model.TITLE = row["TITLE"].ToString();
                }
                if (row["KEYWORDS"] != null)
                {
                    model.KEYWORDS = row["KEYWORDS"].ToString();
                }
                if (row["CHANNEL"] != null)
                {
                    model.CHANNEL = row["CHANNEL"].ToString();
                }
                if (row["BRANDID"] != null)
                {
                    model.BRANDID = row["BRANDID"].ToString();
                }
                if (row["SCHOOLID"] != null)
                {
                    model.SCHOOLID = row["SCHOOLID"].ToString();
                }
                if (row["IMAGESHOW"] != null)
                {
                    model.IMAGESHOW = row["IMAGESHOW"].ToString();
                }
                if (row["NEWSTEXT"] != null)
                {
                    model.NEWSTEXT = row["NEWSTEXT"].ToString();
                }
                if (row["NEWSURL"] != null)
                {
                    model.NEWSURL = row["NEWSURL"].ToString();
                }
                if (row["STATUS"] != null)
                {
                    model.STATUS = row["STATUS"].ToString();
                }
                if (row["CREATEDATE"] != null && row["CREATEDATE"].ToString() != "")
                {
                    model.CREATEDATE = DateTime.Parse(row["CREATEDATE"].ToString());
                }
                if (row["CREATEUSER"] != null)
                {
                    model.CREATEUSER = row["CREATEUSER"].ToString();
                }
                if (row["VIDEOSHOW"] != null)
                {
                    model.VIDEOSHOW = row["VIDEOSHOW"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM CMS_NEWS ");
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
            strSql.Append(")AS Row, T.*,X.CHANNELNAME  from CMS_NEWS T left join CMS_NEWSCHANNEL X ON T.CHANNEL = X.ID where 1=1  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND T.TITLE like '%" + strWhere + "%' OR T.KEYWORDS like '%" + strWhere + "%'");
            }
            if (startDate != "" && endDate == "")
            {
                strSql.Append(" and T.CREATEDATE between '" + startDate + " 00:00:00' and '" + DateTime.Now.ToShortDateString() + " 23:59:59'");
            }
            if (startDate == "" && endDate != "")
            {
                strSql.Append(" and T.CREATEDATE < '" + DateTime.Now.ToShortDateString() + " 23:59:59'");
            }
            if (startDate != "" && endDate != "")
            {
                strSql.Append(" and T.CREATEDATE between '" + startDate + " 00:00:00' and '" + endDate + " 23:59:59'");
            }
            strSql.Append(" ) TT");
            if (string.IsNullOrEmpty(startIndex.ToString()) != true && string.IsNullOrEmpty(endIndex.ToString()) != true)
            {
                strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            }
            strSql.Append(" order by TT.CREATEDATE desc, TT.status");
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
        public List<E_Model.News> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CMS_NEWS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.News> list = new List<E_Model.News>();
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
        public E_Model.News ReaderBind(IDataReader dataReader)
        {
            E_Model.News model = new E_Model.News();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.TITLE = dataReader["TITLE"].ToString();
            model.KEYWORDS = dataReader["KEYWORDS"].ToString();
            model.CHANNEL = dataReader["CHANNEL"].ToString();
            model.BRANDID = dataReader["BRANDID"].ToString();
            model.SCHOOLID = dataReader["SCHOOLID"].ToString();
            model.IMAGESHOW = dataReader["IMAGESHOW"].ToString();
            model.NEWSTEXT = dataReader["NEWSTEXT"].ToString();
            model.NEWSURL = dataReader["NEWSURL"].ToString();
            model.STATUS = dataReader["STATUS"].ToString();
            ojb = dataReader["CREATEDATE"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CREATEDATE = (DateTime)ojb;
            }
            model.CREATEUSER = dataReader["CREATEUSER"].ToString();
            model.VIDEOSHOW = dataReader["VIDEOSHOW"].ToString();
            return model;
        }



        public bool UpdateStatus(string ID, string Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_NEWS set ");
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
            strSql.Append("update CMS_NEWS set ");
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

        public DataSet GetTopList(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT top "+top+" * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by CMS_NEWS.CREATEDATE desc");
            strSql.Append(")AS Row, CMS_NEWS.*,CMS_NEWSCHANNEL.CHANNELNAME,CMS_BRAND.BRANDENAME  from CMS_NEWS left join CMS_NEWSCHANNEL  ON CMS_NEWS.CHANNEL = CMS_NEWSCHANNEL.ID LEFT JOIN CMS_BRAND ON CMS_NEWS.BRANDID = CMS_BRAND.ID where 1=1  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND "+strWhere);
            }
            strSql.Append(" ) TT");
            
            strSql.Append(" order by TT.CREATEDATE desc, TT.status");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public DataSet GetSearchList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  T.*,X.CHANNELNAME  from CMS_NEWS T left join CMS_NEWSCHANNEL X ON T.CHANNEL = X.ID where 1=1  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND " + strWhere);
            }

            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }



        public DataSet GetDataTableProc(string sqlWhere, string PageSize, string PageIndex, out string RecordCount)
        {
            DataSet ds;
            StringBuilder strSql;
            strSql = new StringBuilder();
            strSql.Append("SELECT count(ID) as count FROM cms_news ");
            if (sqlWhere != "")
            {
                strSql.Append("  where  " + sqlWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            ds = new DataSet();
            ds = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                RecordCount = ds.Tables[0].Rows[0]["count"].ToString();
            }
            else
            {
                RecordCount = "0";
            }
            strSql = new StringBuilder();
            if (PageIndex == "1")
            {
                strSql.Append("select * from cms_news where 1=1 and ");
                
                if (sqlWhere.Trim() != "")
                {
                    strSql.Append(sqlWhere);
                }
                strSql.Append(" order by createdate desc");
            }
            else
            {
                strSql.Append("SELECT * FROM ( ");
                strSql.Append(" SELECT ROW_NUMBER() OVER (order by T.CREATEDATE");
                strSql.Append(")AS Row, T.*  from CMS_NEWS T ");
                if (sqlWhere.Trim() != "")
                {
                    strSql.Append(" WHERE  " + sqlWhere);
                }
                strSql.Append(" ) TT");
                
                strSql.Append(" WHERE RowNumber BETWEEN (to_number(" + PageIndex + ") - 1) * to_number(" + PageSize + ") + 1 AND to_number(" + PageIndex + ") * to_number(" + PageSize + ")");
            }
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }


        #endregion  Method
    }
}
