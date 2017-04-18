using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class SchoolTeacher
    {

        /// <summary>
        /// 学校编号
        /// </summary>		
        private string _schoolid;
        [DataMember]
        public string SCHOOLID
        {
            get { return _schoolid; }
            set { _schoolid = value; }
        }
        /// <summary>
        /// 老师编号
        /// </summary>		
        private string _teacherid;
        [DataMember]
        public string TEACHERID
        {
            get { return _teacherid; }
            set { _teacherid = value; }
        }

    }
}
