using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;
namespace E_BLL
{
	/// <summary>
	/// Notice
	/// </summary>
	public partial class Notice
    {
        private readonly INotice dal=DataAccess.CreateNotice();
		public Notice()
		{}
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(E_Model.Notice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(E_Model.Notice model)
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
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public E_Model.Notice GetModel(string ID)
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


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetSearchList(string strWhere, string startDate, string endDate)
		{
            return dal.GetSearchList(strWhere, startDate, endDate);
		}

        public E_Model.Notice ReaderBind(IDataReader dataReader)
        {
            return dal.ReaderBind(dataReader);
        }

        public bool UpdateStatus(string ID, decimal Status)
        {
            return dal.UpdateStatus(ID, Status);
        }

        public bool UpdateStatusList(string IDlist)
        {
            return dal.UpdateStatusList(IDlist);
        }
        public DataSet GetTopList(string strWhere, int rowNum)
        {
            return dal.GetTopList(strWhere, rowNum);
        }
        #endregion  BasicMethod

    }
}

