using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Model;
using System.Data;
using E_IDAL;
using E_DALFactory;

namespace E_BLL
{
    public class Dictionary
    {
        private readonly IDictionary dal = DataAccess.CreateDictionary();
        public bool Add(E_Model.Dictionary model)
        {
            return dal.Add(model);
        }

        public bool Update(E_Model.Dictionary model)
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

        public E_Model.Dictionary GetModel(string ID)
        {
            return dal.GetModel(ID);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public E_Model.Dictionary ReaderBind(IDataReader dataReader)
        {
            return dal.ReaderBind(dataReader);
        }

        public DataSet GetSearchList(string strWhere, string startDate, string endDate)
        {
            return dal.GetSearchList(strWhere, startDate, endDate);
        }

        public DataSet GetParentList(string strWhere)
        {
            return dal.GetParentList(strWhere);
        }
    }
}
