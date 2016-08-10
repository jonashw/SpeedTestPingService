using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Timers;

namespace SpeedTestPingService
{
    public partial class SpeedTestPingService : ServiceBase
    {
        private static readonly EventSourceCreationData EventSourceInfo = new EventSourceCreationData("SpeedTestPingService", "Application");
        private readonly EventLog _eventLog;
        private readonly TimeSpan _pingInterval;
        public SpeedTestPingService(TimeSpan pingInterval)
        {
            InitializeComponent();
            _pingInterval = pingInterval;
            if (!EventLog.SourceExists(EventSourceInfo.Source))
            {
                EventLog.CreateEventSource(EventSourceInfo);
            }
            _eventLog = new EventLog
            {
                Source = EventSourceInfo.Source,
                Log = EventSourceInfo.LogName
            };
        }

        protected override void OnStart(string[] args)
        {
            _eventLog.WriteEntry(
                "Service started with ping interval of " + _pingInterval.ToString("g"),
                EventLogEntryType.Information);
            var timer = new Timer
            {
                Interval = _pingInterval.TotalMilliseconds
            };
            timer.Elapsed += (sender, eventArgs) => doPings();
            timer.Start();
            doPings();
        }

        private void doPings()
        {
            var ping = new System.Net.NetworkInformation.Ping();
            foreach (var host in new[] {"www.speedtest.net", "www.fast.com"})
            {
                var logPrefix = $"Pinging {host}... ";
                var response = ping.Send(host);
                if (response == null)
                {
                    _eventLog.WriteEntry(logPrefix + "Response was null", EventLogEntryType.Error);
                }
                else
                {
                    _eventLog.WriteEntry(
                        $"{logPrefix}Received response after {response.RoundtripTime}ms with status={response.Status}",
                        response.Status == IPStatus.Success
                            ? EventLogEntryType.Information
                            : EventLogEntryType.Error);
                }
            }
        }

        protected override void OnStop() =>
            _eventLog.WriteEntry("Service stopped",EventLogEntryType.Information);
    }
}