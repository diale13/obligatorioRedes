using Common;
using Common.Interfaces;
using Services;
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Server
{
    public static class RemmotingManager
    {
        static readonly ISettingsManager SettingsMgr = new SettingsManager();

        public static TcpChannel InitiateRemotingSessionService()
        {
            var port = Int32.Parse(SettingsMgr.ReadSetting(ServerConfig.SessionServicePort));
            var tcpSessionChannel = new TcpChannel(port);
            ChannelServices.RegisterChannel(tcpSessionChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(SessionService),
                "SessionService",
                WellKnownObjectMode.Singleton);
            return tcpSessionChannel;
        }

        public static TcpChannel InitiateRemotingApiUserService()
        {
            var port = Int32.Parse(SettingsMgr.ReadSetting(ServerConfig.ApiUserServicePort));
            var apiUserServiceChannel = new TcpChannel(port);
            ChannelServices.RegisterChannel(apiUserServiceChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(SessionService),
                "ApiUserService",
                WellKnownObjectMode.Singleton);
            return apiUserServiceChannel;
        }
    }
}
