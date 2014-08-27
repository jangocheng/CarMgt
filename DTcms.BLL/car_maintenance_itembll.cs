using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.BLL
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public partial class car_maintenance_itembll
    {
        private readonly DAL.car_maintenance_itemdal dal = new DAL.car_maintenance_itemdal();
        public car_maintenance_itembll()
        { }
        #region  Method
        public string GetMaxCode()
        {
            return dal.GetMaxCode();
        }


        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ��鱣�����Ƿ����
        /// </summary>
        public bool Exists(string typecode)
        {
            return dal.Exists(typecode);
        }

        /// <summary>
        /// ����һ�����������
        /// </summary>
        public string GetRandomCode(int length)
        {
            string temp = Utils.Number(length, true);
            if (Exists(temp))
            {
                return GetRandomCode(length);
            }
            return temp;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DTcms.Model.car_maintenance_iteminfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(DTcms.Model.car_maintenance_iteminfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DTcms.Model.car_maintenance_iteminfo GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// ���ݱ���������һ��ʵ��
        /// </summary>
        public Model.car_maintenance_iteminfo GetModel(string code,string typename)
        {
            return dal.GetModel(code, typename);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public string GetTitleByCode(string code) {
            return dal.GetTitleByCode(code);
        }
        #endregion  Method
    }
}