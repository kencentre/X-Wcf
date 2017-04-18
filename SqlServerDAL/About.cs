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
    public class About : E_IDAL.IAbout
    {
        public About()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.About model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_ABOUT(");
            strSql.Append("ID,TITLE,CHANNEL,IMAGESHOW,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER,PATHURL)");

            strSql.Append(" values (");
            strSql.Append("@ID,@TITLE,@CHANNEL,@IMAGESHOW,@DESCRIPTION,@STATUS,@CREATEDATE,@CREATEUSER,@PATHURL)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, model.ID);
            db.AddInParameter(dbCommand, "TITLE", DbType.AnsiString, model.TITLE);
            db.AddInParameter(dbCommand, "CHANNEL", DbType.AnsiString, model.CHANNEL);
            db.AddInParameter(dbCommand, "IMAGESHOW", DbType.AnsiString, model.IMAGESHOW);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.AnsiString, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "STATUS", DbType.AnsiString, model.STATUS);
            db.AddInParameter(dbCommand, "CREATEDATE", DbType.DateTime, model.CREATEDATE);
            db.AddInParameter(dbCommand, "CREATEUSER", DbType.AnsiString, model.CREATEUSER);
            db.AddInParameter(dbCommand, "PATHURL", DbType.AnsiString, model.PATHURL);
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
        public bool Update(E_Model.About model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_ABOUT set ");
            strSql.Append("TITLE=@TITLE,");
            strSql.Append("CHANNEL=@CHANNEL,");
            strSql.Append("IMAGESHOW=@IMAGESHOW,");
            strSql.Append("PATHURL=@PATHURL,");
            strSql.Append("DESCRIPTION=@DESCRIPTION");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "TITLE", DbType.AnsiString, model.TITLE);
            db.AddInParameter(dbCommand, "CHANNEL", DbType.AnsiString, model.CHANNEL);
            db.AddInParameter(dbCommand, "IMAGESHOW", DbType.AnsiString, model.IMAGESHOW);
            db.AddInParameter(dbCommand, "PATHURL", DbType.AnsiString, model.PATHURL);
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
            strSql.Append("delete from CMS_ABOUT ");
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
            strSql.Append("delete from CMS_ABOUT ");
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
        public E_Model.About GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CMS_ABOUT ");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, ID);
            E_Model.About model = null;
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
        public E_Model.About DataRowToModel(DataRow row)
        {
            E_Model.About model = new E_Model.About();
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
                if (row["CHANNEL"] != null)
                {
                    model.CHANNEL = row["CHANNEL"].ToString();
                }
                if (row["IMAGESHOW"] != null)
                {
                    model.IMAGESHOW = row["IMAGESHOW"].ToString();
                }
                if (row["DESCRIPTION"] != null)
                {
                    model.DESCRIPTION = row["DESCRIPTION"].ToString();
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
                if (row["PATHURL"] != null)
                {
                    model.PATHURL = row["PATHURL"].ToString();
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
            strSql.Append(" FROM CMS_ABOUT ");
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
            strSql.Append("order by CMS_ABOUT.CREATEDATE desc");
            strSql.Append(")AS Row, CMS_ABOUT.* ,SYS_DICTIONARY.DICTIONARYNAME from CMS_ABOUT left join SYS_DICTIONARY on CMS_ABOUT.CHANNEL = SYS_DICTIONARY.id  where 1=1  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND CMS_ABOUT.TITLE like '%" + strWhere + "%'");
            }
            if (startDate != "" && endDate == "")
            {
                strSql.Append(" and CMS_ABOUT.CREATEDATE between '" + startDate + " 00:00:00' and '" + DateTime.Now.ToShortDateString() + " 23:59:59'");
            }
            if (startDate == "" && endDate != "")
            {
                strSql.Append(" and CMS_ABOUT.CREATEDATE < '" + DateTime.Now.ToShortDateString() + " 23:59:59'");
            }
            if (startDate != "" && endDate != "")
            {
                strSql.Append(" and CMS_ABOUT.CREATEDATE between '" + startDate + " 00:00:00' and '" + endDate + " 23:59:59'");
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
        public List<E_Model.About> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CMS_ABOUT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.About> list = new List<E_Model.About>();
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
        public E_Model.About ReaderBind(IDataReader dataReader)
        {
            E_Model.About model = new E_Model.About();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.TITLE = dataReader["TITLE"].ToString();
            model.CHANNEL = dataReader["CHANNEL"].ToString();
            model.IMAGESHOW = dataReader["IMAGESHOW"].ToString();
            model.DESCRIPTION = dataReader["DESCRIPTION"].ToString();
            model.STATUS = dataReader["STATUS"].ToString();
            ojb = dataReader["CREATEDATE"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CREATEDATE = (DateTime)ojb;
            }
            model.CREATEUSER = dataReader["CREATEUSER"].ToString();
            model.PATHURL = dataReader["PATHURL"].ToString();
            return model;
        }



        public bool UpdateStatus(string ID, string Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_ABOUT set ");
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
            strSql.Append("update CMS_ABOUT set ");
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


        public DataSet GetTopList(int top,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT top "+top+ " CMS_ABOUT.*,SYS_DICTIONARY.DICTIONARYNAME from CMS_ABOUT LEFT JOIN SYS_DICTIONARY on CMS_ABOUT.CHANNEL = SYS_DICTIONARY.ID  where 1=1 ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND "+ strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        #endregion  Method
    }
}
