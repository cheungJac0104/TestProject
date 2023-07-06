
namespace TestProject.Helper
{
    public static class DateTimeConverter
    {

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


        public static long GetUnixTimestamp()
        {
          DateTimeOffset now = DateTimeOffset.UtcNow;
          return now.ToUnixTimeSeconds();
        }

        public static string ConvertDateString(string dat, string dateFormat)
        {
            string _rtn = null; 
            try
            {
                bool _result = DateTime.TryParse(dat, out DateTime _dat);
                _rtn = _result ? _dat.ToString(dateFormat) : null;
      
            }
            catch (Exception ex)
            {
                _rtn = null;
            }
            return _rtn;
        }


        public static string CreateDateString(string timestamp, string dateFormat)
        {
            //https://blog.yowko.com/timezoneinfo-time-zone-id-not-found/
            string _rtn = null; 
            try
            {
                IConfiguration _configuration;
                _configuration = ConfigurationManager.AppSetting;
                var timeZones = TimeZoneInfo.GetSystemTimeZones();
                string _timeZoneById = _configuration.GetValue<string>("SystemSettings:timeZoneId");
                if (string.IsNullOrEmpty(_timeZoneById)) {
                    //For Linux - Asia/Hong_Kong, For Window - China Standard Time
                    _timeZoneById = "Asia/Hong_Kong";  
                }

                var tz = TimeZoneInfo.FindSystemTimeZoneById(_timeZoneById);


                double unixTimeStamp = Convert.ToDouble(timestamp);
                var dtDateTime = Epoch.AddSeconds(unixTimeStamp);  
                System.DateTime dtDateTime_Local = TimeZoneInfo.ConvertTimeFromUtc(dtDateTime, tz); 
                _rtn = dtDateTime_Local.ToString(dateFormat);

                //System.DateTime dtDateTime2 = dtDateTime.AddSeconds(unixTimeStamp); // <-- is this ToLocalTime() already take care of using server timezone?
                //System.DateTime dtDateTime3 = TimeZoneInfo.ConvertTimeFromUtc(dtDateTime2, tz);
                //System.DateTime dtDateTime1 = dtDateTime.AddSeconds( unixTimeStamp ).ToLocalTime();  



            }
            catch (Exception ex)
            {
                _rtn = null;
            }
            return _rtn;
        }

        public static int ConvertToTimestamp(this DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch;
            return  (int)elapsedTime.TotalSeconds;
        }
    }
}
