using System;
using System.Text.RegularExpressions;
using ServiceStack.Redis;

namespace BpmOnlineConfig.Maintenance
{
    public sealed class Redis : IDisposable
    {
        #region Private: Fields
        private BpmOnlineSite _site;
        //private ConnectionMultiplexer _connectionMultiplexer; 
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
            var connectionString = _site.ConnectionStringsConfig.GetConfigParameterValue("add[@name=\"redis\"]", "connectionString").ToString();
            var hostMatch = Regex.Match(connectionString, @"host=([A-Za-z0-9_.]+)", RegexOptions.IgnoreCase);
            if (hostMatch.Success)
            {
                Host = hostMatch.Groups[1].Value;
            }
            var portMatch = Regex.Match(connectionString, @"port=([A-Za-z0-9_.]+)", RegexOptions.IgnoreCase);
            if (portMatch.Success)
            {
                Port = portMatch.Groups[1].Value;
            }
            var dbMatch = Regex.Match(connectionString, @"db=([A-Za-z0-9_.]+)", RegexOptions.IgnoreCase);
            if (dbMatch.Success)
            {
                Db = dbMatch.Groups[1].Value;
            }
            ServerConnectionString = !string.IsNullOrEmpty(Port) ? Host + ":" + Port : Host;
            _redisClient = new RedisClient(Host, Convert.ToInt32(Port))
            {
                Db = Convert.ToInt32(Db)
            };
            //_connectionMultiplexer = ConnectionMultiplexer.Connect(ServerConnectionString + ",allowAdmin=true");
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
