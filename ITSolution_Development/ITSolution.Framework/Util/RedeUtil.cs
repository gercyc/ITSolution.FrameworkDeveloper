using ITE.Entidades.POCO.TI;
using System;
using System.Net;
using System.Net.Sockets;

namespace ITSolution.Framework.Util
{
    public class RedeUtil
    {
        /// <summary>
        /// Get local computer name
        /// Get local computer host name using static method Dns.GetHostName.
        /// </summary>
        /// <returns></returns>
        public static string GetHostName()
        {
            //Todos OK
            //Dns.GetHostName()
            //var x = System.Environment.MachineName;
            //var x = System.Windows.Forms.SystemInformation.ComputerName;
            string hostName = Dns.GetHostName();
            return hostName;
        }
   
        /// <summary>
        /// Obtém o endereço de ip local
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
        
        /// <summary>
        /// Get local IP address list
        /// Get list of computer IP addresses using static method Dns.GetHostAd­dresses.
        /// To get list of local IP addresses pass local computer name as a parameter to the method.
        /// </summary>
        /// <returns></returns>
        public static IPAddress[] GetLocalIPAddressList()
        {

            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

            return localIPs;
        }

        /// <summary>
        /// Check whether an IP address is local
        /// The following method checks if a given host name or IP address is local.First, it gets all IP addresses of the given host, then it gets all IP addresses of the local computer and finally it compares both lists.If any host IP equals to any of local IPs, the host is a local IP.It also checks whether the host is a loopback address (localhost / 127.0.0.1).
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static bool IsLocalIpAddress(string host)
        {
            try
            { // get host IP addresses
                IPAddress[] hostIPs = Dns.GetHostAddresses(host);
                // get local IP addresses
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                // test if any host IP equals to any local IP or to localhost
                foreach (IPAddress hostIP in hostIPs)
                {
                    // is localhost
                    if (IPAddress.IsLoopback(hostIP)) return true;
                    // is local address
                    foreach (IPAddress localIP in localIPs)
                    {
                        if (hostIP.Equals(localIP)) return true;
                    }
                }
            }
            catch { }
            return false;
        }

        /// <summary>            
        /// Check if you're connected or not
        /// </summary>
        /// <returns></returns>true ou false
        public static bool IsNetworkAvailable()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        public Computer ReportCmputer
        {
            get {

                var pc = new Computer
                {
                    Hd = "",
                    MemoriaRam = "",
                    NomePlacaMae = "",
                    Processador = "",
                    NomeComputador = GetHostName(),
                    GrupoTrabalho = "",
                };

                return pc;
            }
        }

    }
}
