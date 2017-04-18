using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class School
    {
        private readonly ISchool dal = DataAccess.CreateSchool();

        public bool Add(E_Model.School model)
        {
            return dal.Add(model);
        }

        public bool Update(E_Model.School model)
        {
            return dal.Update(model);
        }

        public bool Delete(string ID)
        {
            return dal.Delete(ID);
        }

        public  bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }
        public E_Model.School GetModel(string ID)
        {
            return dal.GetModel(ID);
         }
        //E_Model.School DataRowToModel(DataRow row);

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetListByPage(string strWhere, string startDate, string endDate, string startIndex, string endIndex)
        {
            return dal.GetListByPage( strWhere,  startDate,  endDate,  startIndex,  endIndex);
        }
        
        public List<E_Model.School> GetListArray(string strWhere)
        {
            return dal.GetListArray(strWhere);
        }

        public E_Model.School ReaderBind(IDataReader dataReader)
        {
            return dal.ReaderBind(dataReader);
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
