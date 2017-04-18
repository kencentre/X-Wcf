using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class Desk
    {
        public Desk()
        { }

        #region Model
        private string _id;
        private string _deskname;
        private string _deskcode;
        private string _deskurl;
        private string _desktype;
        private string _status;
        private string _description;
        private string _createuser;
        private DateTime _createdate;
        private int _sortlist;
        private string _deskwidth;
        private string _deskheight;
        private string _enableclose;
        private string _enablemin;
        private string _enablemax;
        private string _enablecol;
        /// <summary>
        /// 编号（主键）
        /// </summary>
        [DataMember]
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 桌面名称
        /// </summary>
        [DataMember]
        public string DESKNAME
        {
            set { _deskname = value; }
            get { return _deskname; }
        }
        /// <summary>
        /// 桌面编码
        /// </summary>
        [DataMember]
        public string DESKCODE
        {
            set { _deskcode = value; }
            get { return _deskcode; }
        }
        /// <summary>
        /// 桌面地址
        /// </summary>
        [DataMember]
        public string DESKURL
        {
            set { _deskurl = value; }
            get { return _deskurl; }
        }
        /// <summary>
        /// 桌面类型
        /// </summary>
        [DataMember]
        public string DESKTYPE
        {
            set { _desktype = value; }
            get { return _desktype; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public string STATUS
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
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
        /// 创建时间
        /// </summary>
        [DataMember]
        public int SORTLIST
        {
            set { _sortlist = value; }
            get { return _sortlist; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string DESKWIDTH
        {
            set { _deskwidth = value; }
            get { return _deskwidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string DESKHEIGHT
        {
            set { _deskheight = value; }
            get { return _deskheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ENABLECLOSE
        {
            set { _enableclose = value; }
            get { return _enableclose; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ENABLEMIN
        {
            set { _enablemin = value; }
            get { return _enablemin; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ENABLEMAX
        {
            set { _enablemax = value; }
            get { return _enablemax; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ENABLECOL
        {
            set { _enablecol = value; }
            get { return _enablecol; }
        }
        #endregion Model
    }
}
