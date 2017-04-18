﻿using System;
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
    public class School : E_IDAL.ISchool
    {
        public School()
        { }

        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.School model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_SCHOOL(");
            strSql.Append("ID,SCHOOLNAME,SCHOOLENAME,SCHOOLADRESS,SCHOOLIMAGE,SHOWPICTURE,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append("@ID,@SCHOOLNAME,@SCHOOLENAME,@SCHOOLADRESS,@SCHOOLIMAGE,@SHOWPICTURE,@DESCRIPTION,@STATUS,@CREATEDATE,@CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, model.ID);
            db.AddInParameter(dbCommand, "SCHOOLNAME", DbType.AnsiString, model.SCHOOLNAME);
            db.AddInParameter(dbCommand, "SCHOOLENAME", DbType.AnsiString, model.SCHOOLENAME);
            db.AddInParameter(dbCommand, "SCHOOLADRESS", DbType.AnsiString, model.SCHOOLADRESS);
            db.AddInParameter(dbCommand, "SCHOOLIMAGE", DbType.AnsiString, model.SCHOOLIMAGE);
            db.AddInParameter(dbCommand, "SHOWPICTURE", DbType.AnsiString, model.SHOWPICTURE);
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
        public bool Update(E_Model.School model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_SCHOOL set ");
            strSql.Append("SCHOOLNAME=@SCHOOLNAME,");
            strSql.Append("SCHOOLENAME=@SCHOOLENAME,");
            strSql.Append("SCHOOLADRESS=@SCHOOLADRESS,");
            strSql.Append("SCHOOLIMAGE=@SCHOOLIMAGE,");
            strSql.Append("SHOWPICTURE=@SHOWPICTURE,");
            strSql.Append("DESCRIPTION=@DESCRIPTION");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "SCHOOLNAME", DbType.AnsiString, model.SCHOOLNAME);
            db.AddInParameter(dbCommand, "SCHOOLENAME", DbType.AnsiString, model.SCHOOLENAME);
            db.AddInParameter(dbCommand, "SCHOOLADRESS", DbType.AnsiString, model.SCHOOLADRESS);
            db.AddInParameter(dbCommand, "SCHOOLIMAGE", DbType.AnsiString, model.SCHOOLIMAGE);
            db.AddInParameter(dbCommand, "SHOWPICTURE", DbType.AnsiString, model.SHOWPICTURE);
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
            strSql.Append("delete from CMS_SCHOOL ");
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
            strSql.Append("delete from CMS_SCHOOL ");
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
        public E_Model.School GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,SCHOOLNAME,SCHOOLENAME,SCHOOLADRESS,SCHOOLIMAGE,SHOWPICTURE,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER from CMS_SCHOOL ");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, ID);
            E_Model.School model = null;
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
        public E_Model.School DataRowToModel(DataRow row)
        {
            E_Model.School model = new E_Model.School();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["SCHOOLNAME"] != null)
                {
                    model.SCHOOLNAME = row["SCHOOLNAME"].ToString();
                }
                if (row["SCHOOLENAME"] != null)
                {
                    model.SCHOOLENAME = row["SCHOOLENAME"].ToString();
                }
                if (row["SCHOOLADRESS"] != null)
                {
                    model.SCHOOLADRESS = row["SCHOOLADRESS"].ToString();
                }
                if (row["SCHOOLIMAGE"] != null)
                {
                    model.SCHOOLIMAGE = row["SCHOOLIMAGE"].ToString();
                }
                if (row["SHOWPICTURE"] != null)
                {
                    model.SHOWPICTURE = row["SHOWPICTURE"].ToString();
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
            strSql.Append("select ID,SCHOOLNAME,SCHOOLENAME,SCHOOLADRESS,SCHOOLIMAGE,SHOWPICTURE,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM CMS_SCHOOL ");
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
        public DataSet GetListByPage(string strWhere,string startDate,string endDate, string startIndex, string endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.CREATEDATE desc");
            
            strSql.Append(")AS Row, T.*  from CMS_SCHOOL T WHERE 1=1");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and (SCHOOLNAME like '%"+strWhere+ "%' or  SCHOOLENAME like '%" + strWhere + "%')");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "CMS_SCHOOL");
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
        public List<E_Model.School> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,SCHOOLNAME,SCHOOLENAME,SCHOOLADRESS,SCHOOLIMAGE,SHOWPICTURE,DESCRIPTION,STATUS,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM CMS_SCHOOL ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.School> list = new List<E_Model.School>();
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
        public E_Model.School ReaderBind(IDataReader dataReader)
        {
            E_Model.School model = new E_Model.School();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.SCHOOLNAME = dataReader["SCHOOLNAME"].ToString();
            model.SCHOOLENAME = dataReader["SCHOOLENAME"].ToString();
            model.SCHOOLADRESS = dataReader["SCHOOLADRESS"].ToString();
            model.SCHOOLIMAGE = dataReader["SCHOOLIMAGE"].ToString();
            model.SHOWPICTURE = dataReader["SHOWPICTURE"].ToString();
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
            strSql.Append("update CMS_SCHOOL set ");
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
            strSql.Append("update CMS_SCHOOL set ");
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