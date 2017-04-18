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
    public class BrandTeacher:E_IDAL.IBrandTeacher
    {
        public BrandTeacher()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(E_Model.BrandTeacher model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_BRAND_TEACHER(");
            strSql.Append("BRANDID,TEACHERID)");

            strSql.Append(" values (");
            strSql.Append("@BRANDID,@TEACHERID)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "BRANDID", DbType.AnsiString, model.BRANDID);
            db.AddInParameter(dbCommand, "TEACHERID", DbType.AnsiString, model.TEACHERID);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string TEACHERID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_BRAND_TEACHER ");
            strSql.Append(" where TEACHERID=@TEACHERID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "TEACHERID", DbType.String, TEACHERID);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BRANDID,TEACHERID ");
            strSql.Append(" FROM CMS_BRAND_TEACHER ");
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
