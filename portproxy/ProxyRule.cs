using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace portproxy
{
    public class ProxyRule
    {
        public string Direction { get; set; }
        public string Listenaddress { get; set; }
        public string Listenport { get; set; }
        public string Connectaddress { get; set; }
        public string Connectport { get; set; }
        public string Protocol { get; set; }

        public override bool Equals(Object obj)
        {
            ProxyRule that = obj as ProxyRule;
            if (that == null)
                return false;
            return Direction == that.Direction && Listenaddress == that.Listenaddress && Listenport == that.Listenport;
        }
        public override int GetHashCode()
        {
            return (Direction+Listenaddress+Listenport).GetHashCode();
        }
        public override string ToString()
        {
            return Direction + " listenaddress=" + Listenaddress + " listenport=" + Listenport + " connectaddress=" + Connectaddress + " connectport=" + Connectport + " protocol=" + Protocol;
        }
        public string ToShortString()
        {
            return Direction + " listenaddress=" + Listenaddress + " listenport=" + Listenport;
        }
        public string[] ToSubitems()
        {
            return new string[] { Direction, Listenaddress, Listenport,Connectaddress, Connectport, Protocol };
        }
        public static ProxyRule FromSubitems(string[] items)
        {
            ProxyRule rule = new ProxyRule();
            rule.Direction = items[0];
            rule.Listenaddress = items[1];
            rule.Listenport = items[2];
            rule.Connectaddress = items[3];
            rule.Connectport = items[4];
            rule.Protocol = items[5];
            return rule;
        }
    }
}
