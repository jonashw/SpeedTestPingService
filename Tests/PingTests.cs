using System.Net.NetworkInformation;
using NUnit.Framework;
using Ping = SpeedTestPingService.Ping;

namespace Tests
{
    [TestFixture]
    public class PingTests
    {
        [Test] public void SpeedTestDotNet() =>
            Assert.That(Ping.SpeedTestDotNetResponds(), Is.EqualTo(IPStatus.Success));

        [Test] public void FastDotCom() =>
            Assert.That(Ping.FastDotComResponds(), Is.EqualTo(IPStatus.Success));
    }
}