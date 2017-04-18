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
    public class Dept : E_IDAL.IDept
    {
        public Dept()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Dept model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_DEPT(");
            strSql.Append("ID,DEPTNAME,DEPTCODE,PARENTID,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER)");

            strSql.Append(" values (");
            strSql.Append(":ID,:DEPTNAME,:DEPTCODE,:PARENTID,:SORTLIST,:STATUS,:DESCRIPTION,:CREATEDATE,:CREATEUSER)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            db.AddInParameter(dbCommand, "DEPTNAME", DbType.String, model.DEPTNAME);
            db.AddInParameter(dbCommand, "DEPTCODE", DbType.String, model.DEPTCODE);
            db.AddInParameter(dbCommand, "PARENTID", DbType.String, model.PARENTID);
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
        public bool Update(E_Model.Dept model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_DEPT set ");
            strSql.Append("ID=:ID,");
            strSql.Append("DEPTNAME=:DEPTNAME,");
            strSql.Append("DEPTCODE=:DEPTCODE,");
            strSql.Append("PARENTID=:PARENTID,");
            strSql.Append("SORTLIST=:SORTLIST,");
            strSql.Append("DESCRIPTION=:DESCRIPTION");
            strSql.Append(" where ID=:ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            db.AddInParameter(dbCommand, "DEPTNAME", DbType.String, model.DEPTNAME);
            db.AddInParameter(dbCommand, "DEPTCODE", DbType.String, model.DEPTCODE);
            db.AddInParameter(dbCommand, "PARENTID", DbType.String, model.PARENTID);
            db.AddInParameter(dbCommand, "SORTLIST", DbType.String, model.SORTLIST);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
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
            strSql.Append("delete from SYS_DEPT ");
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
            strSql.Append("delete from SYS_DEPT ");
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
        public E_Model.Dept GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,DEPTNAME,DEPTCODE,PARENTID,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER from SYS_DEPT ");
            strSql.Append(" where ID='" + ID + "' ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            DataSet DS = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            E_Model.Dept model = new E_Model.Dept();
            if (DS.Tables[0].Rows.Count == 1)
            {
                model.ID = DS.Tables[0].Rows[0]["ID"].ToString();
                model.DEPTNAME = DS.Tables[0].Rows[0]["DEPTNAME"].ToString();
                model.DEPTCODE = DS.Tables[0].Rows[0]["DEPTCODE"].ToString();
                model.PARENTID = DS.Tables[0].Rows[0]["PARENTID"].ToString();
                model.DESCRIPTION = DS.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                if (model.SORTLIST != null)
                {
                    model.SORTLIST = decimal.Parse(DS.Tables[0].Rows[0]["SORTLIST"].ToString());
                }
                if (model.STATUS != null)
                {
                    model.STATUS = decimal.Parse(DS.Tables[0].Rows[0]["STATUS"].ToString());
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,DEPTNAME,DEPTCODE,PARENTID,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_DEPT ");
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
        public List<E_Model.Dept> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,DEPTNAME,DEPTCODE,PARENTID,SORTLIST,STATUS,DESCRIPTION,CREATEDATE,CREATEUSER ");
            strSql.Append(" FROM SYS_DEPT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Dept> list = new List<E_Model.Dept>();
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
        public E_Model.Dept ReaderBind(IDataReader dataReader)
        {
            E_Model.Dept model = new E_Model.Dept();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.DEPTNAME = dataReader["DEPTNAME"].ToString();
            model.DEPTCODE = dataReader["DEPTCODE"].ToString();
            model.PARENTID = dataReader["PARENTID"].ToString();
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

        public DataSet GetAccountListByDeptID(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from sys_account  where DEPT ='" + ID + "' or DEPT in ( ");
            strSql.Append(" SELECT id from SYS_DEPT START WITH PARENTID ='" + ID + "' CONNECT BY PARENTID = PRIOR id  ) ");

            strSql.Append(" order by Createdate desc");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        #endregion  Method
    }
}
