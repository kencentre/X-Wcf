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
    public class MainRole:E_IDAL.IMainRole
    {
        public MainRole()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(E_Model.MainRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_MAIN_ROLE(");
            strSql.Append("MAINID,ROLEID)");

            strSql.Append(" values (");
            strSql.Append("@MAINID,@ROLEID)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "MAINID", DbType.String, model.MAINID);
            db.AddInParameter(dbCommand, "ROLEID", DbType.String, model.ROLEID);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ROLEID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_MAIN_ROLE ");
            strSql.Append(" where  ROLEID=@ROLEID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ROLEID", DbType.String, ROLEID);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MAINID,ROLEID ");
            strSql.Append(" FROM SYS_MAIN_ROLE ");
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
