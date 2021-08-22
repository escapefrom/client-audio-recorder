using AudioDialogRecorder.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioDialogRecorder.Core.Sender
{
    public class ClientAudioSender
    {
        private const string PATH = "send_audio_";
        private RequestSender _requestSender;
        private GlobalSettings _globalSettings;

        public ClientAudioSender(GlobalSettings globalSettings)
        {
            _requestSender = new RequestSender(globalSettings);
            _globalSettings = globalSettings;
        }

        public object SendAudio(byte[] data)
            => _requestSender
                .SendPost(_globalSettings?.UrlConfig.ClientPointUrl ?? PATH, new RecordAudioRequest
                {
                    ChatSourceId = _globalSettings.ChatSourceId ?? "Chat",
                    UserSourceId = _globalSettings.UserSourceId ?? "Client",
                    StartDateTime = DateTime.Now,
                    AudioData = data
                })
                .Result;
    }
}
