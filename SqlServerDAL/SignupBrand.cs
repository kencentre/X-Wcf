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
    public class SignupBrand:E_IDAL.ISignupBrand
    {
        public SignupBrand()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(E_Model.SignupBrand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_SIGNUP_BRAND(");
            strSql.Append("SIGNUOID,BRANDID)");

            strSql.Append(" values (");
            strSql.Append("@SIGNUOID,@BRANDID)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "SIGNUOID", DbType.AnsiString, model.SIGNUOID);
            db.AddInParameter(dbCommand, "BRANDID", DbType.AnsiString, model.BRANDID);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string SIGNUOID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_SIGNUP_BRAND ");
            strSql.Append(" where SIGNUOID=@SIGNUOID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "SIGNUOID", DbType.String, SIGNUOID);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BRANDID,SIGNUOID from CMS_SIGNUP_BRAND ");
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
