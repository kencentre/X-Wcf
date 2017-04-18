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
    public class NewsChannel: INewsChannel
    {
        public NewsChannel()
        { }

        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.NewsChannel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_NEWSCHANNEL(");
            strSql.Append("ID,CHANNELNAME,CHANNELCODE,PARENTID,STATUS,DESCRIPTION,SORTLIST,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append(":ID,:CHANNELNAME,:CHANNELCODE,:PARENTID,:STATUS,:DESCRIPTION,:SORTLIST,:CREATEDATE,:CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            db.AddInParameter(dbCommand, "CHANNELNAME", DbType.String, model.CHANNELNAME);
            db.AddInParameter(dbCommand, "CHANNELCODE", DbType.String, model.CHANNELCODE);
            db.AddInParameter(dbCommand, "PARENTID", DbType.String, model.PARENTID);
            db.AddInParameter(dbCommand, "STATUS", DbType.String, model.STATUS);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "SORTLIST", DbType.Decimal, model.SORTLIST);
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
        public bool Update(E_Model.NewsChannel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_NEWSCHANNEL set ");
            strSql.Append("CHANNELNAME=:CHANNELNAME,");
            strSql.Append("CHANNELCODE=:CHANNELCODE,");
            strSql.Append("PARENTID=:PARENTID,");
            strSql.Append("STATUS=:STATUS,");
            strSql.Append("DESCRIPTION=:DESCRIPTION,");
            strSql.Append("SORTLIST=:SORTLIST");
            strSql.Append(" where ID=:ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CHANNELNAME", DbType.String, model.CHANNELNAME);
            db.AddInParameter(dbCommand, "CHANNELCODE", DbType.String, model.CHANNELCODE);
            db.AddInParameter(dbCommand, "PARENTID", DbType.String, model.PARENTID);
            db.AddInParameter(dbCommand, "STATUS", DbType.String, model.STATUS);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "SORTLIST", DbType.Decimal, model.SORTLIST);
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
            strSql.Append("delete from CMS_NEWSCHANNEL ");
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
            strSql.Append("delete from CMS_NEWSCHANNEL ");
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
        public E_Model.NewsChannel GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CHANNELNAME,CHANNELCODE,PARENTID,STATUS,DESCRIPTION,SORTLIST,CREATEDATE,CREATEUSER from CMS_NEWSCHANNEL ");
            strSql.Append(" where ID=:ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, ID);
            E_Model.NewsChannel model  = null;
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
        public E_Model.NewsChannel DataRowToModel(DataRow row)
        {
            E_Model.NewsChannel model = new E_Model.NewsChannel();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["CHANNELNAME"] != null)
                {
                    model.CHANNELNAME = row["CHANNELNAME"].ToString();
                }
                if (row["CHANNELCODE"] != null)
                {
                    model.CHANNELCODE = row["CHANNELCODE"].ToString();
                }
                if (row["PARENTID"] != null)
                {
                    model.PARENTID = row["PARENTID"].ToString();
                }
                if (row["STATUS"] != null)
                {
                    model.STATUS = row["STATUS"].ToString();
                }
                model.DESCRIPTION=row["DESCRIPTION"].ToString();
                if (row["SORTLIST"] != null && row["SORTLIST"].ToString() != "")
                {
                    model.SORTLIST = decimal.Parse(row["SORTLIST"].ToString());
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
            strSql.Append("select ID,CHANNELNAME,CHANNELCODE,PARENTID,STATUS,DESCRIPTION,SORTLIST,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM CMS_NEWSCHANNEL ");
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from CMS_NEWSCHANNEL T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "CMS_NEWSCHANNEL");
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
        public List<E_Model.NewsChannel> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CHANNELNAME,CHANNELCODE,PARENTID,STATUS,DESCRIPTION,SORTLIST,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM CMS_NEWSCHANNEL ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.NewsChannel> list = new List<E_Model.NewsChannel>();
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
        public E_Model.NewsChannel ReaderBind(IDataReader dataReader)
        {
            E_Model.NewsChannel model = new E_Model.NewsChannel();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.CHANNELNAME = dataReader["CHANNELNAME"].ToString();
            model.CHANNELCODE = dataReader["CHANNELCODE"].ToString();
            model.PARENTID = dataReader["PARENTID"].ToString();
            model.STATUS = dataReader["STATUS"].ToString();
            model.DESCRIPTION = dataReader["DESCRIPTION"].ToString();
            ojb = dataReader["SORTLIST"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SORTLIST = (decimal)ojb;
            }
            ojb = dataReader["CREATEDATE"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CREATEDATE = (DateTime)ojb;
            }
            model.CREATEUSER = dataReader["CREATEUSER"].ToString();
            return model;
        }

        #endregion  Method
    }
}
