using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class Dictionary
    {
        public Dictionary()
        { }

        #region Model
        private string _id;
        private string _dictionaryname;
        private string _dictionaryvalue;
        private string _parentid;
        private decimal _sortlist;
        private string _description;
        private DateTime _createdate;
        private string _createuser;
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 字典名称
        /// </summary>
        [DataMember]
        public string DICTIONARYNAME
        {
            set { _dictionaryname = value; }
            get { return _dictionaryname; }
        }
        /// <summary>
        /// 字典值
        /// </summary>
        [DataMember]
        public string DICTIONARYVALUE
        {
            set { _dictionaryvalue = value; }
            get { return _dictionaryvalue; }
        }
        /// <summary>
        /// 上级编号
        /// </summary>
        [DataMember]
        public string PARENTID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public decimal SORTLIST
        {
            set { _sortlist = value; }
            get { return _sortlist; }
        }
        /// <summary>
        /// 备注
        [DataMember]/// </summary>
        public string  DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CREATEDATE
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public string CREATEUSER
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        #endregion Model
    }
}
