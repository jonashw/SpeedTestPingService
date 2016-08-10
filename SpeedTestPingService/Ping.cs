using System.Net.NetworkInformation;

namespace SpeedTestPingService
{
    public static class Ping
    {
        private static readonly System.Net.NetworkInformation.Ping Client = new System.Net.NetworkInformation.Ping();
        public static IPStatus? SpeedTestDotNetResponds() => Client.Send("www.speedtest.net")?.Status;
        public static IPStatus? FastDotComResponds()      => Client.Send("www.fast.com")?.Status;
    }
}