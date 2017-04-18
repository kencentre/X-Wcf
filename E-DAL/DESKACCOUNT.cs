using E_Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OracleDAL
{
    public class DeskAccount : E_IDAL.IDeskAccount
    {
        public DeskAccount()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(E_Model.DeskAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_DESK_ACCOUNT(");
            strSql.Append("DESKID,USERID)");

            strSql.Append(" values (");
            strSql.Append(":DESKID,:USERID)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "DESKID", DbType.String, model.DESKID);
            db.AddInParameter(dbCommand, "USERID", DbType.String, model.USERID);
            db.ExecuteNonQuery(dbCommand);


        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ACCOUNTID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_DESK_ACCOUNT ");
            strSql.Append(" where USERID=:USERID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ACCOUNTID", DbType.String, ACCOUNTID);
            db.ExecuteNonQuery(dbCommand);


        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DESKID,USERID ");
            strSql.Append(" FROM SYS_DESK_ACCOUNT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetSearchList(string DESKID, string ACCOUNTID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT	SYS_DESK.DESKNAME,SYS_DESK.DESKURL,SYS_DESK.ID AS DESKID ,SYS_ACCOUNT.ID AS ACCOUNTID,SYS_DESK.DESKWIDTH,SYS_DESK.DESKHEIGHT,SYS_DESK.ENABLECLOSE,SYS_DESK.ENABLEMIN,SYS_DESK.ENABLEMAX,SYS_DESK.ENABLECOL FROM SYS_DESK ");
            strSql.Append("  LEFT JOIN SYS_DESK_ACCOUNT ON SYS_DESK. ID = SYS_DESK_ACCOUNT.DESKID");
            strSql.Append(" LEFT JOIN SYS_ACCOUNT ON SYS_DESK_ACCOUNT.USERID = SYS_ACCOUNT.ID where 1=1 ");
            if (DESKID != "")
            {
                strSql.Append(" and SYS_DESK.ID = '" + DESKID + "'");
            }
            if (ACCOUNTID != "")
            {
                strSql.Append(" and SYS_ACCOUNT.ID = '" + ACCOUNTID + "'");
            }
            strSql.Append(" and SYS_DESK.status = '1' order by SYS_DESK.SORTLIST");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        #endregion  Method
    }
}
