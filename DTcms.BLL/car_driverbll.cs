using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.BLL
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public partial class car_driverbll
    {
        private readonly DAL.car_driverdal dal = new DAL.car_driverdal();
        public car_driverbll()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 获取最大的驾驶员的编码
        /// </summary>
        /// <returns></returns>
        public string GetMaxDriverCode()
        {
            return dal.GetMaxDriverCode();
        }


        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string drivercode)
        {
            return dal.Exists(drivercode);
        }

        /// <summary>
        /// 返回一个随机用户名
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
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.car_driverinfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.car_driverinfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.car_driverinfo GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据用户名返回一个实体
        /// </summary>
        public Model.car_driverinfo GetModel(string code,string drivername)
        {
            return dal.GetModel(code, drivername);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public string GetTitleByCode(string code)
        {
            return dal.GetTitleByCode(code);
        }
        #endregion  Method
    }
}