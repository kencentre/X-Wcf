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
    public class Dictionary:E_IDAL.IDictionary
    {
        public Dictionary()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Dictionary model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_DICTIONARY(");
            strSql.Append("ID,DICTIONARYNAME,DICTIONARYVALUE,PARENTID,SORTLIST,DESCRIPTION,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append("@ID,@DICTIONARYNAME,@DICTIONARYVALUE,@PARENTID,@SORTLIST,@DESCRIPTION,@CREATEDATE,@CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            db.AddInParameter(dbCommand, "DICTIONARYNAME", DbType.String, model.DICTIONARYNAME);
            db.AddInParameter(dbCommand, "DICTIONARYVALUE", DbType.String, model.DICTIONARYVALUE);
            db.AddInParameter(dbCommand, "PARENTID", DbType.String, model.PARENTID);
            db.AddInParameter(dbCommand, "SORTLIST", DbType.Decimal, model.SORTLIST);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
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
        public bool Update(E_Model.Dictionary model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_DICTIONARY set ");
            strSql.Append("DICTIONARYNAME=@DICTIONARYNAME,");
            strSql.Append("DICTIONARYVALUE=@DICTIONARYVALUE,");
            strSql.Append("PARENTID=@PARENTID,");
            strSql.Append("SORTLIST=@SORTLIST,");
            strSql.Append("DESCRIPTION=@DESCRIPTION");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "DICTIONARYNAME", DbType.String, model.DICTIONARYNAME);
            db.AddInParameter(dbCommand, "DICTIONARYVALUE", DbType.String, model.DICTIONARYVALUE);
            db.AddInParameter(dbCommand, "PARENTID", DbType.String, model.PARENTID);
            db.AddInParameter(dbCommand, "SORTLIST", DbType.Decimal, model.SORTLIST);
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
            strSql.Append("delete from SYS_DICTIONARY ");
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
            strSql.Append("delete from SYS_DICTIONARY ");
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
        public E_Model.Dictionary GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,DICTIONARYNAME,DICTIONARYVALUE,PARENTID,SORTLIST,DESCRIPTION,CREATEDATE,CREATEUSER from SYS_DICTIONARY ");
            strSql.Append(" where ID='" + ID + "' ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            DataSet DS = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            E_Model.Dictionary model = new E_Model.Dictionary();
            if (DS.Tables[0].Rows.Count == 1)
            {
                model.ID = DS.Tables[0].Rows[0]["ID"].ToString();
                model.DICTIONARYNAME = DS.Tables[0].Rows[0]["DICTIONARYNAME"].ToString();
                model.DICTIONARYVALUE = DS.Tables[0].Rows[0]["DICTIONARYVALUE"].ToString();
                model.PARENTID = DS.Tables[0].Rows[0]["PARENTID"].ToString();
                model.DESCRIPTION = DS.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                if (model.SORTLIST != null)
                {
                    model.SORTLIST = decimal.Parse(DS.Tables[0].Rows[0]["SORTLIST"].ToString());
                }
                if (model.CREATEDATE != null)
                {
                    model.CREATEDATE = DateTime.Parse(DS.Tables[0].Rows[0]["CREATEDATE"].ToString());
                }
                model.CREATEUSER = DS.Tables[0].Rows[0]["CREATEUSER"].ToString();
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Model.Dictionary DataRowToModel(DataRow row)
        {
            E_Model.Dictionary model = new E_Model.Dictionary();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["DICTIONARYNAME"] != null)
                {
                    model.DICTIONARYNAME = row["DICTIONARYNAME"].ToString();
                }
                if (row["DICTIONARYVALUE"] != null)
                {
                    model.DICTIONARYVALUE = row["DICTIONARYVALUE"].ToString();
                }
                if (row["PARENTID"] != null)
                {
                    model.PARENTID = row["PARENTID"].ToString();
                }
                if (row["SORTLIST"] != null && row["SORTLIST"].ToString() != "")
                {
                    model.SORTLIST = decimal.Parse(row["SORTLIST"].ToString());
                }
                //model.DESCRIPTION=row["DESCRIPTION"].ToString();
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
            strSql.Append("select ID,DICTIONARYNAME,DICTIONARYVALUE,PARENTID,SORTLIST,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_DICTIONARY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<E_Model.Dictionary> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,DICTIONARYNAME,DICTIONARYVALUE,PARENTID,SORTLIST,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_DICTIONARY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Dictionary> list = new List<E_Model.Dictionary>();
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
        public E_Model.Dictionary ReaderBind(IDataReader dataReader)
        {
            E_Model.Dictionary model = new E_Model.Dictionary();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.DICTIONARYNAME = dataReader["DICTIONARYNAME"].ToString();
            model.DICTIONARYVALUE = dataReader["DICTIONARYVALUE"].ToString();
            model.PARENTID = dataReader["PARENTID"].ToString();
            ojb = dataReader["SORTLIST"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SORTLIST = (decimal)ojb;
            }
            model.DESCRIPTION = dataReader["DESCRIPTION"].ToString();

            ojb = dataReader["CREATEDATE"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CREATEDATE = (DateTime)ojb;
            }
            model.CREATEUSER = dataReader["CREATEUSER"].ToString();
            return model;
        }

        public DataSet GetSearchList(string strWhere, string startDate, string endDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append(" FROM sys_Dictionary   where 1=1 and id <> '2abe5d4e-3c71-43c0-83b0-a4e2b560aeb0' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  (DictionaryName like '%" + strWhere + "%' or DictionaryValue like '%" + strWhere + "%' )");
            }
            if (startDate != "" && endDate == "")
            {
                strSql.Append(" and createdate between to_date('" + startDate + " 00:00:00','yyyy-MM-dd hh24:mi:ss') and to_date('" + DateTime.Now.ToShortDateString() + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            if (startDate == "" && endDate != "")
            {
                strSql.Append(" and createdate < to_date('" + DateTime.Now.ToShortDateString() + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            if (startDate != "" && endDate != "")
            {
                strSql.Append(" and createdate between to_date('" + startDate + " 00:00:00','yyyy-MM-dd E_Model.School') and to_date('" + endDate + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            strSql.Append(" order by  Createdate desc, sortlist ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public DataSet GetParentList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM SYS_DICTIONARY where parentid in (select id from SYS_DICTIONARY where DICTIONARYNAME = '" + strWhere + "')");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        #endregion  Method
    }
}
