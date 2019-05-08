using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace HYTD.Common
{
    /// <summary>
    /// ���ڰѶ���������ת���ض��������͵ķ���
    /// </summary>
    public class ConvertHelper
    {
        #region ���������ת���ַ��������ķ���
        /// <summary>
        /// ���������ת���ַ��������ķ���
        /// </summary>
        /// <param name="obj">�������</param>
        /// <returns>�ַ�������</returns>
        public static string GetString(object obj)
        {
            return (obj == DBNull.Value || obj == null) ? "" : obj.ToString();
        }
        #endregion

        #region ���������ת��32λ�����ͱ����ķ���
        /// <summary>
        /// ���������ת��32λ�����ͱ����ķ���
        /// </summary>
        /// <param name="obj">�������</param>
        /// <returns>32λ�����ͱ���</returns>
        public static int GetInteger(object obj)
        {
            return ConvertStringToInteger(GetString(obj));
        }
        #endregion

        #region ���������ת��64λ�����ͱ����ķ���
        /// <summary>
        /// ���������ת��64λ�����ͱ����ķ���
        /// </summary>
        /// <param name="obj">�������</param>
        /// <returns>64λ�����ͱ���</returns>
        public static long GetLong(object obj)
        {
            return ConvertStringToLong(GetString(obj));
        }
        #endregion

        #region ���������ת��˫���ȸ����ͱ����ķ���
        /// <summary>
        /// ���������ת��˫���ȸ����ͱ����ķ���
        /// </summary>
        /// <param name="obj">�������</param>
        /// <returns>˫���ȸ����ͱ���</returns>
        public static double GetDouble(object obj)
        {
            return ConvertStringToDouble(GetString(obj));
        }
        #endregion

        #region ���������ת��ʮ�������ֱ����ķ���
        /// <summary>
        /// ���������ת��ʮ�������ֱ����ķ���
        /// </summary>
        /// <param name="obj">�������</param>
        /// <returns>ʮ�������ֱ���</returns>
        public static decimal GetDecimal(object obj)
        {
            return ConvertStringToDecimal(GetString(obj));
        }
        #endregion

        #region ���������ת�ɲ����ͱ����ķ���
        /// <summary>
        /// ���������ת�ɲ����ͱ����ķ���
        /// </summary>
        /// <param name="obj">�������</param>
        /// <returns>�����ͱ���</returns>
        public static bool GetBoolean(object obj)
        {
            return (obj == DBNull.Value || obj == null) ? false :
                GetString(obj).Length == 0 ? false : Convert.ToBoolean(obj);
        }
        #endregion

        #region ���������ת������ʱ�����ַ��������ķ���
        /// <summary>
        /// ���������ת������ʱ�����ַ��������ķ���
        /// </summary>
        /// <param name="obj">�������</param>
        /// <param name="sFormat">��ʽ�ַ�</param>
        /// <returns>ʱ�����ַ�������</returns>
        public static string GetDateTimeString(object obj, string sFormat)
        {
            return (obj == DBNull.Value || obj == null) ? "" : Convert.ToDateTime(obj).ToString(sFormat);
        }
        #endregion

        #region ���������ת�������ַ��������ķ���
        /// <summary>
        /// ���������ת�������ַ��������ķ���
        /// </summary>
        /// <param name="obj">�������</param>
        /// <returns>�����ַ�������</returns>
        public static string GetShortDateString(object obj)
        {
            return GetDateTimeString(obj, "yyyy-MM-dd");
        }
        #endregion

        #region ���������ת�������ͱ����ķ���
        /// <summary>
        /// ���������ת�������ͱ����ķ���
        /// </summary>
        /// <param name="obj">�������</param>
        /// <returns>�����ͱ���</returns>
        public static DateTime GetDateTime(object obj)
        {
            return obj == null || obj == DBNull.Value || obj.ToString().Length==0 ? new DateTime() : Convert.ToDateTime(obj);
        }
        /// <summary>
        /// ���������ת�������ͱ����ķ��� ���ʱ��Ϊ�ջ�null ����1900��1��1��
        /// </summary>
        /// <param name="obj">�������</param>
        /// <returns>�����ͱ���</returns>
        public static DateTime GetDateTimeHasDefault(object obj)
        {
            return obj == null || obj == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(obj);
        }
        #endregion

        #region ˽�з���

        #region ���ַ���ת��32λ�����ͱ����ķ���
        /// <summary>
        /// ���ַ���ת��32λ�����ͱ����ķ���
        /// </summary>
        /// <param name="s">�ַ���</param>
        /// <returns>32λ�����ͱ���</returns>
        private static int ConvertStringToInteger(string s)
        {
            int result = 0;
            int.TryParse(s, out result);
            return result;
        }
        #endregion

        #region ���ַ���ת��64λ�����ͱ����ķ���
        /// <summary>
        /// ���ַ���ת��64λ�����ͱ����ķ���
        /// </summary>
        /// <param name="s">�ַ���</param>
        /// <returns>64λ�����ͱ���</returns>
        private static long ConvertStringToLong(string s)
        {
            long result = 0;
            long.TryParse(s, out result);
            return result;
        }
        #endregion

        #region ���ַ���ת��˫���ȸ����ͱ����ķ���
        /// <summary>
        /// ���ַ���ת��˫���ȸ����ͱ����ķ���
        /// </summary>
        /// <param name="s">�ַ���</param>
        /// <returns>˫���ȸ����ͱ���</returns>
        private static double ConvertStringToDouble(string s)
        {
            double result = 0;
            double.TryParse(s, out result);
            return result;
        }
        #endregion

        #region ���ַ���ת��ʮ�������ֱ����ķ���
        /// <summary>
        /// ���ַ���ת��ʮ�������ֱ����ķ���
        /// </summary>
        /// <param name="s">�ַ���</param>
        /// <returns>ʮ�������ֱ���</returns>
        private static decimal ConvertStringToDecimal(string s)
        {
            decimal result = 0;
            decimal.TryParse(s, out result);
            return Convert.ToDecimal(result.ToString("g0"));
        }
        /// <summary>
        /// �������뺯��,ȥ��С��λ�����0
        /// </summary>
        /// <param name="dcl">Ҫ�����������</param>
        /// <param name="nNum">С��λ��ȡ������ʱ��n=0</param>
        /// <returns></returns>
        public static decimal ChinaRound(decimal dcl, int intNum)
        {
            string strValue = dcl.ToString();
            if (strValue.IndexOf(".") >= 0)
            {
                if (strValue.Substring(strValue.IndexOf(".") + 1).Length > intNum)
                {
                    if (strValue.Substring(strValue.IndexOf(".") + intNum + 1, 1) == "5")
                    {
                        strValue = strValue.Substring(0, strValue.IndexOf(".") + intNum + 1) + "6";
                        dcl = Convert.ToDecimal(strValue);
                    }
                }
            }
            return Convert.ToDecimal(decimal.Round(dcl, intNum).ToString("g0"));//ȥ�������0
        }
        #endregion

        #endregion
    }
}