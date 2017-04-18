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
    public class Student:E_IDAL.IStudent
    {
        public Student()
        { }

        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Student model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_STUDENT(");
            strSql.Append("ID,SCHOOLID,SNAME,ENAME,STUDENTINFO,STUDENTIMG,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append("@ID,@SCHOOLID,@SNAME,@ENAME,@STUDENTINFO,@STUDENTIMG,@DESCRIPTION,@STATUS,@CREATEDATE,@CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, model.ID);
            db.AddInParameter(dbCommand, "SCHOOLID", DbType.AnsiString, model.SCHOOLID);
            db.AddInParameter(dbCommand, "SNAME", DbType.AnsiString, model.SNAME);
            db.AddInParameter(dbCommand, "ENAME", DbType.AnsiString, model.ENAME);
            db.AddInParameter(dbCommand, "STUDENTINFO", DbType.AnsiString, model.STUDENTINFO);
            db.AddInParameter(dbCommand, "STUDENTIMG", DbType.AnsiString, model.STUDENTIMG);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.AnsiString, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "STATUS", DbType.AnsiString, model.STATUS);
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
        public bool Update(E_Model.Student model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_STUDENT set ");
            strSql.Append("SCHOOLID=@SCHOOLID,");
            strSql.Append("SNAME=@SNAME,");
            strSql.Append("ENAME=@ENAME,");
            strSql.Append("STUDENTINFO=@STUDENTINFO,");
            strSql.Append("STUDENTIMG=@STUDENTIMG,");
            strSql.Append("DESCRIPTION=@DESCRIPTION");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "SCHOOLID", DbType.AnsiString, model.SCHOOLID);
            db.AddInParameter(dbCommand, "SNAME", DbType.AnsiString, model.SNAME);
            db.AddInParameter(dbCommand, "ENAME", DbType.AnsiString, model.ENAME);
            db.AddInParameter(dbCommand, "STUDENTINFO", DbType.AnsiString, model.STUDENTINFO);
            db.AddInParameter(dbCommand, "STUDENTIMG", DbType.AnsiString, model.STUDENTIMG);
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
            strSql.Append("delete from CMS_STUDENT ");
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
            strSql.Append("delete from CMS_STUDENT ");
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
        public E_Model.Student GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,SCHOOLID,SNAME,ENAME,STUDENTINFO,STUDENTIMG,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER from CMS_STUDENT ");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, ID);
            E_Model.Student model = null;
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
        public E_Model.Student DataRowToModel(DataRow row)
        {
            E_Model.Student model = new E_Model.Student();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["SCHOOLID"] != null)
                {
                    model.SCHOOLID = row["SCHOOLID"].ToString();
                }
                if (row["SNAME"] != null)
                {
                    model.SNAME = row["SNAME"].ToString();
                }
                if (row["ENAME"] != null)
                {
                    model.ENAME = row["ENAME"].ToString();
                }
                if (row["STUDENTINFO"] != null)
                {
                    model.STUDENTINFO = row["STUDENTINFO"].ToString();
                }
                if (row["STUDENTIMG"] != null)
                {
                    model.STUDENTIMG = row["STUDENTIMG"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,SCHOOLID,SNAME,ENAME,STUDENTINFO,STUDENTIMG,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM CMS_STUDENT ");
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
            strSql.Append(")AS Row, T.*  from CMS_STUDENT T where 1=1  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND SNAME like '%" + strWhere + "%' OR ENAME like '%" + strWhere + "%'");
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
        public List<E_Model.Student> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,SCHOOLID,SNAME,ENAME,STUDENTINFO,STUDENTIMG,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM CMS_STUDENT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Student> list = new List<E_Model.Student>();
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
        public E_Model.Student ReaderBind(IDataReader dataReader)
        {
            E_Model.Student model = new E_Model.Student();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.SCHOOLID = dataReader["SCHOOLID"].ToString();
            model.SNAME = dataReader["SNAME"].ToString();
            model.ENAME = dataReader["ENAME"].ToString();
            model.STUDENTINFO = dataReader["STUDENTINFO"].ToString();
            model.STUDENTIMG = dataReader["STUDENTIMG"].ToString();
            model.DESCRIPTION = dataReader["DESCRIPTION"].ToString();
            model.STATUS = dataReader["STATUS"].ToString();
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
            strSql.Append("update CMS_STUDENT set ");
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
            strSql.Append("update CMS_STUDENT set ");
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
            strSql.Append("SELECT	TOP "+top+" cms_student.*,	cms_school.SCHOOLNAME,	CMS_BRAND.ID as BRANDID,	CMS_BRAND.BRANDNAME FROM	cms_student ");
            strSql.Append(" LEFT JOIN cms_school ON cms_student.SCHOOLID = cms_school.id LEFT JOIN CMS_BRAND_STUDENT ON CMS_BRAND_STUDENT.STUDENTID = cms_student.id ");
            strSql.Append(" LEFT JOIN CMS_BRAND ON CMS_BRAND.ID = CMS_BRAND_STUDENT.BRANDID");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND " + strWhere);
            }

            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        #endregion  Method
    }
}
