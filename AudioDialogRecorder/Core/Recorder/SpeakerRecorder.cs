using System;
using System.Linq;
using AudioDialogRecorder.Core.Sender;
using VisioForge.Shared.NAudio.Wave;

namespace AudioDialogRecorder.Core.Recorder
{
    public class SpeakerRecorder : RecorderBase
    {
        #region Private members

        private ClientAudioSender _clientAudioSender = null;
        private WasapiLoopbackCapture _captureInstance = null;

        #endregion Private members

        #region Ctors

        public SpeakerRecorder(GlobalSettings globalSettings)
        {
            _clientAudioSender = new ClientAudioSender(globalSettings);
            _captureInstance = new WasapiLoopbackCapture();
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
            if (!args.Buffer.All((bt) => bt == 'A'))
            {
                _clientAudioSender.SendAudio(args.Buffer);
            }
        }

        private void captureRecordingStoppedHandler(object? sender, StoppedEventArgs args)
        {
            _captureInstance.Dispose();
        }

        #endregion Private methods
    }
}
