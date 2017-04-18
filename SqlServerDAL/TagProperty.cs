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
    public class TagProperty:E_IDAL.ITagProperty
    {
        public TagProperty()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(E_Model.TagProperty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_TAG_PROPERTY(");
            strSql.Append("TAGID,PROPERTYID)");

            strSql.Append(" values (");
            strSql.Append("@TAGID,@PROPERTYID)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "TAGID", DbType.AnsiString, model.TAGID);
            db.AddInParameter(dbCommand, "PROPERTYID", DbType.AnsiString, model.PROPERTYID);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string TAGID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_TAG_PROPERTY ");
            strSql.Append(" where TAGID=@TAGID  ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "TAGID", DbType.AnsiString, TAGID);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TAGID,PROPERTYID ");
            strSql.Append(" FROM CMS_TAG_PROPERTY ");
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
