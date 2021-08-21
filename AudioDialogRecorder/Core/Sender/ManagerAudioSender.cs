using AudioDialogRecorder.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioDialogRecorder.Core.Sender
{
    public class ManagerAudioSender
    {
        private const string PATH = "managerAudio";
        private RequestSender _requestSender;

        public ManagerAudioSender()
        {
            _requestSender = new RequestSender();
        }

        public object SendAudio(byte[] data)
            => _requestSender
                .SendPost(PATH, new RecordAudioRequest { IsManager = true, StartDateTime = DateTime.Now, Audio = data })
                .Result;
    }
}
