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
    public class Tag:E_IDAL.ITag
    {
        public Tag()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Tag model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_TAG(");
            strSql.Append("ID,TAGNAEM,TAGTYPE,BROCKID,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append("@ID,@TAGNAEM,@TAGTYPE,@BROCKID,@STATUS,@DESCRIPTION,@CREATEDATE,@CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, model.ID);
            db.AddInParameter(dbCommand, "TAGNAEM", DbType.AnsiString, model.TAGNAEM);
            db.AddInParameter(dbCommand, "TAGTYPE", DbType.AnsiString, model.TAGTYPE);
            db.AddInParameter(dbCommand, "BROCKID", DbType.AnsiString, model.BROCKID);
            db.AddInParameter(dbCommand, "STATUS", DbType.AnsiString, model.STATUS);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.AnsiString, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "CREATEDATE", DbType.DateTime, model.CREATEDATE);
            db.AddInParameter(dbCommand, "CREATEUSER", DbType.AnsiString, model.CREATEUSER);
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
        public bool Update(E_Model.Tag model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_TAG set ");
            strSql.Append("TAGNAEM=@TAGNAEM,");
            strSql.Append("TAGTYPE=@TAGTYPE,");
            strSql.Append("BROCKID=@BROCKID,");
            strSql.Append("DESCRIPTION=@DESCRIPTION");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "TAGNAEM", DbType.AnsiString, model.TAGNAEM);
            db.AddInParameter(dbCommand, "TAGTYPE", DbType.AnsiString, model.TAGTYPE);
            db.AddInParameter(dbCommand, "BROCKID", DbType.AnsiString, model.BROCKID);
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
            strSql.Append("delete from CMS_TAG ");
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
            strSql.Append("delete from CMS_TAG ");
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
        public E_Model.Tag GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TAGNAEM,TAGTYPE,BROCKID,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER from CMS_TAG ");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, ID);
            E_Model.Tag model = null;
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
        public E_Model.Tag DataRowToModel(DataRow row)
        {
            E_Model.Tag model = new E_Model.Tag();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["TAGNAEM"] != null)
                {
                    model.TAGNAEM = row["TAGNAEM"].ToString();
                }
                if (row["TAGTYPE"] != null)
                {
                    model.TAGTYPE = row["TAGTYPE"].ToString();
                }
                if (row["BROCKID"] != null)
                {
                    model.BROCKID = row["BROCKID"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TAGNAEM,TAGTYPE,BROCKID,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER from CMS_TAG ");
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
            strSql.Append(")AS Row, T.*,X.BROCKNAME  from CMS_TAG  T LEFT JOIN CMS_BROCK X ON X.ID = T.BROCKID where 1=1  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND T.TAGNAEM like '%" + strWhere + "%' ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "CMS_TAG");
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
        public List<E_Model.Tag> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TAGNAEM,TAGTYPE,BROCKID,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER from CMS_TAG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Tag> list = new List<E_Model.Tag>();
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
        public E_Model.Tag ReaderBind(IDataReader dataReader)
        {
            E_Model.Tag model = new E_Model.Tag();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.TAGNAEM = dataReader["TAGNAEM"].ToString();
            model.TAGTYPE = dataReader["TAGTYPE"].ToString();
            model.BROCKID = dataReader["BROCKID"].ToString();
            model.STATUS = dataReader["STATUS"].ToString();
            model.DESCRIPTION = dataReader["DESCRIPTION"].ToString();
            ojb = dataReader["CREATEDATE"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CREATEDATE = (DateTime)ojb;
            }
            model.CREATEUSER = dataReader["CREATEUSER"].ToString();
            return model;
        }



        public bool UpdateStatus(string ID, string Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_TAG set ");
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
            strSql.Append("update CMS_TAG set ");
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
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.CREATEDATE desc");
            strSql.Append(")AS Row, T.*,y.PROPERTYNAME,y.PROPERTYTYPE,x.propertyid from CMS_TAG  T LEFT JOIN CMS_Tag_Property X ON X.TAGID = T.ID ");
            strSql.Append("  left join CMS_PROPERTY Y  on y.id = x.propertyid");
            strSql.Append("    where  t.status = '1' ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND " + strWhere );
            }
            strSql.Append(" ) TT");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public DataSet GetSearchListByProperty(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CMS_TAG.ID,CMS_TAG.TAGNAEM,CMS_PROPERTY.PROPERTYNAME,CMS_PROPERTY.PROPERTYTYPE,CMS_PROPERTY_VALUE.PROPERTYVALUE ");
            strSql.Append(" FROM CMS_TAG LEFT JOIN CMS_TAG_PROPERTY ON CMS_TAG.ID= CMS_TAG_PROPERTY.TAGID  ");
            strSql.Append(" LEFT JOIN CMS_PROPERTY ON CMS_TAG_PROPERTY.PROPERTYID = CMS_PROPERTY.ID ");
            strSql.Append(" LEFT JOIN CMS_PROPERTY_VALUE ON CMS_PROPERTY_VALUE.TAGID = CMS_TAG.ID");
            strSql.Append(" ");
            strSql.Append(" ");
            strSql.Append("    where  CMS_TAG.status = '1' ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND " + strWhere);
            }
            strSql.Append(" ORDER BY CMS_TAG.CREATEDATE DESC ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        #endregion  Method
    }
}
