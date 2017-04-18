using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class Account
    {
        private readonly IAccount dal = DataAccess.CreateAccount();

        public bool Add(E_Model.Account model)
        {
            return dal.Add(model);
        }

        public bool Update(E_Model.Account model)
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

        public E_Model.Account GetModel(string ID)
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

        public E_Model.Account ReaderBind(IDataReader dataReader)
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

        public bool AccountLogin(string UserName, string Password)
        {
            return dal.AccountLogin(UserName, Password);
        }

        public bool UpdatePwd(E_Model.Account model)
        {
            return dal.UpdatePwd(model);
        }

        public bool UpdateUserInfo(E_Model.Account model)
        {
            return dal.UpdateUserInfo(model);
        }
        
        public bool ResetPwd(E_Model.Account model)
        {
            return dal.ResetPwd(model);
        }

        public DataSet GetAccountMainList(string ID)
        {
            return dal.GetAccountMainList(ID);
        }

        public DataSet GetAccountMainListByPID(string ID, string ParentID)
        {
            return dal.GetAccountMainListByPID(ID, ParentID);
        }
    }
}
