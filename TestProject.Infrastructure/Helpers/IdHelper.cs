using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TestProject.Infrastructure.Helpers
{
    public class IdHelper
    {


        public static string GetGuidHash()
        {
            return Guid.NewGuid().ToString().GetHashCode().ToString("x");
        }
        /// <summary>
        /// 无 '-' 的guid串
        /// </summary>
        /// <returns></returns>
        public static string GetGuidN() {
            return Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// 生成一个长整型，可以转成19字节长的字符串
        /// </summary>
        /// <returns>System.Int64.</returns>
        public static long GetLongId()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 生成16个字节长度的数据与英文组合串
        /// </summary>
        public static string GenerateStr()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }

            return String.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStampId() {
            var ts = DateTimeHelper.GetNowTimestamp();
            string strRandomResult = NextRandom(1000, 1).ToString("0000");
            return ts + strRandomResult;
        }

        /// <summary>
        /// yyyyMMddHHmmssffff 格式id
        /// </summary>
        /// <returns></returns>
        public static string GetOrderNumber()
        {
            string strDateTimeNumber = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string strRandomResult = NextRandom(1000, 1).ToString("0000");
            return strDateTimeNumber + strRandomResult;
        }

        #region private

        /// <summary>
        /// 参考：msdn上的RNGCryptoServiceProvider例子
        /// </summary>
        /// <param name="numSeeds"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static int NextRandom(int numSeeds, int length)
        {
            // Create a byte array to hold the random value.
            byte[] randomNumber = new byte[length];
            // Create a new instance of the RNGCryptoServiceProvider.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            // Fill the array with a random value.
            rng.GetBytes(randomNumber);
            // Convert the byte to an uint value to make the modulus operation easier.
            uint randomResult = 0x0;
            for (int i = 0; i < length; i++)
            {
                randomResult |= ((uint)randomNumber[i] << ((length - 1 - i) * 8));
            }

            return (int)(randomResult % numSeeds) + 1;
        }



      
        #endregion


    }
}
