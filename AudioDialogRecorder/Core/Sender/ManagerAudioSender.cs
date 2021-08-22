using AudioDialogRecorder.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AudioDialogRecorder.Core.Sender
{
    public class ManagerAudioSender
    {
        private const string PATH = "send_audio";
        private RequestSender _requestSender;
        private GlobalSettings _globalSettings;

        public ManagerAudioSender(GlobalSettings globalSettings)
        {
            _requestSender = new RequestSender(globalSettings);
            _globalSettings = globalSettings;
        }

        public object SendAudio(byte[] data)
            => _requestSender
                .SendPost(_globalSettings?.UrlConfig.ManagerPointUrl ?? PATH, new RecordAudioRequest
                {
                    ChatSourceId = _globalSettings.ChatSourceId ?? "AudioChat",
                    UserSourceId = _globalSettings.UserSourceId ?? "SomeAudio",
                    StartDateTime = DateTime.Now,
                    AudioData = data
                })
                .Result;
    }
}
