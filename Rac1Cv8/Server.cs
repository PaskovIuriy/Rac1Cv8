﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rac1Cv8
{
    public class Server
    {
        public string UID { get; private set; }
        public string AgentHost { get; private set; }
        public int AgentPort { get; private set; }
        public PortRange PortRange { get; private set; }
        public string Name { get; private set; }
        public string Using { get; private set; }
        public string DedicateManagers { get; private set; }
        public int InfobaseLimit { get; private set; }
        public long MemoryLimit { get; private set; }
        public int ConnectionsLimit { get; private set; }
        public long SafeWPMemoryLimit { get; private set; }
        public long SafeCallMemoryLimit { get; private set; }
        public int ClusterPort { get; private set; }

        public string ClusterUID { get; private set; }

        private string RacPath;
        private string ConnStr;
        private string ClusterUser;
        private string ClusterPwd;

        public Server()
        {

        }

        public Server(
            string ClusterUID,
            string[] properties,               //server string properties
            string RacPath,
            string ConnStr,
            string ClusterUser,
            string ClusterPwd
            )
        {

            InitializeProperties(properties);
            this.RacPath = RacPath;
            this.ConnStr = ConnStr;
            this.ClusterUser = ClusterUser;
            this.ClusterPwd = ClusterPwd;
            this.ClusterUID = ClusterUID;
        }

        private void InitializeProperties(string[] properties)
        {
            UID = properties[0];
            AgentHost = properties[1];
            AgentPort = int.TryParse(properties[2], out int _AgentPort) ? _AgentPort : -1;
            PortRange = new PortRange(properties[3]);
            Name = properties[4];
            Using = properties[5];
            DedicateManagers = properties[6];
            InfobaseLimit = int.TryParse(properties[7], out int _InfobaseLimit) ? _InfobaseLimit : -1;
            MemoryLimit = long.TryParse(properties[8], out long _MemoryLimit) ? _MemoryLimit : -1;
            ConnectionsLimit = int.TryParse(properties[9], out int _ConnectionsLimit) ? _ConnectionsLimit : -1;
            SafeWPMemoryLimit = long.TryParse(properties[10], out long _SafeWPMemoryLimit) ? _SafeWPMemoryLimit : -1;
            SafeCallMemoryLimit = long.TryParse(properties[11], out long _SafeCallMemoryLimit) ? _SafeCallMemoryLimit : -1;
            ClusterPort = int.TryParse(properties[12], out int _ClusterPort) ? _ClusterPort : -1;
        }
    }

    public class PortRange
    {
        public int HighBound { get; private set; }
        public int LowBound { get; private set; }

        public PortRange(string str)
        {
            ParseStr(str);
        }

        private void ParseStr(string str)
        {
            int split_index = str.IndexOf(":");

            HighBound = int.TryParse(str.Substring(0, str.Length - split_index), out int _HighBound) ? _HighBound : -1;
            LowBound = int.TryParse(str.Substring(split_index + 1, str.Length - (str.Length - split_index + 1)), out int _LowBound) ? _LowBound : -1;
        }
    }
}