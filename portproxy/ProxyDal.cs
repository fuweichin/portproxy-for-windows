using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace portproxy
{
    class ProxyDal
    {
        static string[] directions = new string[] { "v4tov4", "v6tov4", "v4tov6", "v6tov6" };
        static Regex regex = new Regex(@"^(\S+)\s+(\d+)\s+(\S+)\s+(\d+)\s*$", RegexOptions.ECMAScript|RegexOptions.Multiline);
        public bool AddRule(ProxyRule rule)
        {
            ExecResult result = ExecCommand("netsh", "interface portproxy add " + rule.ToString());
            return result.code == 0;
        }
        public bool DeleteRule(ProxyRule rule)
        {
            ExecResult result = ExecCommand("netsh", "interface portproxy delete " + rule.ToShortString());
            return result.code == 0;
        }
        public bool SetRule(ProxyRule rule)
        {
            ExecResult result = ExecCommand("netsh", "interface portproxy set " + rule.ToString());
            return result.code == 0;
        }
        public bool Reset()
        {
            ExecResult result = ExecCommand("netsh", "interface portproxy reset");
            return result.code == 0;
        }
        public List<ProxyRule> GetRules()
        {
            List<ProxyRule> rules = new List<ProxyRule>();
            foreach (string direction in directions)
            {
                ExecResult result = ExecCommand("netsh", "interface portproxy show " + direction);
                Match m = regex.Match(result.output);
                while (m.Success)
                {
                    ProxyRule rule = new ProxyRule();
                    rule.Direction = direction;
                    rule.Listenaddress = m.Groups[1].Captures[0].Value;
                    rule.Listenport = m.Groups[2].Captures[0].Value;
                    rule.Connectaddress = m.Groups[3].Captures[0].Value;
                    rule.Connectport = m.Groups[4].Captures[0].Value;
                    rule.Protocol = "tcp";
                    rules.Add(rule);
                    Console.WriteLine(rule.ToString());
                    m = m.NextMatch();
                }
            }
            return rules;
        }
        public static ExecResult ExecCommand(string cmd,string args)
        {
            Process p = new Process();
            p.StartInfo.FileName = cmd;
            p.StartInfo.Arguments = args;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            string outstr = p.StandardOutput.ReadToEnd();
            string errstr = p.StandardError.ReadToEnd();
            p.WaitForExit();
            int exitCode = p.ExitCode;
            ExecResult result=new ExecResult(p.ExitCode, outstr, errstr);
            return result;
        }
        public List<ProxyRule> ReadRulesFromFile(string pathname)
        {
            List<ProxyRule> rules = new List<ProxyRule>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathname);
            XmlNodeList ruleNodes = xmlDoc.DocumentElement.SelectNodes("/portproxy/rule");
            foreach (XmlNode ruleNode in ruleNodes)
            {
                ProxyRule rule = new ProxyRule();
                rule.Direction=ruleNode.Attributes["direction"].Value;
                rule.Protocol = ruleNode.Attributes["protocol"].Value;
                XmlNode listenElem = ruleNode.SelectSingleNode("listen");
                rule.Listenaddress = listenElem.Attributes["address"].Value;
                rule.Listenport = listenElem.Attributes["port"].Value;
                XmlNode connectElem = ruleNode.SelectSingleNode("connect");
                rule.Connectaddress = connectElem.Attributes["address"].Value;
                rule.Connectport = connectElem.Attributes["port"].Value;
                rules.Add(rule);
            }
            return rules;
        }
        public bool WriteRulesToFile(List<ProxyRule> rules, string pathname)
        {
            XmlTextWriter writer = new XmlTextWriter(pathname, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("portproxy");
            foreach (ProxyRule rule in rules)
            {
                WriteRuleElem(rule,writer);
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            return true;
        }
        public static void WriteRuleElem(ProxyRule rule, XmlTextWriter writer)
        {
            writer.WriteStartElement("rule");
            writer.WriteAttributeString("direction", rule.Direction);
            writer.WriteAttributeString("protocol", rule.Protocol);
                writer.WriteStartElement("listen");
                writer.WriteAttributeString("address", rule.Listenaddress);
                writer.WriteAttributeString("port", rule.Listenport);
                writer.WriteEndElement();
                writer.WriteStartElement("connect");
                writer.WriteAttributeString("address", rule.Connectaddress);
                writer.WriteAttributeString("port", rule.Connectport);
                writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
