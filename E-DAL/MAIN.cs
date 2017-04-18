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
    public class Main : E_IDAL.IMain
    {
        public Main()
        { }
        public bool Add(E_Model.Main model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MAIN(");
            strSql.Append("ID,MAINNAME,MAINICON,PARENTID,MAINURL,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append(":ID,:MAINNAME,:MAINICON,:PARENTID,:MAINURL,:SORTLIST,:STATUS,:DESCRIPTION,:CREATEDATE,:CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            db.AddInParameter(dbCommand, "MAINNAME", DbType.String, model.MAINNAME);
            db.AddInParameter(dbCommand, "MAINICON", DbType.String, model.MAINICON);
            db.AddInParameter(dbCommand, "PARENTID", DbType.String, model.PARENTID);
            db.AddInParameter(dbCommand, "MAINURL", DbType.String, model.MAINURL);
            db.AddInParameter(dbCommand, "SORTLIST", DbType.Decimal, model.SORTLIST);
            db.AddInParameter(dbCommand, "STATUS", DbType.Decimal, model.STATUS);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "CREATEDATE", DbType.Date, model.CREATEDATE);
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
        public bool Update(E_Model.Main model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_MAIN set ");
            strSql.Append("MAINNAME=:MAINNAME,");
            strSql.Append("MAINICON=:MAINICON,");
            strSql.Append("PARENTID=:PARENTID,");
            strSql.Append("MAINURL=:MAINURL,");
            strSql.Append("SORTLIST=:SORTLIST,");
            strSql.Append("DESCRIPTION=:DESCRIPTION ");
            strSql.Append(" where ID=:ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "MAINNAME", DbType.String, model.MAINNAME);
            db.AddInParameter(dbCommand, "MAINICON", DbType.String, model.MAINICON);
            db.AddInParameter(dbCommand, "PARENTID", DbType.String, model.PARENTID);
            db.AddInParameter(dbCommand, "MAINURL", DbType.String, model.MAINURL);
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
            strSql.Append("delete from SYS_MAIN ");
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
            strSql.Append("delete from SYS_MAIN ");
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
        public E_Model.Main GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,MAINNAME,MAINICON,PARENTID,MAINURL,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER from SYS_MAIN ");
            strSql.Append(" where ID= '" + ID + "' ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            DataSet DS = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            E_Model.Main model = new E_Model.Main();
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,MAINNAME,MAINICON,PARENTID,MAINURL,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_MAIN ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by SORTLIST");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<E_Model.Main> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,MAINNAME,MAINICON,PARENTID,MAINURL,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_MAIN ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Main> list = new List<E_Model.Main>();
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
        public E_Model.Main ReaderBind(IDataReader dataReader)
        {
            E_Model.Main model = new E_Model.Main();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.MAINNAME = dataReader["MAINNAME"].ToString();
            model.MAINICON = dataReader["MAINICON"].ToString();
            model.PARENTID = dataReader["PARENTID"].ToString();
            model.MAINURL = dataReader["MAINURL"].ToString();
            ojb = dataReader["SORTLIST"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SORTLIST = (decimal)ojb;
            }
            ojb = dataReader["STATUS"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.STATUS = (decimal)ojb;
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
    }
}
