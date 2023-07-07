using System;
using System.Security.Cryptography;
using System.Text;

namespace TestProject.Infrastructure.Helpers
{
    public static class Md5
    {
        public static string Encrypt(string str)
        {

            string pwd = String.Empty;

            MD5 md5 = MD5.Create();

            // 编码UTF8/Unicode　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            // 转换成字符串
            for (int i = 0; i < s.Length; i++)
            {
                //格式后的字符是小写的字母
                //如果使用大写（X）则格式后的字符是大写字符
                pwd = pwd + s[i].ToString("X");

            }

            return pwd;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strData">预加密的数据</param>
        /// <returns>加密后的数据</returns>
        public static string Crypt_MD5_Encode(this string strData)
        {
            return Crypt_MD5_Encode(strData, 16);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strData">预加密的数据</param>
        /// <param name="length">加密串长度 16/32</param>
        /// <returns>加密后的数据</returns>
        public static string Crypt_MD5_Encode(string strData, int length)
        {
            strData = "@^#c&d" + strData + ":>|%y2015";
            byte[] bytes = Encoding.Default.GetBytes(strData);
            byte[] buffer2 = new MD5CryptoServiceProvider().ComputeHash(bytes);
            string str = string.Empty;
            int len = buffer2.Length;
            for (int i = 0; i < len; i++)
            {
                str = str + buffer2[i].ToString("X2");
            }

            if (length == 16) str = str.Substring(8, 16);
            return str;
        }



    }
}
