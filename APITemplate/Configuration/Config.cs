namespace Configuration
{
    /// <summary>
    /// Global configuration.
    /// </summary>
    public class Config
    {
        public string DBConnectionString
        {
            get
            {
#if DEBUG
                return "Data Source=localhost;Database=MainDB;User ID=sa;PWD=P@ssw3rd;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
#endif
#if RELEASE
                return "Data Source=localhost\\SQLEXPRESS;Database=ProductDatabase;Persist Security Info=False;User ID=ProductionLogin;PWD=password;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
#endif
            }
        }
        public string RedisConnectionString
        {
            get
            {
#if DEBUG
                return "localhost:6379,localhost:6379,allowAdmin=true";
#endif
#if RELEASE
                return "redis0:6380,redis1:6380,allowAdmin=true";
#endif
            }
        }

        public TimeSpan LoginTimeout
        {
            get
            {
#if DEBUG
                return TimeSpan.FromMinutes(10);
#endif
#if RELEASE
               return TimeSpan.FromMinutes(10);
#endif
            }
        }

        public TimeSpan EmailVerifyExpireSeconds
        {
            get
            {
#if DEBUG
                return TimeSpan.FromSeconds(86400);
#endif
#if RELEASE
               return TimeSpan.FromSeconds(86400);;
#endif
            }
        }
        public byte[] Salt
        {
            get
            {
                return Convert.FromBase64String("ewU3FxHlcGAY2rZoB45jWM18PjE4fzypwkJcHwFXorc=");
            }
        }
    }
}