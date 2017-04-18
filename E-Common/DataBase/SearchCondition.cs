using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace E_Common
{
    /// <summary>
    /// 搜索条件
    /// </summary>
    public class SearchCondition
    {

        #region 添加查询条件

        private Hashtable _conditionTable = new Hashtable();

        private Hashtable _htGroupNames = new Hashtable();

        /// <summary>
        /// 查询条件列表
        /// </summary>
        public Hashtable ConditionTable
        {
            get { return this._conditionTable; }
        }

        /// <summary>
        /// 为查询添加条件
        /// <example>
        /// 用法一：
        /// SearchCondition searchObj = new SearchCondition();
        /// searchObj.AddCondition("Test", 1, SqlOperator.NotEqual);
        /// searchObj.AddCondition("Test2", "Test2Value", SqlOperator.Like);
        /// string conditionSql = searchObj.BuildConditionSql();
        /// 
        /// 用法二：AddCondition函数可以串起来添加多个条件
        /// SearchCondition searchObj = new SearchCondition();
        /// searchObj.AddCondition("Test", 1, SqlOperator.NotEqual).AddCondition("Test2", "Test2Value", SqlOperator.Like);
        /// string conditionSql = searchObj.BuildConditionSql();
        /// </example>
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">SqlOperator枚举类型</param>
        /// <returns>增加条件后的Hashtable</returns>
        public SearchCondition AddCondition(string fieldName, object fieldValue, SqlOperator sqlOperator)
        {
            this._conditionTable.Add(System.Guid.NewGuid()/*fielName*/,
                new SearchEntity(fieldName, fieldValue, sqlOperator));
            return this;
        }

        /// <summary>
        /// 为查询添加条件
        /// <example>
        /// 用法一：
        /// SearchCondition searchObj = new SearchCondition();
        /// searchObj.AddCondition("Test", 1, SqlOperator.NotEqual, false);
        /// searchObj.AddCondition("Test2", "Test2Value", SqlOperator.Like, true);
        /// string conditionSql = searchObj.BuildConditionSql();
        /// 
        /// 用法二：AddCondition函数可以串起来添加多个条件
        /// SearchCondition searchObj = new SearchCondition();
        /// searchObj.AddCondition("Test", 1, SqlOperator.NotEqual, false).AddCondition("Test2", "Test2Value", SqlOperator.Like, true);
        /// string conditionSql = searchObj.BuildConditionSql();
        /// </example>
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">SqlOperator枚举类型</param>
        /// <param name="excludeIfEmpty">如果字段为空或者Null则不作为查询条件</param>
        /// <returns></returns>
        public SearchCondition AddCondition(string fieldName, object fieldValue, SqlOperator sqlOperator, bool excludeIfEmpty)
        {
            this._conditionTable.Add(System.Guid.NewGuid()/*fielName*/,
                new SearchEntity(fieldName, fieldValue, sqlOperator, excludeIfEmpty));
            return this;
        }

        /// <summary>
        /// 将多个条件分组归类作为一个条件来查询，
        /// 如需构造一个括号内的条件 ( Test = "AA1" OR Test = "AA2")
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">SqlOperator枚举类型</param>
        /// <param name="excludeIfEmpty">如果字段为空或者Null则不作为查询条件</param>
        /// <param name="groupName">分组的名称，如需构造一个括号内的条件 ( Test = "AA1" OR Test = "AA2"), 定义一个组名集中条件</param>
        /// <returns></returns>
        public SearchCondition AddCondition(string fieldName, object fieldValue, SqlOperator sqlOperator,
            bool excludeIfEmpty, string groupName)
        {
            this._conditionTable.Add(System.Guid.NewGuid()/*fielName*/,
                new SearchEntity(fieldName, fieldValue, sqlOperator, excludeIfEmpty, groupName));
            return this;
        }

        #endregion

        #region 辅助函数

        /// <summary>
        /// 转换枚举类型为对应的Sql语句操作符号
        /// </summary>
        /// <param name="sqlOperator">SqlOperator枚举对象</param>
        /// <returns><![CDATA[对应的Sql语句操作符号（如 ">" "<>" ">=")]]></returns>
        private string ConvertSqlOperator(SqlOperator sqlOperator, object fieldValue)
        {
            string stringOperator = " = ";
            string stringValue = string.Format(" '{0}' ", fieldValue);
            switch (sqlOperator)
            {
                case SqlOperator.Equal:
                    stringOperator = " = ";
                    break;
                case SqlOperator.LessThan:
                    stringOperator = " < ";
                    break;
                case SqlOperator.LessThanOrEqual:
                    stringOperator = " <= ";
                    break;
                case SqlOperator.Like:
                    stringOperator = " LIKE ";
                    stringValue = string.Format(" '%{0}%' ", fieldValue);
                    break;
                case SqlOperator.NotLike:
                    stringOperator = " NOT LIKE ";
                    stringValue = string.Format(" '%{0}%' ", fieldValue);
                    break;
                case SqlOperator.LikeStartAt:
                    stringOperator = " LIKE ";
                    stringValue = string.Format(" '%{0}' ", fieldValue);
                    break;
                case SqlOperator.LikeEndAt:
                    stringOperator = " LIKE ";
                    stringValue = string.Format(" '{0}%' ", fieldValue);
                    break;
                case SqlOperator.MoreThan:
                    stringOperator = " > ";
                    break;
                case SqlOperator.MoreThanOrEqual:
                    stringOperator = " >= ";
                    break;
                case SqlOperator.NotEqual:
                    stringOperator = " <> ";
                    break;
                case SqlOperator.In:
                    stringOperator = " IN ";
                    stringValue = string.Format(" ({0}) ", fieldValue);
                    break;
                case SqlOperator.NotIn:
                    stringOperator = " NOT IN ";
                    stringValue = string.Format(" ({0}) ", fieldValue);
                    break;
                default:
                    stringOperator = " = ";
                    break;
            }
            return stringOperator + stringValue;
        }

        /// <summary>
        /// 根据传入对象的值类型获取其对应的DbType类型
        /// </summary>
        /// <param name="fieldValue">对象的值</param>
        /// <returns>DbType类型</returns>
        private DbType GetFieldDbType(object fieldValue)
        {
            DbType type = DbType.String;
            switch (fieldValue.GetType().ToString())
            {
                case "System.Int16":
                    type = DbType.Int16;
                    break;
                case "System.UInt16":
                    type = DbType.UInt16;
                    break;
                case "System.Single":
                    type = DbType.Single;
                    break;
                case "System.UInt32":
                    type = DbType.UInt32;
                    break;
                case "System.Int32":
                    type = DbType.Int32;
                    break;
                case "System.UInt64":
                    type = DbType.UInt64;
                    break;
                case "System.Int64":
                    type = DbType.Int64;
                    break;
                case "System.String":
                    type = DbType.String;
                    break;
                case "System.Double":
                    type = DbType.Double;
                    break;
                case "System.Decimal":
                    type = DbType.Decimal;
                    break;
                case "System.Byte":
                    type = DbType.Byte;
                    break;
                case "System.Boolean":
                    type = DbType.Boolean;
                    break;
                case "System.DateTime":
                    type = DbType.DateTime;
                    break;
                case "System.Guid":
                    type = DbType.Guid;
                    break;
                default:
                    type = DbType.String;
                    break;
            }
            return type;
        }

        /// <summary>
        /// 判断输入的字符是否为日期
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        internal bool IsDate(string strValue)
        {
            return Regex.IsMatch(strValue, @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))");
        }

        /// <summary>
        /// 判断输入的字符是否为日期,如2004-07-12 14:25|||1900-01-01 00:00|||9999-12-31 23:59
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        internal bool IsDateHourMinute(string strValue)
        {
            return Regex.IsMatch(strValue, @"^(19[0-9]{2}|[2-9][0-9]{3})-((0(1|3|5|7|8)|10|12)-(0[1-9]|1[0-9]|2[0-9]|3[0-1])|(0(4|6|9)|11)-(0[1-9]|1[0-9]|2[0-9]|30)|(02)-(0[1-9]|1[0-9]|2[0-9]))\x20(0[0-9]|1[0-9]|2[0-3])(:[0-5][0-9]){1}$");
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BuilderConditionSql()
        {
            SearchEntity entity;
            StringBuilder BuilderSql = new StringBuilder();
            foreach (DictionaryEntry de in this._conditionTable)
            {
                entity = (SearchEntity)de.Value;
                if (entity.ExcludeIfEmpty &&
                    (entity.FieldValue == null || string.IsNullOrEmpty(entity.FieldValue.ToString())))
                    continue;
                if (string.IsNullOrEmpty(entity.GroupName))
                {
                    BuilderSql.AppendFormat(" AND {0} {1}", entity.FieldName,
                            this.ConvertSqlOperator(entity.SqlOperator, entity.FieldValue));
                }
                else
                {
                    if (!this._htGroupNames.Contains(entity.GroupName))
                        this._htGroupNames.Add(entity.GroupName, entity.GroupName);
                }
            }
            //拼接or
            string groupSql = string.Empty;
            StringBuilder sbGroup = new StringBuilder();
            foreach (string groupName in this._htGroupNames.Keys)
            {
                sbGroup = new StringBuilder();
                groupSql = " AND ({0})";
                foreach (DictionaryEntry de in this._conditionTable)
                {
                    entity = (SearchEntity)de.Value;
                    if (entity.ExcludeIfEmpty &&
                        (entity.FieldValue == null || string.IsNullOrEmpty(entity.FieldValue.ToString())))
                        continue;
                    if (groupName.Equals(entity.GroupName, StringComparison.OrdinalIgnoreCase))
                    {
                        sbGroup.AppendFormat(" OR {0} {1}", entity.FieldName,
                            this.ConvertSqlOperator(entity.SqlOperator, entity.FieldValue));
                    }
                }
                if (sbGroup.Length > 0)
                {
                    groupSql = string.Format(groupSql, sbGroup.ToString().Substring(3));//从第一个Or开始位置
                    BuilderSql.Append(groupSql);
                }
            }
            return BuilderSql.Length > 0 ? BuilderSql.ToString().Substring(4) : string.Empty;
        }
    }
}
