﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Preferences;

namespace QuickShare.Droid.Classes
{
    internal class Settings
    {
        Context context;

        public Settings(Context _context)
        {
            context = _context;
        }

        internal string CloudClipboardText
        {
            get
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                return prefs.GetString("CloudClipboardText", "");
            }
            set
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString("CloudClipboardText", value);
                editor.Apply();
            }
        }

        internal CloudClipboardReceiveMode CloudClipboardReceiveMode
        {
            get
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                return (CloudClipboardReceiveMode)prefs.GetInt("CloudClipboardReceiveSetting", (int)CloudClipboardReceiveMode.Notification);
            }
            set
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutInt("CloudClipboardReceiveSetting", (int)value);
                editor.Apply();
            }
        }

        internal bool UseLegacyUI
        {
            get
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                return prefs.GetBoolean("UseLegacyUI", false);
            }
            set
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutBoolean("UseLegacyUI", value);
                editor.Apply();
            }
        }

        internal bool AllowToStayInBackground
        {
            get
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                return prefs.GetBoolean("AllowToStayInBackground", true);
            }
            set
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutBoolean("AllowToStayInBackground", value);
                editor.Apply();
            }
        }

        internal Version LatestShownWhatsNewVersion
        {
            get
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                string versionText = prefs.GetString("LatestShownWhatsNewVersion", "0.0.0.0");

                if (Version.TryParse(versionText, out Version v))
                    return v;
                else
                    return new Version("0.0.0.0");
            }
            set
            {
                string versionText = value.ToString();

                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString("LatestShownWhatsNewVersion", versionText);
                editor.Apply();
            }
        }
    }

    internal enum CloudClipboardReceiveMode
    {
        Notification = 0,
        Automatic = 1,
    }
}