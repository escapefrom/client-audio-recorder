using System;
using System.Collections.Generic;
using System.Text;
using VisioForge.Shared.NAudio.Wave;

namespace AudioDialogRecorder.Core.Recorder
{
    public class RecorderBase
    {
        protected const int SAMPLE_RATE = 8000;
        protected const int CHANNELS = 2;
        protected const int BITS_PER_SAMPLE = 16;
        protected const int BLOCK_ALIGN = CHANNELS * (BITS_PER_SAMPLE / 8);
        protected const int AVERAGE_BYTES_PERSECOND = SAMPLE_RATE * BLOCK_ALIGN;

        protected WaveFormat createLPCMFormat()
            => WaveFormat.CreateCustomFormat(WaveFormatEncoding.Pcm, SAMPLE_RATE,
                CHANNELS, AVERAGE_BYTES_PERSECOND, BLOCK_ALIGN, BITS_PER_SAMPLE);
    }
}
