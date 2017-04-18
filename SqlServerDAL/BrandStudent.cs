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
    public class BrandStudent:E_IDAL.IBrandStudent
    {
        public BrandStudent()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(E_Model.BrandStudent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_BRAND_STUDENT(");
            strSql.Append("BRANDID,STUDENTID)");

            strSql.Append(" values (");
            strSql.Append("@BRANDID,@STUDENTID)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "BRANDID", DbType.AnsiString, model.BRANDID);
            db.AddInParameter(dbCommand, "STUDENTID", DbType.AnsiString, model.STUDENTID);
           
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string STUDENTID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_BRAND_STUDENT ");
            strSql.Append(" where STUDENTID=@STUDENTID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "STUDENTID", DbType.String, STUDENTID);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BRANDID,STUDENTID from CMS_BRAND_STUDENT ");
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
