using System;
using System.Collections.Generic;
using System.Text;

namespace AudioDialogRecorder.Model
{
    public class RecordAudioRequest
    {
        public bool IsManager;
        public DateTime StartDateTime;
        public byte[] Audio;
    }
}
