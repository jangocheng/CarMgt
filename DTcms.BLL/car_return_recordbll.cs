using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.BLL
{
    /// <summary>
    /// �����س��Ǽ���Ϣ
    /// </summary>
    public partial class car_return_recordbll
    {
        private readonly DAL.car_return_recorddal dal = new DAL.car_return_recorddal();
        public car_return_recordbll()
        { }
        #region  Method

        /// <summary>
        /// ���ݻس�ʱ����ûس���¼���������
        /// </summary>
        /// <param name="returnTime"></param>
        /// <returns></returns>
        public string GetMileageEnd(string returnTime)
        {
            return dal.GetMileageEnd(returnTime);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����û����Ƿ����
        /// </summary>
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetCarReturnCost(int Top, string strWhere, string filedOrder)
        {
            return dal.GetCarReturnCost(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ����ȡ��,ÿ����Ŀ��,û�е���Ŀ���·ݲ�Ϊһ��
        /// </summary>
        public DataSet GetMonthItems(string startDate, string endDate, string date, string strWhere)
        {
            return dal.GetMonthItems(startDate, endDate, date, strWhere);
        }

        /// <summary>
        /// ����һ������û���
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
        public int Add(DTcms.Model.car_return_recordinfo model)
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
        public bool Update(DTcms.Model.car_return_recordinfo model)
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
        public DTcms.Model.car_return_recordinfo GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// �����û�������һ��ʵ��
        /// </summary>
        public Model.car_return_recordinfo GetModel(string code, string carnumnber)
        {
            return dal.GetModel(code, carnumnber);
        }

        /// <summary>
        /// ���ݳ��������ȡ����������ִ�
        /// </summary>
        /// <param name="sourcecode"></param>
        /// <returns></returns>
        public Model.car_return_recordinfo GetItemCodes(string sourcecode,string where)
        {
            return dal.GetItemCodes(sourcecode,where);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetCarUseReturnReport(int Top, string strWhere, string filedOrder)
        {
            return dal.GetCarUseReturnReport(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetCarDrivers(int Top, string strWhere, string filedOrder)
        {
            return dal.GetCarDrivers(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion  Method
    }
}