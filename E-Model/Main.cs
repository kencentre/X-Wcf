using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
namespace E_Model
{
    [DataContract]
    public class Main
    {
        public Main()
        { }

        #region Model
        private string _id;
        private string _mainname;
        private string _mainicon;
        private string _parentid;
        private string _mainurl;
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
        /// 菜单名称
        /// </summary>
        [DataMember]
        public string MAINNAME
        {
            set { _mainname = value; }
            get { return _mainname; }
        }
        /// <summary>
        /// 菜单图标
        /// </summary>
        [DataMember]
        public string MAINICON
        {
            set { _mainicon = value; }
            get { return _mainicon; }
        }
        /// <summary>
        /// 上街菜单
        /// </summary>
        [DataMember]
        public string PARENTID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 菜单地址
        /// </summary>
        [DataMember]
        public string MAINURL
        {
            set { _mainurl = value; }
            get { return _mainurl; }
        }
        /// <summary>
        /// 菜单排序
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
        public string DESCRIPTION
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
