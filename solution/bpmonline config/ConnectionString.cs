using System.Text.RegularExpressions;

namespace BpmOnlineConfig
{
    class ConnectionString
    {
        protected string ConnectionStringText { get; set; }

        public ConnectionString(string connectionString)
        {
            ConnectionStringText = connectionString.Trim();
        }

        public string GetAttribute(string attributeName)
        {
            var match = Regex.Match(ConnectionStringText, attributeName + @"\s*=\s*([A-Za-z0-9_.-]*)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return null;
        }

        public void SetAttribute(string attributeName, string attributeValue)
        {
            var value = GetAttribute(attributeName);
            if (value == attributeValue)
            {
                return;
            }
            if (value != null)
            {
                var replacePattern = string.Format(@"({0}\s*=\s*)([A-Za-z0-9_.-]*)", attributeName);
                var regex = new Regex(replacePattern, RegexOptions.IgnoreCase);
                var replacement = string.Format("$1{0}", attributeValue);
                ConnectionStringText = regex.Replace(ConnectionStringText, replacement);
                return;
            }
            if ((ConnectionStringText.Length > 0) && !ConnectionStringText.EndsWith(";"))
            {
                ConnectionStringText += ";";
            }
            var attributeStr = string.Format(" {0}={1};", attributeName, attributeValue);
            ConnectionStringText += attributeStr;
        }

        public override string ToString()
        {
            return ConnectionStringText;
        }
    }
}
