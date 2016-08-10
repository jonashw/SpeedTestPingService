using System;
using System.Linq;
using System.ServiceProcess;

namespace SpeedTestPingService
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var pingInterval = TimeSpan.FromMinutes(tryParseInt(args.FirstOrDefault()) ?? 15);
            ServiceBase.Run(new ServiceBase[]
            {
                new SpeedTestPingService(pingInterval)
            });
        }

        private static int? tryParseInt(string str)
        {
            if (str == null)
            {
                return null;
            }
            int i;
            return int.TryParse(str, out i)
                ? i
                : (int?) null;
        }
    }
}
