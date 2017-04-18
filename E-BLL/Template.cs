using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class Template
    {
        private readonly ITemplate dal = DataAccess.CreateTemplate();

        public bool Add(E_Model.Template model)
        {
            return dal.Add(model);
        }

        public bool Update(E_Model.Template model)
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

        public E_Model.Template GetModel(string ID)
        {
            return dal.GetModel(ID);
        }

        public E_Model.Template DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetListByPage(string strWhere, string startDate, string endDate, string startIndex, string endIndex)
        {
            return dal.GetListByPage(strWhere, startDate, endDate, startIndex, endIndex);
        }

        public bool UpdateStatus(string ID, string Status)
        {
            return dal.UpdateStatus(ID, Status);
        }

        public bool UpdateStatusList(string IDlist)
        {
            return dal.UpdateStatusList(IDlist);
        }
    }
}
