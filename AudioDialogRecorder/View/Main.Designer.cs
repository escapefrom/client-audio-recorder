
namespace AudioDialogRecorder.View
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        //private void button1_Click(object sender, EventArgs e)
        //{
        //    // Define the output wav file of the recorded audio
        //    string outputFilePath = @"C:\Users\sdkca\Desktop\system_recorded_audio.wav";
        //    // Redefine the capturer instance with a new instance of the LoopbackCapture class
        //    this.CaptureInstance = new WasapiLoopbackCapture();
        //    // Redefine the audio writer instance with the given configuration
        //    this.RecordedAudioWriter = new WaveFileWriter(outputFilePath, CaptureInstance.WaveFormat);
        //    // When the capturer receives audio, start writing the buffer into the mentioned file
        //    this.CaptureInstance.DataAvailable += (s, a) =>
        //    {
        //        this.RecordedAudioWriter.Write(a.Buffer, 0, a.BytesRecorded);
        //    };
        //    // When the Capturer Stops
        //    this.CaptureInstance.RecordingStopped += (s, a) =>
        //    {
        //        this.RecordedAudioWriter.Dispose();
        //        this.RecordedAudioWriter = null;
        //        CaptureInstance.Dispose();
        //    };
        //    // Enable "Stop button" and disable "Start Button"
        //    this.button1.Enabled = false;
        //    this.button2.Enabled = true;
        //    // Start recording !
        //    this.CaptureInstance.StartRecording();
        //}
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    // Stop recording !
        //    this.CaptureInstance.StopRecording();
        //    // Enable "Start button" and disable "Stop Button"
        //    this.button1.Enabled = true;
        //    this.button2.Enabled = false;
        //}

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.startButton = new System.Windows.Forms.Button();
        this.endButton = new System.Windows.Forms.Button();
        this.cliendIdLabel = new System.Windows.Forms.Label();
        this.chatIdLabel = new System.Windows.Forms.Label();
        this.cliendIdTextBox = new System.Windows.Forms.TextBox();
        this.chatIdTextBox = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // startButton
        // 
        this.startButton.Location = new System.Drawing.Point(15, 16);
        this.startButton.Margin = new System.Windows.Forms.Padding(4);
        this.startButton.Name = "startButton";
        this.startButton.Size = new System.Drawing.Size(242, 31);
        this.startButton.TabIndex = 0;
        this.startButton.Text = "Начать запись";
        this.startButton.UseVisualStyleBackColor = true;
        this.startButton.Click += new System.EventHandler(this.StartClick);
        // 
        // endButton
        // 
        this.endButton.Enabled = false;
        this.endButton.Location = new System.Drawing.Point(15, 55);
        this.endButton.Margin = new System.Windows.Forms.Padding(4);
        this.endButton.Name = "endButton";
        this.endButton.Size = new System.Drawing.Size(242, 31);
        this.endButton.TabIndex = 1;
        this.endButton.Text = "Закончить запись";
        this.endButton.UseVisualStyleBackColor = true;
        this.endButton.Click += new System.EventHandler(this.EndClick);
        // 
        // cliendIdLabel
        // 
        this.cliendIdLabel.AutoSize = true;
        this.cliendIdLabel.Location = new System.Drawing.Point(15, 149);
        this.cliendIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.cliendIdLabel.Name = "cliendIdLabel";
        this.cliendIdLabel.Size = new System.Drawing.Size(71, 20);
        this.cliendIdLabel.TabIndex = 3;
        this.cliendIdLabel.Text = "ID клиента";
        // 
        // chatIdLabel
        // 
        this.chatIdLabel.Location = new System.Drawing.Point(70, 90);
        this.chatIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.chatIdLabel.Name = "chatIdLabel";
        this.chatIdLabel.Size = new System.Drawing.Size(129, 31);
        this.chatIdLabel.TabIndex = 4;
        this.cliendIdLabel.Text = "ID чата";
        // 
        // cliendIdTextBox
        // 
        this.cliendIdTextBox.Location = new System.Drawing.Point(15, 125);
        this.cliendIdTextBox.Margin = new System.Windows.Forms.Padding(4);
        this.cliendIdTextBox.Name = "cliendIdTextBox";
        this.cliendIdTextBox.Size = new System.Drawing.Size(241, 26);
        this.cliendIdTextBox.TabIndex = 3;
        // 
        // chatIdTextBox
        // 
        this.chatIdTextBox.Location = new System.Drawing.Point(15, 173);
        this.chatIdTextBox.Margin = new System.Windows.Forms.Padding(4);
        this.chatIdTextBox.Name = "chatIdTextBox";
        this.chatIdTextBox.Size = new System.Drawing.Size(241, 26);
        this.chatIdTextBox.TabIndex = 3;
        // 
        // Main
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(273, 227);
        this.Controls.Add(this.chatIdTextBox);
        this.Controls.Add(this.chatIdLabel);
        this.Controls.Add(this.cliendIdTextBox);
        this.Controls.Add(this.cliendIdLabel);
        this.Controls.Add(this.endButton);
        this.Controls.Add(this.startButton);
        this.Margin = new System.Windows.Forms.Padding(4);
        this.Name = "Main";
        this.Text = "ADR";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Label cliendIdLabel;
        private System.Windows.Forms.Label chatIdLabel;
        private System.Windows.Forms.TextBox cliendIdTextBox;
        private System.Windows.Forms.TextBox chatIdTextBox;
    }
}

