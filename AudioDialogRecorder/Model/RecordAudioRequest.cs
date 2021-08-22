using System;
using System.Collections.Generic;
using System.Text;

namespace AudioDialogRecorder.Model
{
    public class RecordAudioRequest
    {
        public string ChatSourceId;
        public string UserSourceId;
        public DateTime StartDateTime;
        public byte[] Audio;
    }
}
