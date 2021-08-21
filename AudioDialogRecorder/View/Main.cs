using AudioDialogRecorder.Core.Recorder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioDialogRecorder.View
{
    public partial class Main : Form
    {
        private SpeakerRecorder _speakerRecorder = null;
        private MicrophoneRecorder _microphoneRecorder = null;

        public Main()
        {
            InitializeComponent();

            _speakerRecorder = new SpeakerRecorder();
            _microphoneRecorder = new MicrophoneRecorder();
        }

        private void StartClick(object sender, EventArgs e)
        {
            _speakerRecorder.StartRecording();
            _microphoneRecorder.StartRecording();
            startButton.Enabled = false;
            endButton.Enabled = true;
        }

        private void EndClick(object sender, EventArgs e)
        {
            _speakerRecorder.StopRecording();
            _microphoneRecorder.StopRecording();
            startButton.Enabled = true;
            endButton.Enabled = false;
        }
    }
}
