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
    public class PropertyValue:E_IDAL.IPropertyValue
    {
        public PropertyValue()
        { }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(E_Model.PropertyValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_PROPERTY_VALUE(");
            strSql.Append("ID,TAGID,PROPERTYID,PROPERTYVALUE)");

            strSql.Append(" values (");
            strSql.Append("@ID,@TAGID,@PROPERTYID,@PROPERTYVALUE)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, model.ID);
            db.AddInParameter(dbCommand, "TAGID", DbType.AnsiString, model.TAGID);
            db.AddInParameter(dbCommand, "PROPERTYID", DbType.AnsiString, model.PROPERTYID);
            db.AddInParameter(dbCommand, "PROPERTYVALUE", DbType.AnsiString, model.PROPERTYVALUE);
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
        public bool Update(E_Model.PropertyValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_PROPERTY_VALUE set ");
            strSql.Append("PROPERTYVALUE=@PROPERTYVALUE");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "PROPERTYVALUE", DbType.AnsiString, model.PROPERTYVALUE);
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, model.ID);
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
		public E_Model.PropertyValue GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TAGID,PROPERTYID,PROPERTYVALUE from CMS_PROPERTY_VALUE ");
            strSql.Append(" where ID=@ID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.AnsiString, ID);
            E_Model.PropertyValue model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Model.PropertyValue DataRowToModel(DataRow row)
        {
            E_Model.PropertyValue model = new E_Model.PropertyValue();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["TAGID"] != null)
                {
                    model.TAGID = row["TAGID"].ToString();
                }
                if (row["PROPERTYID"] != null)
                {
                    model.PROPERTYID = row["PROPERTYID"].ToString();
                }
                if (row["PROPERTYVALUE"] != null)
                {
                    model.PROPERTYVALUE = row["PROPERTYVALUE"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CMS_PROPERTY_VALUE.ID,CMS_PROPERTY_VALUE.TAGID,CMS_PROPERTY_VALUE.PROPERTYID,CMS_PROPERTY_VALUE.PROPERTYVALUE,CMS_PROPERTY.PROPERTYTYPE ");
            strSql.Append(" FROM CMS_PROPERTY_VALUE left join CMS_PROPERTY ON CMS_PROPERTY_VALUE.PROPERTYID = CMS_PROPERTY.ID  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public E_Model.PropertyValue ReaderBind(IDataReader dataReader)
        {
            E_Model.PropertyValue model = new E_Model.PropertyValue();
            model.ID = dataReader["ID"].ToString();
            model.TAGID = dataReader["TAGID"].ToString();
            model.PROPERTYID = dataReader["PROPERTYID"].ToString();
            model.PROPERTYVALUE = dataReader["PROPERTYVALUE"].ToString();
            return model;
        }
    }
}
