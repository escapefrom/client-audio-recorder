using AudioDialogRecorder.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioDialogRecorder.Core.Sender
{
    public class ClientAudioSender
    {
        private const string PATH = "send_audio";
        private RequestSender _requestSender;

        public ClientAudioSender()
        {
            _requestSender = new RequestSender();
        }

        public object SendAudio(byte[] data)
            => _requestSender
                .SendPost(PATH, new RecordAudioRequest
                {
                    UserSourceId = "Client",
                    StartDateTime = DateTime.Now,
                    Audio = data
                })
                .Result;
    }
}
