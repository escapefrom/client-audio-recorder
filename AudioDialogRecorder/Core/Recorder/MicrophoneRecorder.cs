using AudioDialogRecorder.Core.Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisioForge.Shared.NAudio.Wave;

namespace AudioDialogRecorder.Core.Recorder
{
    public class MicrophoneRecorder : RecorderBase
    {
        #region Private members

        private ManagerAudioSender _managerAudioSender = null;
        private WaveInEvent _waveIn = null;

        #endregion Private members

        #region Ctors

        public MicrophoneRecorder(GlobalSettings globalSettings)
        {
            _managerAudioSender = new ManagerAudioSender(globalSettings);
            _waveIn = new WaveInEvent();
            _waveIn.WaveFormat = createLPCMFormat();
            addEventHandlers();
        }

        #endregion Ctors

        #region Public methods

        public void StartRecording()
        {
            _waveIn.StartRecording();
        }

        public void StopRecording()
        {
            _waveIn.StopRecording();
        }

        #endregion Public methods

        #region Private methods

        private void addEventHandlers()
        {
            _waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(captureDataAvailableHandler);
            _waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(captureRecordingStoppedHandler);
        }

        private void captureDataAvailableHandler(object? sender, WaveInEventArgs args)
        {
            if (!args.Buffer.All((bt) => bt == 'A'))
            {
                _managerAudioSender.SendAudio(args.Buffer);
            }
        }

        private void captureRecordingStoppedHandler(object? sender, StoppedEventArgs args)
        {
            _waveIn.Dispose();
        }

        #endregion Private methods
    }
}
