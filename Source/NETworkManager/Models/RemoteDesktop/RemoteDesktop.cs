﻿using Microsoft.Win32;
using NETworkManager.Models.Settings;

namespace NETworkManager.Models.RemoteDesktop
{
    public static class RemoteDesktop
    {
        // ReSharper disable once InconsistentNaming
        private const string CLSID_MsRdpClient9NotSafeForScripting = @"8B918B82-7985-4C24-89DF-C33AD2BBFBCD";

        public static bool IsRDP8Dot1Available
        {
            get
            {
                var msRdpClient9NotSafeForScriptingKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\CLSID\{" + CLSID_MsRdpClient9NotSafeForScripting + "}", false);

                return msRdpClient9NotSafeForScriptingKey != null;
            }
        }

        public static RemoteDesktopSessionInfo CreateSessionInfo(ProfileInfo profileInfo = null)
        {
            var info = new RemoteDesktopSessionInfo
            {
                Hostname = profileInfo?.Host,

                // Display
                AdjustScreenAutomatically = profileInfo != null && profileInfo.RemoteDesktop_OverrideDisplay ? profileInfo.RemoteDesktop_AdjustScreenAutomatically : SettingsManager.Current.RemoteDesktop_AdjustScreenAutomatically,
                UseCurrentViewSize = profileInfo != null && profileInfo.RemoteDesktop_OverrideDisplay ? profileInfo.RemoteDesktop_UseCurrentViewSize : SettingsManager.Current.RemoteDesktop_UseCurrentViewSize,
                DesktopWidth = profileInfo != null && profileInfo.RemoteDesktop_OverrideDisplay ? (profileInfo.RemoteDesktop_UseCustomScreenSize ? profileInfo.RemoteDesktop_CustomScreenWidth : profileInfo.RemoteDesktop_ScreenWidth) : (SettingsManager.Current.RemoteDesktop_UseCustomScreenSize ? SettingsManager.Current.RemoteDesktop_CustomScreenWidth : SettingsManager.Current.RemoteDesktop_ScreenWidth),
                DesktopHeight = profileInfo != null && profileInfo.RemoteDesktop_OverrideDisplay ? (profileInfo.RemoteDesktop_UseCustomScreenSize ? profileInfo.RemoteDesktop_CustomScreenHeight : profileInfo.RemoteDesktop_ScreenHeight) : (SettingsManager.Current.RemoteDesktop_UseCustomScreenSize ? SettingsManager.Current.RemoteDesktop_CustomScreenHeight : SettingsManager.Current.RemoteDesktop_ScreenHeight),
                ColorDepth = profileInfo != null && profileInfo.RemoteDesktop_OverrideColorDepth ? profileInfo.RemoteDesktop_ColorDepth : SettingsManager.Current.RemoteDesktop_ColorDepth,

                // Network
                Port = profileInfo != null && profileInfo.RemoteDesktop_OverridePort ? profileInfo.RemoteDesktop_Port : SettingsManager.Current.RemoteDesktop_Port,

                // Authentication
                EnableCredSspSupport = profileInfo != null && profileInfo.RemoteDesktop_OverrideCredSspSupport ? profileInfo.RemoteDesktop_EnableCredSspSupport : SettingsManager.Current.RemoteDesktop_EnableCredSspSupport,
                AuthenticationLevel = profileInfo != null && profileInfo.RemoteDesktop_OverrideAuthenticationLevel ? profileInfo.RemoteDesktop_AuthenticationLevel : SettingsManager.Current.RemoteDesktop_AuthenticationLevel,

                // Keyboard
                KeyboardHookMode = profileInfo != null && profileInfo.RemoteDesktop_OverrideApplyWindowsKeyCombinations ? profileInfo.RemoteDesktop_KeyboardHookMode : SettingsManager.Current.RemoteDesktop_KeyboardHookMode,

                // Local devices and resources
                RedirectClipboard = profileInfo != null && profileInfo.RemoteDesktop_OverrideRedirectClipboard ? profileInfo.RemoteDesktop_RedirectClipboard : SettingsManager.Current.RemoteDesktop_RedirectClipboard,
                RedirectDevices = profileInfo != null && profileInfo.RemoteDesktop_OverrideRedirectDevices ? profileInfo.RemoteDesktop_RedirectDevices : SettingsManager.Current.RemoteDesktop_RedirectDevices,
                RedirectDrives = profileInfo != null && profileInfo.RemoteDesktop_OverrideRedirectDrives ? profileInfo.RemoteDesktop_RedirectDrives : SettingsManager.Current.RemoteDesktop_RedirectDrives,
                RedirectPorts = profileInfo != null && profileInfo.RemoteDesktop_OverrideRedirectPorts ? profileInfo.RemoteDesktop_RedirectPorts : SettingsManager.Current.RemoteDesktop_RedirectPorts,
                RedirectSmartCards = profileInfo != null && profileInfo.RemoteDesktop_OverrideRedirectSmartcards ? profileInfo.RemoteDesktop_RedirectSmartCards : SettingsManager.Current.RemoteDesktop_RedirectSmartCards,

                // Experience
                PersistentBitmapCaching = profileInfo != null && profileInfo.RemoteDesktop_OverridePersistentBitmapCaching ? profileInfo.RemoteDesktop_PersistentBitmapCaching : SettingsManager.Current.RemoteDesktop_PersistentBitmapCaching,
                ReconnectIfTheConnectionIsDropped = profileInfo != null && profileInfo.RemoteDesktop_OverrideReconnectIfTheConnectionIsDropped ? profileInfo.RemoteDesktop_ReconnectIfTheConnectionIsDropped : SettingsManager.Current.RemoteDesktop_ReconnectIfTheConnectionIsDropped,

                // Performance
                ConnectionSpeed = profileInfo != null && profileInfo.RemoteDesktop_OverrideConnectionSpeed ? profileInfo.RemoteDesktop_ConnectionSpeed : SettingsManager.Current.RemoteDesktop_ConnectionSpeed,
                DesktopBackground = profileInfo != null && profileInfo.RemoteDesktop_OverrideDesktopBackground ? profileInfo.RemoteDesktop_DesktopBackground : SettingsManager.Current.RemoteDesktop_DesktopBackground,
                FontSmoothing = profileInfo != null && profileInfo.RemoteDesktop_OverrideFontSmoothing ? profileInfo.RemoteDesktop_FontSmoothing : SettingsManager.Current.RemoteDesktop_FontSmoothing,
                DesktopComposition = profileInfo != null && profileInfo.RemoteDesktop_OverrideDesktopComposition ? profileInfo.RemoteDesktop_DesktopComposition : SettingsManager.Current.RemoteDesktop_DesktopComposition,
                ShowWindowContentsWhileDragging = profileInfo != null && profileInfo.RemoteDesktop_OverrideShowWindowContentsWhileDragging ? profileInfo.RemoteDesktop_ShowWindowContentsWhileDragging : SettingsManager.Current.RemoteDesktop_ShowWindowContentsWhileDragging,
                MenuAndWindowAnimation = profileInfo != null && profileInfo.RemoteDesktop_OverrideMenuAndWindowAnimation ? profileInfo.RemoteDesktop_MenuAndWindowAnimation : SettingsManager.Current.RemoteDesktop_MenuAndWindowAnimation,
                VisualStyles = profileInfo != null && profileInfo.RemoteDesktop_OverrideVisualStyles ? profileInfo.RemoteDesktop_VisualStyles : SettingsManager.Current.RemoteDesktop_VisualStyles,
            };

            return info;
        }
    }
}
