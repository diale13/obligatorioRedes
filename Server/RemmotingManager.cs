using Common;
using Common.Interfaces;
using Services;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;

namespace Server
{
    public static class RemmotingManager
    {
        static readonly ISettingsManager SettingsMgr = new SettingsManager();
        public static TcpChannel InitiateRemotingSessionService()
        {
            var port = Int32.Parse(SettingsMgr.ReadSetting(ServerConfig.SessionServicePort));
            var tcpSessionChannel = (TcpChannel)GetChannel("sessionChannel",port, false);
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
            var apiUserServiceChannel = (TcpChannel)(TcpChannel)GetChannel("apiUserChannel", port, false);
            ChannelServices.RegisterChannel(apiUserServiceChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ApiUserService),
                "ApiUserService",
                WellKnownObjectMode.Singleton);
            return apiUserServiceChannel;
        }

        public static IChannel GetChannel(string name,int tcpPort, bool isSecure)
        {
            BinaryServerFormatterSinkProvider serverProv =
                new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = TypeFilterLevel.Full;
            IDictionary propBag = new Hashtable();
            propBag["port"] = tcpPort;
            propBag["typeFilterLevel"] = TypeFilterLevel.Full;
            propBag["name"] = name;
            if (isSecure)
            {
                propBag["secure"] = isSecure;
                propBag["impersonate"] = false;
            }
            return new TcpChannel(
                propBag, null, serverProv);
        }

    }
}
