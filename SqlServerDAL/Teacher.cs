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
    public class Teacher:E_IDAL.ITeacher
    {
        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Teacher model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_TEACHER(");
            strSql.Append("ID,CHNNAME,ENGNAME,RANK,TPICTURE,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append("@ID,@CHNNAME,@ENGNAME,@RANK,@TPICTURE,@STATUS,@DESCRIPTION,@CREATEDATE,@CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, model.ID);
            db.AddInParameter(dbCommand, "CHNNAME", DbType.AnsiString, model.CHNNAME);
            db.AddInParameter(dbCommand, "ENGNAME", DbType.AnsiString, model.ENGNAME);
            db.AddInParameter(dbCommand, "RANK", DbType.AnsiString, model.RANK);
            db.AddInParameter(dbCommand, "TPICTURE", DbType.AnsiString, model.TPICTURE);
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
        public bool Update(E_Model.Teacher model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_TEACHER set ");
            strSql.Append("CHNNAME=@CHNNAME,");
            strSql.Append("ENGNAME=@ENGNAME,");
            strSql.Append("RANK=@RANK,");
            strSql.Append("TPICTURE=@TPICTURE,");
            strSql.Append("DESCRIPTION=@DESCRIPTION");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CHNNAME", DbType.AnsiString, model.CHNNAME);
            db.AddInParameter(dbCommand, "ENGNAME", DbType.AnsiString, model.ENGNAME);
            db.AddInParameter(dbCommand, "RANK", DbType.AnsiString, model.RANK);
            db.AddInParameter(dbCommand, "TPICTURE", DbType.AnsiString, model.TPICTURE);
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
            strSql.Append("delete from CMS_TEACHER ");
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
            strSql.Append("delete from CMS_TEACHER ");
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
        public E_Model.Teacher GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CHNNAME,ENGNAME,RANK,TPICTURE,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER from CMS_TEACHER ");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, ID);
            E_Model.Teacher model = null;
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
        public E_Model.Teacher DataRowToModel(DataRow row)
        {
            E_Model.Teacher model = new E_Model.Teacher();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["CHNNAME"] != null)
                {
                    model.CHNNAME = row["CHNNAME"].ToString();
                }
                if (row["ENGNAME"] != null)
                {
                    model.ENGNAME = row["ENGNAME"].ToString();
                }
                if (row["RANK"] != null)
                {
                    model.RANK = row["RANK"].ToString();
                }
                if (row["TPICTURE"] != null)
                {
                    model.TPICTURE = row["TPICTURE"].ToString();
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
            strSql.Append("select ID,CHNNAME,ENGNAME,RANK,TPICTURE,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM CMS_TEACHER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,CHNNAME,ENGNAME,RANK,TPICTURE,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM CMS_TEACHER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
            strSql.Append(")AS Row, T.*  from CMS_TEACHER T where 1=1  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" AND CHNNAME like '%" + strWhere + "%' OR ENGENAME like '%" + strWhere + "%'");
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

        public DataSet GetTopList(int top,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  TOP "+top+ " CMS_TEACHER.*, CMS_BRAND.ID FROM CMS_TEACHER LEFT JOIN CMS_BRAND_TEACHER ON CMS_TEACHER.ID = CMS_BRAND_TEACHER.TEACHERID ");
            strSql.Append("LEFT JOIN CMS_BRAND ON CMS_BRAND_TEACHER.BRANDID = CMS_BRAND.ID  where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public DataSet GetTopListBySchool(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  TOP " + top + " CMS_TEACHER.*, CMS_BRAND.ID FROM CMS_TEACHER LEFT JOIN CMS_BRAND_TEACHER ON CMS_TEACHER.ID = CMS_BRAND_TEACHER.TEACHERID ");
            strSql.Append("LEFT JOIN CMS_BRAND ON CMS_BRAND_TEACHER.BRANDID = CMS_BRAND.ID LEFT JOIN CMS_SCHOOL_TEACHER ON CMS_SCHOOL_TEACHER.TEACHERID = CMS_TEACHER. ID LEFT JOIN CMS_SCHOOL ON CMS_SCHOOL_TEACHER.SCHOOLID = CMS_SCHOOL.ID  where");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<E_Model.Teacher> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CHNNAME,ENGNAME,RANK,TPICTURE,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM CMS_TEACHER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Teacher> list = new List<E_Model.Teacher>();
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
        public E_Model.Teacher ReaderBind(IDataReader dataReader)
        {
            E_Model.Teacher model = new E_Model.Teacher();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.CHNNAME = dataReader["CHNNAME"].ToString();
            model.ENGNAME = dataReader["ENGNAME"].ToString();
            model.RANK = dataReader["RANK"].ToString();
            model.TPICTURE = dataReader["TPICTURE"].ToString();
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
            strSql.Append("update CMS_TEACHER set ");
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
            strSql.Append("update CMS_TEACHER set ");
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
