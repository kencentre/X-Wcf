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
    public class AccountDuty : E_IDAL.IAccountDuty
    {
        public AccountDuty()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(E_Model.AccountDuty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ACCOUNT_DUTY(");
            strSql.Append("ACCOUNTID,DUTYID)");

            strSql.Append(" values (");
            strSql.Append("@ACCOUNTID,@DUTYID)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ACCOUNTID", DbType.String, model.ACCOUNTID);
            db.AddInParameter(dbCommand, "DUTYID", DbType.String, model.DUTYID);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ACCOUNTID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_ACCOUNT_DUTY ");
            strSql.Append(" where ACCOUNTID=@ACCOUNTID ");
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
            strSql.Append("select ACCOUNTID,DUTYID ");
            strSql.Append(" FROM SYS_ACCOUNT_DUTY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }


        #endregion  Method
    }
}
