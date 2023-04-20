/* Windows GUI for the Pptx Text to Speech Application
 * Author: Thaddeus Thomas
 * Date: 2023-04-13
 * 
 * Notes: 
 * TODO: debug the text input for selecting a file
 * TODO: Debug the output location
 */

using PptxScraper;
using TextToSpeech;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            toolStripComboBox1 = new ToolStripMenuItem();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openFileToolStripMenuItem = new ToolStripMenuItem();
            selectOutputFolderToolStripMenuItem = new ToolStripMenuItem();
            viewLogsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            folderBrowserDialog1 = new FolderBrowserDialog();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox1 = new TextBox();
            this.ButtonExecute_Click = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            folderBrowserDialog2 = new FolderBrowserDialog();
            textBoxLogs = new RichTextBox();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripComboBox1, fileToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(723, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(12, 20);
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFileToolStripMenuItem, selectOutputFolderToolStripMenuItem, viewLogsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.Size = new Size(182, 22);
            openFileToolStripMenuItem.Text = "Open File";
            openFileToolStripMenuItem.Click += OpenFileToolStripMenuItem_Click;
            // 
            // selectOutputFolderToolStripMenuItem
            // 
            selectOutputFolderToolStripMenuItem.Name = "selectOutputFolderToolStripMenuItem";
            selectOutputFolderToolStripMenuItem.Size = new Size(182, 22);
            selectOutputFolderToolStripMenuItem.Text = "Select Output Folder";
            selectOutputFolderToolStripMenuItem.Click += SelectOutputFolderToolStripMenuItem_Click;
            // 
            // viewLogsToolStripMenuItem
            // 
            viewLogsToolStripMenuItem.Name = "viewLogsToolStripMenuItem";
            viewLogsToolStripMenuItem.Size = new Size(182, 22);
            viewLogsToolStripMenuItem.Text = "View Logs";
            viewLogsToolStripMenuItem.Click += ViewLogsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(182, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AllowDrop = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(this.ButtonExecute_Click, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(723, 30);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(607, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += TextBox1_TextChanged;
            // 
            // ButtonExecute_Click
            // 
            this.ButtonExecute_Click.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.ButtonExecute_Click.AutoSize = true;
            this.ButtonExecute_Click.Location = new Point(646, 3);
            this.ButtonExecute_Click.Name = "ButtonExecute_Click";
            this.ButtonExecute_Click.Size = new Size(74, 24);
            this.ButtonExecute_Click.TabIndex = 0;
            this.ButtonExecute_Click.Text = "Execute";
            this.ButtonExecute_Click.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
            // 
            // textBoxLogs
            // 
            textBoxLogs.Dock = DockStyle.Fill;
            textBoxLogs.Location = new Point(0, 54);
            textBoxLogs.Name = "textBoxLogs";
            textBoxLogs.Size = new Size(723, 198);
            textBoxLogs.TabIndex = 1;
            textBoxLogs.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 252);
            Controls.Add(textBoxLogs);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Event handler for selectPptxButton
        private void selectPptxButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PowerPoint Files (*.pptx)|*.pptx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        // Event handler for execButton
        private void execButton_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Please select a valid PowerPoint file.");
                return;
            }

            PowerPointScraper pptxScraper = new PowerPointScraper();
            IList<string> extractedText = PowerPointScraper.ExtractTextFromPresentation(filePath);

            textBoxLogs.Clear();
            foreach (string text in extractedText)
            {
                textBoxLogs.AppendText(text + "\n");
            }

            // Perform Text-to-Speech operations here using the provided code snippet in the previous response
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripComboBox1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem selectOutputFolderToolStripMenuItem;
        private ToolStripMenuItem viewLogsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialog1;
        private TableLayoutPanel tableLayoutPanel1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private FolderBrowserDialog folderBrowserDialog2;
        private RichTextBox textBoxLogs;
        private TextBox textBox1;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}