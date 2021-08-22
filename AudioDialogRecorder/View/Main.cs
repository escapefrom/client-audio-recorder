using AudioDialogRecorder.Core;
using AudioDialogRecorder.Core.Recorder;
using AudioDialogRecorder.Model;
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
        private GlobalSettings _globalSettings = null;

        public Main()
        {
            InitializeComponent();

            _globalSettings = GlobalSettings.GetInstance();
            _globalSettings.UrlConfig = IOReader.ReadJsonFile<Config>("appsettings.json");

            cliendIdTextBox.Text = _globalSettings.UserSourceId;

            _speakerRecorder = new SpeakerRecorder(_globalSettings);
            _microphoneRecorder = new MicrophoneRecorder(_globalSettings);
        }

        private void StartClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cliendIdTextBox.Text))
            {
                _globalSettings.ChatSourceId = _globalSettings.UserSourceId = cliendIdTextBox.Text;
            }
            else
            {
                cliendIdTextBox.Text = _globalSettings.UserSourceId;
            }

            _speakerRecorder.StartRecording();
            _microphoneRecorder.StartRecording();
            startButton.Enabled = false;
            endButton.Enabled = true;
            cliendIdTextBox.Enabled = false;
        }

        private void EndClick(object sender, EventArgs e)
        {
            _speakerRecorder.StopRecording();
            _microphoneRecorder.StopRecording();
            startButton.Enabled = true;
            endButton.Enabled = false;
            cliendIdTextBox.Enabled = true;
        }
    }
}
