using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Linq;

namespace BpmOnlineConfig
{
    public class ConfigFile
    {
        private readonly XmlNode root;
        private string fullFileName;
        private XmlDocument file;
        private bool changed;

        private XmlNode CreateNewNode(string sectionXPath, string attributeName)
        {
            if (sectionXPath == null)
            {
                return null;
            }
            XmlNode parentNode;
            var slashIndex = sectionXPath.LastIndexOf('/');
            if (slashIndex < 0)
            {
                parentNode = root;
            }
            else
            {
                var parentSectionXPath = sectionXPath.Substring(0, sectionXPath.LastIndexOf('/'));
                parentNode = root.SelectSingleNode(parentSectionXPath);
            }
            if (parentNode == null)
            {
                return null;
            }
            var sectionName = sectionXPath.Split('/').Last();
            var keyAttributeName = String.Empty;
            var keyAttributeValue = String.Empty;
            if (sectionXPath.Contains("@"))
            {
                var matchPattern = new Regex("\\[@(\\w+)=\"(\\w+)\"\\]");
                var match = matchPattern.Match(sectionName);
                keyAttributeName = match.Groups[1].Value;
                keyAttributeValue = match.Groups[2].Value;
                var replacePattern = new Regex(@"\[@.*\]");
                sectionName = replacePattern.Replace(sectionName, String.Empty);
            }
            var newNode = file.CreateNode(XmlNodeType.Element, sectionName, "");
            if (keyAttributeName != String.Empty)
            {
                newNode.Attributes.Append(file.CreateAttribute(keyAttributeName));
                newNode.Attributes[keyAttributeName].Value = keyAttributeValue;
            }
            newNode.Attributes.Append(file.CreateAttribute(attributeName));
            parentNode.AppendChild(newNode);
            return newNode;
        }

        private void SetNodeAttibuteValue(string sectionXPath, XmlNode node, string attributeName,
            Object value, bool createIfNotExists = false)
        {
            if (node == null)
            {
                if (createIfNotExists)
                {
                    node = CreateNewNode(sectionXPath, attributeName);
                }
                else
                {
                    return;
                }
                if (node == null)
                {
                    return;
                }
            }
            var strValue = (value is bool) ? value.ToString().ToLower() : value.ToString();
            if (node.Attributes[attributeName] == null)
            {
                node.Attributes.Append(file.CreateAttribute(attributeName));
            }
            node.Attributes[attributeName].Value = strValue;
            changed = true;
        }

        #region Public: Methods
        public ConfigFile(string path, string fileName)
        {
            file = new XmlDocument();
            fullFileName = Path.Combine(path, fileName);
            file.Load(fullFileName);
            root = file.DocumentElement;
        }

        public void SetConfigParameterValue(string sectionXPath, string attributeName,
            Object value, bool createIfNotExists = false)
        {
            XmlNode node = root.SelectSingleNode(sectionXPath);
            SetNodeAttibuteValue(sectionXPath, node, attributeName, value, createIfNotExists);
        }

        public object GetConfigParameterValue(string sectionXPath, string attributeName)
        {
            XmlNode node = root.SelectSingleNode(sectionXPath);
            if (node == null)
            {
                return null;
            }
            if (node.Attributes[attributeName] == null)
            {
                return null;
            }
            return (node == null) ? null : node.Attributes[attributeName].Value;
        }

        public void SetConfigParametersValue(string sectionXPath, string attributeName,
            Object value, bool createIfNotExists = false)
        {
            XmlNodeList nodes = root.SelectNodes(sectionXPath);
            if ((nodes == null) || (nodes.Count == 0))
            {
                return;
            }
            foreach (XmlNode node in nodes)
            {
                SetNodeAttibuteValue(sectionXPath, node, attributeName, value, createIfNotExists);    
            }
        }

        public void Save()
        {
            if (changed)
            {
                file.Save(fullFileName);
            }
        } 
        #endregion

        internal void RemoveConfigSection(string sectionXPath)
        {
            XmlNode node = file.SelectSingleNode(sectionXPath);
            if ((node == null) || (node.ParentNode == null))
            {
                return;
            }
            node.ParentNode.RemoveChild(node);
            changed = true;
        }
    }
}
