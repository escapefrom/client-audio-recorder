using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AudioDialogRecorder.Core.Sender;
using NAudio.Wave;
using VisioForge.Shared.NAudio.Wave;
using VisioForge.Shared.NAudio.Wave.SampleProviders;
using IWaveProvider = VisioForge.Shared.NAudio.Wave.IWaveProvider;
using RawSourceWaveStream = VisioForge.Shared.NAudio.Wave.RawSourceWaveStream;
using StoppedEventArgs = VisioForge.Shared.NAudio.Wave.StoppedEventArgs;
using Wave32To16Stream = VisioForge.Shared.NAudio.Wave.Wave32To16Stream;
using WaveFileReader = NAudio.Wave.WaveFileReader;
using WaveFormat = VisioForge.Shared.NAudio.Wave.WaveFormat;
using WaveFormatEncoding = VisioForge.Shared.NAudio.Wave.WaveFormatEncoding;
using WaveInEventArgs = VisioForge.Shared.NAudio.Wave.WaveInEventArgs;

namespace AudioDialogRecorder.Core.Recorder
{
    public class SpeakerRecorder : RecorderBase
    {
        #region Private members

        private ClientAudioSender _clientAudioSender = null;
        private WasapiLoopbackCapture _captureInstance = null;
        private WaveInEvent _waveIn = null;
        
        private List<byte> buffer = new List<byte>();
        
        private const int LAST_MESSAGES = 1000;
        private const double COEF = 0.65;

        #endregion Private members

        #region Ctors

        public SpeakerRecorder(GlobalSettings globalSettings)
        {
            _clientAudioSender = new ClientAudioSender(globalSettings);
            _captureInstance = new WasapiLoopbackCapture();
            var format = _captureInstance.WaveFormat;
            //_captureInstance.WaveFormat = createLPCMFormat();
            addEventHandlers();
        }

        #endregion Ctors

        #region Public methods

        public void StartRecording()
        {
            _captureInstance.StartRecording();
        }

        public void StopRecording()
        {
            _captureInstance.StopRecording();
        }

        #endregion Public methods

        #region Private methods

        private void addEventHandlers()
        {
            _captureInstance.DataAvailable += new EventHandler<WaveInEventArgs>(captureDataAvailableHandler);
            _captureInstance.RecordingStopped += new EventHandler<StoppedEventArgs>(captureRecordingStoppedHandler);
        }

        private void captureDataAvailableHandler(object? sender, WaveInEventArgs args)
        {
            buffer.AddRange(args.Buffer);
            if (args.Buffer.TakeLast(LAST_MESSAGES).Count((bt) => bt < 100) > COEF * LAST_MESSAGES)
            {
                _clientAudioSender.SendAudio(buffer.ToArray());
                buffer.Clear();
            }
        }

        private void captureRecordingStoppedHandler(object? sender, StoppedEventArgs args)
        {
            _captureInstance.Dispose();
        }

        // public byte[] ToPCM16(byte[] inputBuffer, int length, WaveFormat format)
        // {
        //     if (length == 0)
        //         return new byte[0]; // No bytes recorded, return empty array.
        //
        //     // Create a WaveStream from the input buffer.
        //     using var memStream = new MemoryStream(inputBuffer, 0, length);
        //     using var inputStream = new RawSourceWaveStream(memStream, format);
        //
        //     // Convert the input stream to a WaveProvider in 16bit PCM format with sample rate of 48000 Hz.
        //     var convertedPCM = new SampleToWaveProvider16(
        //         new WdlResamplingSampleProvider(
        //             new WaveToSampleProvider(inputStream),
        //             8000)
        //     );
        //     convertedPCM.WaveFormat.BitsPerSample = 8;
        //
        //     byte[] convertedBuffer = new byte[length];
        //
        //     using var stream = new MemoryStream();
        //     int read;
        //     
        //     // Read the converted WaveProvider into a buffer and turn it into a Stream.
        //     while ((read = convertedPCM.Read(convertedBuffer, 0, length)) > 0)
        //         stream.Write(convertedBuffer, 0, read);
        //
        //     WaveFormat newFormat = new WaveFormat(8000, 8, 2);
        //     
        //     // Return the converted Stream as a byte array.
        //     stream.Position = 0;
        //     var resultWaveSteam = new WaveFormatCustomMarshaler(new RawSourceWaveStream(stream, convertedPCM.WaveFormat));
        //
        //     var resultSteam = new MemoryStream();
        //     resultSteam.CopyTo(resultWaveSteam);
        //     
        //     return resultSteam.ToArray();
        // }
        
        //
        // byte[] global_buff = new byte[1024 * 1024];
        //
        // public byte[] Convert(byte[] input, int length, WaveFormat format)
        // {
        //     if (length == 0)
        //         return new byte[0];
        //
        //     using (var memStream = new MemoryStream(input, 0, length))
        //     {
        //         using (var inputStream = new RawSourceWaveStream(memStream, format))
        //         {
        //             //convert bytes to floats for operations.
        //             WaveToSampleProvider sampleStream = new WaveToSampleProvider(inputStream);
        //
        //             //resample to 44.1khz
        //             var resamplingProvider = new WdlResamplingSampleProvider(sampleStream, 44100);
        //
        //             //convert float stream to PCM 16 bit.
        //             var ieeeToPCM = new SampleToWaveProvider16(resamplingProvider);
        //             return readStream(ieeeToPCM);
        //         }
        //     }
        // }

        // private void some(WaveFormat newFormat)
        // {
        //     var bytes = new byte[1024 * 1024];
        //     int outRate = 16000;
        //     var outputStream = new MemoryStream(bytes);
        //     using (var writer = new WaveFileWriter(outputStream, WaveFormat.CreateIeeeFloatWaveFormat(outRate, newFormat.Channels)))
        //     {
        //         var read = 0;
        //         var buffer = new float[1000];
        //         var resampler = new NAudio.Wave.SampleProviders.Wa();
        //         resampler.SetMode(true, 2, false);
        //         resampler.SetFilterParms();
        //         resampler.SetFeedMode(true); // input driven
        //         resampler.SetRates(reader.WaveFormat.SampleRate, outRate);
        //
        //         while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
        //         {
        //             int framesAvailable = read / reader.WaveFormat.Channels;
        //             float[] inBuffer;
        //             int inBufferOffset;
        //             int inNeeded = resampler.ResamplePrepare(framesAvailable, writer.WaveFormat.Channels, out inBuffer, out inBufferOffset);
        //
        //             Array.Copy(buffer,0,inBuffer,inBufferOffset,inNeeded * reader.WaveFormat.Channels);
        //
        //             int inAvailable = inNeeded;
        //             float[] outBuffer = new float[2000]; // plenty big enough
        //             int framesRequested = outBuffer.Length / writer.WaveFormat.Channels;
        //             int outAvailable = resampler.ResampleOut(outBuffer, 0, inAvailable, framesRequested, writer.WaveFormat.Channels);
        //
        //             writer.WriteSamples(outBuffer, 0, outAvailable * writer.WaveFormat.Channels);
        //         }
        //     }
        // }

        // private byte[] readStream(IWaveProvider waveStream)
        // {
        //     using (var stream = new MemoryStream())
        //     {
        //         int read;
        //         while ((read = waveStream.Read(global_buff, 0, global_buff.Length)) > 0)
        //         {
        //             stream.Write(global_buff, 0, read);
        //         }
        //         return stream.ToArray();
        //     }
        // }
        
        #endregion Private methods
    }
}
