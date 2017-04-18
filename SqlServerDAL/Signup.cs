using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerDAL
{
    public class Signup:E_IDAL.ISignup
    {
        public Signup()
        { }

        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Signup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_SIGNUP(");
            strSql.Append("ID,USERNAME,SCHOOLID,PHONE,QQ,EMAIL,ADRESS,DESCRIPTION,CREATEDATE,STATUS)");

            strSql.Append(" values (");
            strSql.Append("@ID,@USERNAME,@SCHOOLID,@PHONE,@QQ,@EMAIL,@ADRESS,@DESCRIPTION,@CREATEDATE,@STATUS)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, model.ID);
            db.AddInParameter(dbCommand, "USERNAME", DbType.AnsiString, model.USERNAME);
            db.AddInParameter(dbCommand, "SCHOOLID", DbType.AnsiString, model.SCHOOLID);
            db.AddInParameter(dbCommand, "PHONE", DbType.AnsiString, model.PHONE);
            db.AddInParameter(dbCommand, "QQ", DbType.AnsiString, model.QQ);
            db.AddInParameter(dbCommand, "EMAIL", DbType.AnsiString, model.EMAIL);
            db.AddInParameter(dbCommand, "ADRESS", DbType.AnsiString, model.ADRESS);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.AnsiString, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "CREATEDATE", DbType.DateTime, model.CREATEDATE);
            db.AddInParameter(dbCommand, "STATUS", DbType.AnsiString, model.STATUS);
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
        public bool Update(E_Model.Signup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_SIGNUP set ");
            strSql.Append("USERNAME=@USERNAME,");
            strSql.Append("SCHOOLID=@SCHOOLID,");
            strSql.Append("PHONE=@PHONE,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("EMAIL=@EMAIL,");
            strSql.Append("ADRESS=@ADRESS,");
            strSql.Append("DESCRIPTION=@DESCRIPTION");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "USERNAME", DbType.AnsiString, model.USERNAME);
            db.AddInParameter(dbCommand, "SCHOOLID", DbType.AnsiString, model.SCHOOLID);
            db.AddInParameter(dbCommand, "PHONE", DbType.AnsiString, model.PHONE);
            db.AddInParameter(dbCommand, "QQ", DbType.AnsiString, model.QQ);
            db.AddInParameter(dbCommand, "EMAIL", DbType.AnsiString, model.EMAIL);
            db.AddInParameter(dbCommand, "ADRESS", DbType.AnsiString, model.ADRESS);
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
            strSql.Append("delete from CMS_SIGNUP ");
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
            strSql.Append("delete from CMS_SIGNUP ");
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
        public E_Model.Signup GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,USERNAME,SCHOOLID,PHONE,QQ,EMAIL,ADRESS,DESCRIPTION,CREATEDATE,STATUS from CMS_SIGNUP ");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, ID);
            E_Model.Signup model = null;
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
        public E_Model.Signup DataRowToModel(DataRow row)
        {
            E_Model.Signup model = new E_Model.Signup();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["USERNAME"] != null)
                {
                    model.USERNAME = row["USERNAME"].ToString();
                }
                if (row["SCHOOLID"] != null)
                {
                    model.SCHOOLID = row["SCHOOLID"].ToString();
                }
                if (row["PHONE"] != null)
                {
                    model.PHONE = row["PHONE"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["EMAIL"] != null)
                {
                    model.EMAIL = row["EMAIL"].ToString();
                }
                if (row["ADRESS"] != null)
                {
                    model.ADRESS = row["ADRESS"].ToString();
                }
                if (row["DESCRIPTION"] != null)
                {
                    model.DESCRIPTION = row["DESCRIPTION"].ToString();
                }
                if (row["CREATEDATE"] != null && row["CREATEDATE"].ToString() != "")
                {
                    model.CREATEDATE = DateTime.Parse(row["CREATEDATE"].ToString());
                }
                if (row["STATUS"] != null)
                {
                    model.STATUS = row["STATUS"].ToString();
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
            strSql.Append("select ID,USERNAME,SCHOOLID,PHONE,QQ,EMAIL,ADRESS,DESCRIPTION,CREATEDATE,STATUS ");
            strSql.Append(" FROM CMS_SIGNUP ");
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
            strSql.Append(")AS Row, T.*  from CMS_SIGNUP T where 1=1  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND USERNAME like '%" + strWhere + "%' ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "CMS_STUDENT");
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
        public List<E_Model.Signup> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,USERNAME,SCHOOLID,PHONE,QQ,EMAIL,ADRESS,DESCRIPTION,CREATEDATE,STATUS ");
            strSql.Append(" FROM CMS_SIGNUP ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Signup> list = new List<E_Model.Signup>();
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
        public E_Model.Signup ReaderBind(IDataReader dataReader)
        {
            E_Model.Signup model = new E_Model.Signup();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.USERNAME = dataReader["USERNAME"].ToString();
            model.SCHOOLID = dataReader["SCHOOLID"].ToString();
            model.PHONE = dataReader["PHONE"].ToString();
            model.QQ = dataReader["QQ"].ToString();
            model.EMAIL = dataReader["EMAIL"].ToString();
            model.ADRESS = dataReader["ADRESS"].ToString();
            model.DESCRIPTION = dataReader["DESCRIPTION"].ToString();
            ojb = dataReader["CREATEDATE"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CREATEDATE = (DateTime)ojb;
            }
            model.STATUS = dataReader["STATUS"].ToString();
            return model;
        }

        public bool UpdateStatus(string ID, string Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_SIGNUP set ");
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
            strSql.Append("update CMS_SIGNUP set ");
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
        #endregion  Method
    }
}
