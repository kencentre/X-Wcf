using System;
using System.Data;
using System.Collections.Generic;
using E_Model;
using E_DALFactory;
using E_IDAL;

namespace E_BLL
{
    public class PropertyValue
    {
        private readonly IPropertyValue dal = DataAccess.CreateIPropertyValue();
        public bool Add(E_Model.PropertyValue model)
        {
            return dal.Add(model);
        }

        public bool Update(E_Model.PropertyValue model)
        {
            return dal.Update(model);
        }

        public E_Model.PropertyValue GetModel(string ID)
        {
            return dal.GetModel(ID);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public E_Model.PropertyValue DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        public E_Model.PropertyValue ReaderBind(IDataReader dataReader)
        {
            return dal.ReaderBind(dataReader);
        }
    }
}
