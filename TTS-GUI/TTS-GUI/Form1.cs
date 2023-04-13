// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="">
//
// </copyright>
// <summary>
//   This form is how the gui interacts with the program
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.IO;

namespace TTS_GUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using TextToSpeech.TextToSp;
    using PptxScraper.PowerPointScraper;

    /// <summary>
    /// The form 1.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The label 1_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void selectPptxButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"PowerPoint files (*.pptx)|*.pptx";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.textBox1.Text = openFileDialog.FileName;
                }
            }
        }

        // Event handler for execButton
        private async void execButton_Click(object sender, EventArgs e)
        {
            string filePath = this.textBox1.Text;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show(@"Please select a valid PowerPoint file.");
                return;
            }

            PowerPointScraper pptxScraper = new PowerPointScraper();
            IList<string> extractedText = pptxScraper.ExtractTextFromPresentation(filePath);

            this.richTextBox1.Clear();
            foreach (string text in extractedText)
            {
                this.richTextBox1.AppendText(text + "\n");
            }
            // Perform Text-to-Speech operations here using the TextToSpeech class
            TextToSp tts = new TextToSp();
            string outputAudioFilePath = Path.Combine(Path.GetDirectoryName(filePath), "output_audio.wav");

            StringBuilder sb = new StringBuilder();
            foreach (string text in extractedText)
            {
                sb.AppendLine(text);
            }

            string allText = sb.ToString();
            await tts.ConvertTextToSpeech(allText, outputAudioFilePath);
            MessageBox.Show(@"Text-to-Speech conversion complete. Audio saved as: " + outputAudioFilePath);
        }
    }
}