using AudioDialogRecorder.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioDialogRecorder.Core.Sender
{
    public class ManagerAudioSender
    {
        private const string PATH = "send_audio";
        private RequestSender _requestSender;

        public ManagerAudioSender()
        {
            _requestSender = new RequestSender();
        }

        public object SendAudio(byte[] data)
            => _requestSender
                .SendPost(PATH, new RecordAudioRequest
                {
                    UserSourceId = "Admin",
                    StartDateTime = DateTime.Now,
                    Audio = data
                })
                .Result;
    }
}
