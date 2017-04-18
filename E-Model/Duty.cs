using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class Duty
    {
        public Duty()
        { }

        #region Model
        private string _id;
        private string _dutyname;
        private string _dutycode;
        private decimal _sortlist;
        private decimal _status;
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
        /// 职务名称
        /// </summary>
        [DataMember]
        public string DUTYNAME
        {
            set { _dutyname = value; }
            get { return _dutyname; }
        }
        /// <summary>
        /// 职务代码
        /// </summary>
        [DataMember]
        public string DUTYCODE
        {
            set { _dutycode = value; }
            get { return _dutycode; }
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
        /// 状态
        /// </summary>
        [DataMember]
        public decimal STATUS
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
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
