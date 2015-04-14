using System;
using System.Text.RegularExpressions;
using ServiceStack.Redis;

namespace BpmOnlineConfig.Maintenance
{
    public sealed class Redis : IDisposable
    {
        #region Private: Fields
        private BpmOnlineSite _site;
        private RedisClient _redisClient;
        #endregion

        #region Public: Properties
        public string Host { get; set; }
        public string Port { get; set; }
        public string Db { get; set; }
        public string ServerConnectionString { get; set; } 
        #endregion

        public Redis(BpmOnlineSite site)
        {
            _site = site;
        }

        public void Connect()
        {
            var connectionStringText = _site.ConnectionStringsConfig.GetConfigParameterValue("add[@name=\"redis\"]", "connectionString").ToString();
            var connectionString = new ConnectionString(connectionStringText);
            Host = connectionString.GetAttribute("host");
            Port = connectionString.GetAttribute("port");
            Db = connectionString.GetAttribute("db");
            ServerConnectionString = !string.IsNullOrEmpty(Port) ? Host + ":" + Port : Host;
            _redisClient = new RedisClient(Host, Convert.ToInt32(Port))
            {
                Db = Convert.ToInt32(Db)
            };
        }

        public void FlushCurrentSiteDb()
        {
            _redisClient.FlushDb();
        }

        public void Dispose()
        {
            if (_redisClient != null)
            {
                _redisClient.Dispose();
            }
        }
    }
}
