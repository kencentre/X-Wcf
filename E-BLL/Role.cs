using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public partial class Role
    {
        private readonly IRole dal = DataAccess.CreateRole();
        public Role()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Role model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_Model.Role model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Model.Role GetModel(string ID)
        {

            return dal.GetModel(ID);
        }

        

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetSearchList(string strWhere)
        {
            return dal.GetSearchList(strWhere);
        }

        public E_Model.Role ReaderBind(IDataReader dataReader)
        {
            return dal.ReaderBind(dataReader);
        }

        public bool UpdateStatus(string ID, decimal Status)
        {
            return dal.UpdateStatus(ID,Status);
        }
        public bool UpdateStatusList(string IDlist)
        {
            return dal.UpdateStatusList(IDlist);
        }
        #endregion  BasicMethod
    }
}
