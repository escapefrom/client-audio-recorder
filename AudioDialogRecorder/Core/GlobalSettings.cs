using AudioDialogRecorder.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioDialogRecorder.Core
{
    public class GlobalSettings
    {
        private static GlobalSettings _instance;
        public Config UrlConfig;
        public string ChatSourceId;
        public string UserSourceId;

        private GlobalSettings()
        {
            var rnd = new Random(DateTime.Now.Minute * DateTime.Now.Second * DateTime.Now.Millisecond);
            ChatSourceId = rnd.Next().ToString();
            UserSourceId = rnd.Next().ToString();
        }

        public static GlobalSettings GetInstance()
            => _instance != null ? _instance : new GlobalSettings();
    }
}
