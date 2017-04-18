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
    public class SchoolTeacher : E_IDAL.ISchoolTeacher
    {
        public SchoolTeacher()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(E_Model.SchoolTeacher model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_SCHOOL_TEACHER(");
            strSql.Append("SCHOOLID,TEACHERID)");

            strSql.Append(" values (");
            strSql.Append("@SCHOOLID,@TEACHERID)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "SCHOOLID", DbType.AnsiString, model.SCHOOLID);
            db.AddInParameter(dbCommand, "TEACHERID", DbType.AnsiString, model.TEACHERID);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string TEACHERID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_SCHOOL_TEACHER ");
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
            strSql.Append("select SCHOOLID,TEACHERID ");
            strSql.Append(" FROM CMS_SCHOOL_TEACHER ");
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
