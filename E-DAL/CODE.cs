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

namespace OracleDAL
{
    public class Code : E_IDAL.ICode
    {
        public Code()
        { }
            #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Code model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_CODE(");
            strSql.Append("ID,CODE)");

            strSql.Append(" values (");
            strSql.Append(":ID,:CODE)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ID", DbType.Int16, model.ID);
            db.AddInParameter(dbCommand, "CODE", DbType.Int16, model.CODE);
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
        public E_Model.Code GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CODE from SYS_CODE ");
            strSql.Append(" where ID='" + ID + "' ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            DataSet DS = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            E_Model.Code model = new E_Model.Code();
            if (DS.Tables[0].Rows.Count == 1)
            {
                if (model.ID != null)
                {
                    model.ID = int.Parse(DS.Tables[0].Rows[0]["ID"].ToString());
                }
                if (model.CODE != null)
                {
                    model.CODE = int.Parse(DS.Tables[0].Rows[0]["CODE"].ToString());
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
            strSql.Append("select ID,CODE ");
            strSql.Append(" FROM SYS_CODE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        public string CreateCode(int Number)
        {
            string result = "";
            E_Model.Code model = new E_Model.Code();
            model = GetModel(Number);
            switch (model.CODE.ToString().Length)
            {
                case 0: result = "000000" + model.CODE.ToString(); break;
                case 1: result = "00000" + model.CODE.ToString(); break;
                case 2: result = "0000" + model.CODE.ToString(); break;
                case 3: result = "000" + model.CODE.ToString(); break;
                case 4: result = "00" + model.CODE.ToString(); break;
                case 5: result = "0" + model.CODE.ToString(); break;
                case 6: result = model.CODE.ToString(); break;
            }
            return result;
        }

        public DataSet GetTopId()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * FROM (select * from SYS_CODE order by id DESC) where rownum<2");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        #endregion  Method


    }
}
