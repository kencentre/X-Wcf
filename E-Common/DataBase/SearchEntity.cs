using System;

namespace E_Common
{
    /// <summary>
    /// 查询信息实体类
    /// </summary>
    public class SearchEntity
    {

        public SearchEntity() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段的值</param>
        /// <param name="sqlOperator">字段的Sql操作符号</param>
        public SearchEntity(string fieldName, object fieldValue, SqlOperator sqlOperator)
            : this(fieldName, fieldValue, sqlOperator, true)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段的值</param>
        /// <param name="sqlOperator">字段的Sql操作符号</param>
        /// <param name="excludeIfEmpty">如果字段为空或者Null则不作为查询条件</param>
        public SearchEntity(string fieldName, object fieldValue, SqlOperator sqlOperator, bool excludeIfEmpty)
            : this(fieldName, fieldValue, sqlOperator, excludeIfEmpty, null)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段的值</param>
        /// <param name="sqlOperator">字段的Sql操作符号</param>
        /// <param name="excludeIfEmpty">如果字段为空或者Null则不作为查询条件</param>
        /// <param name="groupName">分组的名称，如需构造一个括号内的条件 ( Test = "AA1" OR Test = "AA2"), 定义一个组名集中条件</param>
        public SearchEntity(string fieldName, object fieldValue, SqlOperator sqlOperator, bool excludeIfEmpty, string groupName)
        {
            this._fieldName = fieldName;
            this._fieldValue = fieldValue;
            this._sqlOperator = sqlOperator;
            this._excludeIfEmpty = excludeIfEmpty;
            this._groupName = groupName;
        }

        #region 字段属性
        private string _fieldName = string.Empty;
        private object _fieldValue = null;
        private SqlOperator _sqlOperator;
        private bool _excludeIfEmpty = true;
        private string _groupName = string.Empty;

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }
        /// <summary>
        /// 字段的值
        /// </summary>
        public object FieldValue
        {
            get { return _fieldValue; }
            set { _fieldValue = value; }
        }
        /// <summary>
        /// 字段的Sql操作符号
        /// </summary>
        public SqlOperator SqlOperator
        {
            get { return _sqlOperator; }
            set { _sqlOperator = value; }
        }
        /// <summary>
        /// 如果字段为空或者Null则不作为查询条件
        /// </summary>
        public bool ExcludeIfEmpty
        {
            get { return _excludeIfEmpty; }
            set { _excludeIfEmpty = value; }
        }
        /// <summary>
        /// 分组的名称，如需构造一个括号内的条件 ( Test = "AA1" OR Test = "AA2"), 定义一个组名集中条件
        /// </summary>
        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }
        #endregion

    }
}
