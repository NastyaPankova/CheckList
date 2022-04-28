﻿namespace Settings.Interface;

public interface IIdentityServerConnectSettings
{
    string Url { get; }
    string ClientId { get; }
    string ClientSecret { get; }
    bool RequireHttps { get; }
}
