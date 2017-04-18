using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class Duty
    {
        private readonly IDuty dal = DataAccess.CreateDuty();
        public bool Add(E_Model.Duty model)
        {
            return dal.Add(model);
        }

        public bool Update(E_Model.Duty model)
        {
            return dal.Update(model);
        }

        public bool Delete(string ID)
        {
            return dal.Delete(ID);
        }

        public bool DeleteList(string IDlist)
        {
            return DeleteList(IDlist);
        }

        public E_Model.Duty GetModel(string ID)
        {
            return dal.GetModel(ID);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetSearchList(string strWhere)
        {
            return dal.GetSearchList(strWhere);
        }

        public E_Model.Duty ReaderBind(IDataReader dataReader)
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

        public DataSet GetUserListByDutyID(string ID)
        {
            return dal.GetUserListByDutyID(ID);
        }
    }
}
