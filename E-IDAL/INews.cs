﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using E_Model;
using System.Data;

namespace E_IDAL
{
    [ServiceContract(Name = "INews")]
    public interface INews
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(E_Model.News model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(E_Model.News model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(string ID);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        [OperationContract]
        bool DeleteList(string IDlist);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        E_Model.News GetModel(string ID);

        [OperationContract]
        E_Model.News DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        [OperationContract]
        DataSet GetList(string strWhere);


        [OperationContract]
        DataSet GetListByPage(string strWhere, string startDate, string endDate, string startIndex, string endIndex);

        [OperationContract]
        bool UpdateStatus(string ID, string Status);

        [OperationContract]
        bool UpdateStatusList(string IDlist);

        [OperationContract]
        DataSet GetTopList(int top, string strWhere);
        [OperationContract]
        DataSet GetSearchList(string strWhere);

        [OperationContract]
        DataSet GetDataTableProc(string sqlWhere, string PageSize, string PageIndex, out string RecordCount);
    }
}
