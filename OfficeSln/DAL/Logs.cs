﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DBUtility;
using System.Data;
using HYTD.Common;
using Model.TO;
using System.Data.SqlClient;
/*
Author：liulei
Version：1.0
Date：2013-10-12 10:45:17
Description: DAL层 Logs
*/
namespace DAL
{

	public class LogsDAL
	{
        LinqHelper<AttendanceDataContext> linqHelper = new LinqHelper<AttendanceDataContext>();
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void AddLogs(Logs entity)
		{
			linqHelper.InsertEntity<Logs>(entity);
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void UpdateLogs(Logs entity)
		{
			linqHelper.UpdateEntity<Logs>(entity);
		}
		
		/// <summary>
		/// 获取一个实体
		/// </summary>
		public Logs GetLogsEntity(int ID)
		{
            return linqHelper.GetEntity<Logs>(c => c.Id == ID);
		}
		
		
		/// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        public void DeleteLogs(int FID)
        {
            linqHelper.DeleteEntity<Logs>(c => c.Id == FID);
        }
		
		
		
		/// <summary>
		/// 获取全部实体集合
		/// </summary>
		public List<Logs> GetLogsList()
		{
			return linqHelper.GetList<Logs>();
		}
		

		/// <summary>
		/// 获取实体分页
		/// </summary>
        public DataTable GetLogsList(LogsTO TO, int pageIndex, int pageSize, string orderBy, out int rowCount)
        {
            string table = " [Logs] ";
            string pk = " ID ";
            string fields = " * ";
            string filter ="";// string.Format(" Status={0} ", ConstantsManager.JiLuZhuangTai.Normal);
            
            #region 组织查询条件


            //if (!string.IsNullOrEmpty(TO.MC))
            //{
			//	filter += string.Format(" and MC like '%{0}%' ", StringHelper.SQLFilter(TO.MC));
            //}

            #endregion

            string sort = " ID DESC ";//排序
            if (!string.IsNullOrEmpty(orderBy))
                sort = orderBy;

            SqlParameter[] parameters = {
                new SqlParameter("@Tables",SqlDbType.VarChar,1000),
                new SqlParameter("@PK",SqlDbType.VarChar,100),
                new SqlParameter("@Fields",SqlDbType.VarChar,1000),
                new SqlParameter("@Pageindex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@Filter",SqlDbType.VarChar,1000),
                new SqlParameter("@Sort",SqlDbType.VarChar,200),
                new SqlParameter("@RowCount",SqlDbType.Int)
            };
            parameters[0].Value = table;
            parameters[1].Value = pk;
            parameters[2].Value = fields;
            parameters[3].Value = pageIndex;
            parameters[4].Value = pageSize;
            parameters[5].Value = filter;
            parameters[6].Value = sort;
            parameters[7].Direction = ParameterDirection.Output;

            DataSet ds = SqlHelper.RunProcedure("SP_DividePage", parameters, "LogsList");
            rowCount = (int)parameters[7].Value;
            return ds.Tables[0];
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddLogReturn(Logs entity)
        {
            try
            {
                linqHelper.InsertEntity<Logs>(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 访问量
        /// </summary>
        /// <returns></returns>
        public int GetLoginCount()
        {
            return linqHelper.GetList<Logs>().Count(l =>l.IsDel==1&& l.TypeName == "登录");
        }
	}
}