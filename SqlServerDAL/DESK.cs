using E_Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SqlServerDAL
{
    public class Desk : E_IDAL.IDesk
    {
        public Desk()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Desk model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_DESK(");
            strSql.Append("ID,DESKNAME,DESKCODE,DESKURL,DESKTYPE,STATUS,DESCRIPTION,CREATEUSER,CREATEDATE,SORTLIST,DESKWIDTH,DESKHEIGHT,ENABLECLOSE,ENABLEMIN,ENABLEMAX,ENABLECOL)");

            strSql.Append(" values (");
            strSql.Append("@ID,@DESKNAME,@DESKCODE,@DESKURL,@DESKTYPE,@STATUS,@DESCRIPTION,@CREATEUSER,@CREATEDATE,@SORTLIST,@DESKWIDTH,@DESKHEIGHT,@ENABLECLOSE,@ENABLEMIN,@ENABLEMAX,@ENABLECOL)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.String, model.ID);
            db.AddInParameter(dbCommand, "DESKNAME", DbType.String, model.DESKNAME);
            db.AddInParameter(dbCommand, "DESKCODE", DbType.String, model.DESKCODE);
            db.AddInParameter(dbCommand, "DESKURL", DbType.String, model.DESKURL);
            db.AddInParameter(dbCommand, "DESKTYPE", DbType.String, model.DESKTYPE);
            db.AddInParameter(dbCommand, "STATUS", DbType.String, model.STATUS);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "CREATEUSER", DbType.String, model.CREATEUSER);
            db.AddInParameter(dbCommand, "CREATEDATE", DbType.DateTime, model.CREATEDATE);
            db.AddInParameter(dbCommand, "SORTLIST", DbType.Int16, model.SORTLIST);
            db.AddInParameter(dbCommand, "DESKWIDTH", DbType.String, model.DESKWIDTH);
            db.AddInParameter(dbCommand, "DESKHEIGHT", DbType.String, model.DESKHEIGHT);
            db.AddInParameter(dbCommand, "ENABLECLOSE", DbType.String, model.ENABLECLOSE);
            db.AddInParameter(dbCommand, "ENABLEMIN", DbType.String, model.ENABLEMIN);
            db.AddInParameter(dbCommand, "ENABLEMAX", DbType.String, model.ENABLEMAX);
            db.AddInParameter(dbCommand, "ENABLECOL", DbType.String, model.ENABLECOL);
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
        public bool Update(E_Model.Desk model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_DESK set ");
            strSql.Append("DESKNAME=@DESKNAME,");
            strSql.Append("DESKCODE=@DESKCODE,");
            strSql.Append("DESKURL=@DESKURL,");
            strSql.Append("DESKTYPE=@DESKTYPE,");
            strSql.Append("DESCRIPTION=@DESCRIPTION,");
            strSql.Append("SORTLIST=@SORTLIST,");
            strSql.Append("DESKWIDTH=@DESKWIDTH,");
            strSql.Append("DESKHEIGHT=@DESKHEIGHT,");
            strSql.Append("ENABLECLOSE=@ENABLECLOSE,");
            strSql.Append("ENABLEMIN=@ENABLEMIN,");
            strSql.Append("ENABLEMAX=@ENABLEMAX,");
            strSql.Append("ENABLECOL=@ENABLECOL");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "DESKNAME", DbType.String, model.DESKNAME);
            db.AddInParameter(dbCommand, "DESKCODE", DbType.String, model.DESKCODE);
            db.AddInParameter(dbCommand, "DESKURL", DbType.String, model.DESKURL);
            db.AddInParameter(dbCommand, "DESKTYPE", DbType.String, model.DESKTYPE);
            db.AddInParameter(dbCommand, "DESCRIPTION", DbType.String, model.DESCRIPTION);
            db.AddInParameter(dbCommand, "SORTLIST", DbType.String, model.SORTLIST);
            db.AddInParameter(dbCommand, "DESKWIDTH", DbType.String, model.DESKWIDTH);
            db.AddInParameter(dbCommand, "DESKHEIGHT", DbType.String, model.DESKHEIGHT);
            db.AddInParameter(dbCommand, "ENABLECLOSE", DbType.String, model.ENABLECLOSE);
            db.AddInParameter(dbCommand, "ENABLEMIN", DbType.String, model.ENABLEMIN);
            db.AddInParameter(dbCommand, "ENABLEMAX", DbType.String, model.ENABLEMAX);
            db.AddInParameter(dbCommand, "ENABLECOL", DbType.String, model.ENABLECOL);
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
            strSql.Append("delete from SYS_DESK ");
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
            strSql.Append("delete from SYS_DESK ");
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
        public E_Model.Desk GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_DESK ");
            strSql.Append(" where ID='" + ID + "' ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            DataSet DS = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            E_Model.Desk model = new E_Model.Desk();
            if (DS.Tables[0].Rows.Count == 1)
            {
                model.ID = DS.Tables[0].Rows[0]["ID"].ToString();
                model.DESKNAME = DS.Tables[0].Rows[0]["DESKNAME"].ToString();
                model.DESKCODE = DS.Tables[0].Rows[0]["DESKCODE"].ToString();
                model.DESCRIPTION = DS.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                model.DESKTYPE = DS.Tables[0].Rows[0]["DESKTYPE"].ToString();
                model.DESKURL = DS.Tables[0].Rows[0]["DESKURL"].ToString();
                model.STATUS = DS.Tables[0].Rows[0]["STATUS"].ToString();
                if (model.CREATEDATE != null)
                {
                    model.CREATEDATE = DateTime.Parse(DS.Tables[0].Rows[0]["CREATEDATE"].ToString());
                }
                model.CREATEUSER = DS.Tables[0].Rows[0]["CREATEUSER"].ToString();
                if (model.SORTLIST != null)
                {
                    model.SORTLIST = int.Parse(DS.Tables[0].Rows[0]["SORTLIST"].ToString());
                }
                model.DESKWIDTH = DS.Tables[0].Rows[0]["DESKWIDTH"].ToString();
                model.DESKHEIGHT = DS.Tables[0].Rows[0]["DESKHEIGHT"].ToString();
                model.ENABLECLOSE = DS.Tables[0].Rows[0]["ENABLECLOSE"].ToString();
                model.ENABLEMAX = DS.Tables[0].Rows[0]["ENABLEMAX"].ToString();
                model.ENABLECOL = DS.Tables[0].Rows[0]["ENABLECOL"].ToString();
                model.ENABLEMIN = DS.Tables[0].Rows[0]["ENABLEMIN"].ToString();
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
            strSql.Append(" FROM SYS_DESK ");
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
        public List<E_Model.Desk> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SYS_DESK ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<E_Model.Desk> list = new List<E_Model.Desk>();
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
        public E_Model.Desk ReaderBind(IDataReader dataReader)
        {
            E_Model.Desk model = new E_Model.Desk();
            object ojb;
            model.ID = dataReader["ID"].ToString();
            model.DESKNAME = dataReader["DESKNAME"].ToString();
            model.DESKCODE = dataReader["DESKCODE"].ToString();
            model.DESKURL = dataReader["DESKURL"].ToString();
            model.DESKTYPE = dataReader["DESKTYPE"].ToString();
            model.STATUS = dataReader["STATUS"].ToString();
            model.DESCRIPTION = dataReader["DESCRIPTION"].ToString();

            model.CREATEUSER = dataReader["CREATEUSER"].ToString();
            ojb = dataReader["CREATEDATE"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CREATEDATE = (DateTime)ojb;
            }
            ojb = new object();
            ojb = dataReader["SORTLIST"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SORTLIST = (int)ojb;
            }
            model.DESKWIDTH = dataReader["DESKWIDTH"].ToString();
            model.DESKHEIGHT = dataReader["DESKHEIGHT"].ToString();
            model.ENABLECLOSE = dataReader["ENABLECLOSE"].ToString();
            model.ENABLEMIN = dataReader["ENABLEMIN"].ToString();
            model.ENABLEMAX = dataReader["ENABLEMAX"].ToString();
            model.ENABLECOL = dataReader["ENABLECOL"].ToString();
            return model;
        }


        public bool UpdateStatus(string ID, decimal Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_DESK set ");
            if (Status == 0)
            {
                strSql.Append(" STATUS  = '1'");
            }
            else
            {
                strSql.Append(" STATUS = '0'");
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
            strSql.Append("update SYS_DESK set ");
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

        public DataSet GetUserListByUserID(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM	SYS_DESK");
            strSql.Append(" where 1=1 ");
            if (ID != "")
            {
                strSql.Append(" and Createuser ='" + ID + "'");
            }
            strSql.Append(" order by  SYS_DESK.sortlist desc ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public DataSet GetSearchList(string strWhere, string startDate, string endDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SYS_DESK where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  (SYS_DESK.DESKNAME like '%" + strWhere + "%' or SYS_DESK.DESKCODE like '%" + strWhere + "%' )");
            }
            if (startDate != "" && endDate == "")
            {
                strSql.Append(" and SYS_DESK.createdate between to_date('" + startDate + " 00:00:00','yyyy-MM-dd E_Model.School') and to_date('" + DateTime.Now.ToShortDateString() + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            if (startDate == "" && endDate != "")
            {
                strSql.Append(" and SYS_DESK.createdate < to_date('" + DateTime.Now.ToShortDateString() + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            if (startDate != "" && endDate != "")
            {
                strSql.Append(" and SYS_DESK.createdate between to_date('" + startDate + " 00:00:00','yyyy-MM-dd hh24:mi:ss') and to_date('" + endDate + " 23:59:59','yyyy-MM-dd hh24:mi:ss')");
            }
            strSql.Append(" order by  SYS_DESK.sortlist desc");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        #endregion  Method
    }
}
