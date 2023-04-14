namespace TTS_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.selectPptxButton = new System.Windows.Forms.Button();
            this.execButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 279);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(798, 41);
            this.textBox1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.AccessibleDescription = "this is where the scraped text is returned to";
            this.richTextBox1.Location = new System.Drawing.Point(3, 37);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(798, 236);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AccessibleName = "Instructions";
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(150, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(150, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Size = new System.Drawing.Size(345, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select a powerpoint file that you would like to\r\nhave audio synthesized fo" +
    "r output.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.selectPptxButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.richTextBox1);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.selectPptxButton);
            this.flowLayoutPanel1.Controls.Add(this.execButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(810, 385);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // selectPptxButton
            // 
            this.selectPptxButton.AccessibleDescription = "This is the initial button colored yellow that selects the Powerpoint file for sc" +
    "raping";
            this.selectPptxButton.BackColor = System.Drawing.SystemColors.Info;
            this.selectPptxButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.selectPptxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPptxButton.Location = new System.Drawing.Point(3, 326);
            this.selectPptxButton.Name = "selectPptxButton";
            this.selectPptxButton.Size = new System.Drawing.Size(196, 35);
            this.selectPptxButton.TabIndex = 6;
            this.selectPptxButton.Text = "Select PPT File";
            this.selectPptxButton.UseVisualStyleBackColor = false;
            // 
            // execButton
            // 
            this.execButton.AccessibleDescription = "This is the button labeled Start Processing File";
            this.execButton.AutoSize = true;
            this.execButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.execButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.execButton.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.execButton.Location = new System.Drawing.Point(205, 326);
            this.execButton.Name = "execButton";
            this.execButton.Size = new System.Drawing.Size(201, 35);
            this.execButton.TabIndex = 7;
            this.execButton.Text = "Start Processing File";
            this.execButton.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 393);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Text To Speech Converter";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button selectPptxButton;
        private System.Windows.Forms.Button execButton;
    }
}

