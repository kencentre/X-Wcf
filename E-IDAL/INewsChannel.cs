using E_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace E_IDAL
{
    [ServiceContract(Name = "INewsChannel")]
    public interface INewsChannel
    {
        #region  成员方法
        [OperationContract]
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(E_Model.NewsChannel model);

        [OperationContract]
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(E_Model.NewsChannel model);

        [OperationContract]
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string ID);

        [OperationContract]
        bool DeleteList(string IDlist);

        [OperationContract]
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        E_Model.NewsChannel GetModel(string ID);

        [OperationContract]
        E_Model.NewsChannel DataRowToModel(DataRow row);

        [OperationContract]
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        [OperationContract]
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        #endregion  成员方法
    }
}
