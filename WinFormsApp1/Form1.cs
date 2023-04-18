/*
 * Winforms Application For Text-To-Speech Application
 * Author: Thaddeus Thomas
 * Date:    April 17, 2023
 *
 *
 */

using Logging;

namespace WinFormsApp1
{
    /// <summary>
    /// Represents the main form of the application.
    /// </summary>
    public partial class Form1 : Form
    {
        private string? filePath;
        private string? outputFolderPath;
        private readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "log.txt"); // Set this to your existing log file path

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1() => InitializeComponent();

        private void OpenFileDialog1_FileOk(
            object sender,
            System.ComponentModel.CancelEventArgs e)
        {
            openFileDialog1.Filter = "All Files|*.*";
            openFileDialog1.Title = "Select a File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
            }
        }

        private void OpenFileToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                outputFolderPath = folderBrowserDialog1.SelectedPath;
            }

            openFileDialog1.Filter = "All Files|*.*";
            openFileDialog1.Title = "Select a File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                Logger.Info($"File selected: {filePath}");
            }
        }

        private void SelectOutputFolderToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            if (File.Exists(logFilePath))
            {
                textBoxLogs.Text = File.ReadAllText(logFilePath);
            }
            else
            {
                MessageBox.Show("Log file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewLogsToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                outputFolderPath = folderBrowserDialog1.SelectedPath;
                Logger.Info($"Output folder selected: {outputFolderPath}");
            }
        }

        private void ButtonExecute_Click(
            object sender,
            EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(outputFolderPath))
            {
                // Execute your command on the file here.
                // You can use the filePath and outputFolderPath variables.
                Logger.Info($"Executing command on file: {filePath}");
                Logger.Info($"Command output will be saved in folder: {outputFolderPath}");

                // After executing the command, log the result.
                Logger.Info($"Command executed successfully.");
            }
            else
            {
                MessageBox.Show("Please select a file and an output folder before executing the command.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TextBox1_TextChanged(
            object sender,
            EventArgs e)
        {
            // Update the outputFolderPath variable based on the new text in the textbox
            outputFolderPath = textBox1.Text;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Replace the title and message with your application's information
            string title = "About My Application";
            string message = "Pptx Text-To-Speech v1.0\n\n" +
                             "Developed by Thaddeus Thomas\n\n" +
                             "Copyright (c) 2023 Thads IT Solutions\n\n" +
                             "All rights reserved.";

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}