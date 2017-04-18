using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class Desk
    {
        private readonly IDesk dal = DataAccess.CreateDesk();
        public bool Add(E_Model.Desk model)
        {
            return dal.Add(model);
        }


        public bool Update(E_Model.Desk model)
        {
            return dal.Update(model);
        }

        public bool Delete(string ID)
        {
            return dal.Delete(ID);
        }

        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        public E_Model.Desk GetModel(string ID)
        {
            return dal.GetModel(ID);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetSearchList(string strWhere, string startDate, string endDate)
        {
            return dal.GetSearchList(strWhere, startDate, endDate);
        }

        public E_Model.Desk ReaderBind(IDataReader dataReader)
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

        public DataSet GetUserListByUserID(string ID)
        {
            return dal.GetUserListByUserID(ID);
        }
    }
}
