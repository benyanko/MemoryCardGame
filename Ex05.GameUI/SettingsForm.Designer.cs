namespace Ex05.GameUI
{
    public partial class SettingsForm
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
            this.m_Player1NameLabel = new System.Windows.Forms.Label();
            this.m_Player2NameLabel = new System.Windows.Forms.Label();
            this.m_BoardSizeLabel = new System.Windows.Forms.Label();
            this.m_Player1NameTextBox = new System.Windows.Forms.TextBox();
            this.m_Player2NameTextBox = new System.Windows.Forms.TextBox();
            this.m_AgaintsButton = new System.Windows.Forms.Button();
            this.m_StartButton = new System.Windows.Forms.Button();
            this.m_BoardSizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_Player1NameLabel
            // 
            this.m_Player1NameLabel.AutoSize = true;
            this.m_Player1NameLabel.Location = new System.Drawing.Point(69, 40);
            this.m_Player1NameLabel.Name = "m_Player1NameLabel";
            this.m_Player1NameLabel.Size = new System.Drawing.Size(124, 17);
            this.m_Player1NameLabel.TabIndex = 0;
            this.m_Player1NameLabel.Text = "First Player Name:";
            // 
            // m_Player2NameLabel
            // 
            this.m_Player2NameLabel.AutoSize = true;
            this.m_Player2NameLabel.Location = new System.Drawing.Point(69, 83);
            this.m_Player2NameLabel.Name = "m_Player2NameLabel";
            this.m_Player2NameLabel.Size = new System.Drawing.Size(145, 17);
            this.m_Player2NameLabel.TabIndex = 1;
            this.m_Player2NameLabel.Text = "Second Player Name:";
            // 
            // m_BoardSizeLabel
            // 
            this.m_BoardSizeLabel.AutoSize = true;
            this.m_BoardSizeLabel.Location = new System.Drawing.Point(69, 135);
            this.m_BoardSizeLabel.Name = "m_BoardSizeLabel";
            this.m_BoardSizeLabel.Size = new System.Drawing.Size(77, 17);
            this.m_BoardSizeLabel.TabIndex = 2;
            this.m_BoardSizeLabel.Text = "Board Size";
            // 
            // m_Player1NameTextBox
            // 
            this.m_Player1NameTextBox.Location = new System.Drawing.Point(236, 40);
            this.m_Player1NameTextBox.Name = "m_Player1NameTextBox";
            this.m_Player1NameTextBox.Size = new System.Drawing.Size(162, 22);
            this.m_Player1NameTextBox.TabIndex = 3;
            // 
            // m_Player2NameTextBox
            // 
            this.m_Player2NameTextBox.Location = new System.Drawing.Point(236, 80);
            this.m_Player2NameTextBox.Name = "m_Player2NameTextBox";
            this.m_Player2NameTextBox.ReadOnly = true;
            this.m_Player2NameTextBox.Size = new System.Drawing.Size(162, 22);
            this.m_Player2NameTextBox.TabIndex = 4;
            this.m_Player2NameTextBox.Text = "-Computer-";
            // 
            // m_AgaintsButton
            // 
            this.m_AgaintsButton.Location = new System.Drawing.Point(415, 77);
            this.m_AgaintsButton.Name = "m_AgaintsButton";
            this.m_AgaintsButton.Size = new System.Drawing.Size(159, 25);
            this.m_AgaintsButton.TabIndex = 5;
            this.m_AgaintsButton.Text = "Againts a friend";
            this.m_AgaintsButton.UseVisualStyleBackColor = true;
            this.m_AgaintsButton.Click += new System.EventHandler(this.m_AgaintsButton_Click);
            // 
            // m_StartButton
            // 
            this.m_StartButton.BackColor = System.Drawing.Color.PaleGreen;
            this.m_StartButton.Location = new System.Drawing.Point(431, 176);
            this.m_StartButton.Name = "m_StartButton";
            this.m_StartButton.Size = new System.Drawing.Size(133, 25);
            this.m_StartButton.TabIndex = 6;
            this.m_StartButton.Text = "Start";
            this.m_StartButton.UseVisualStyleBackColor = false;
            this.m_StartButton.Click += new System.EventHandler(this.m_StartButton_Click);
            // 
            // m_BoardSizeButton
            // 
            this.m_BoardSizeButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_BoardSizeButton.Location = new System.Drawing.Point(72, 165);
            this.m_BoardSizeButton.Name = "m_BoardSizeButton";
            this.m_BoardSizeButton.Size = new System.Drawing.Size(133, 46);
            this.m_BoardSizeButton.TabIndex = 7;
            this.m_BoardSizeButton.Text = "4 X 4";
            this.m_BoardSizeButton.UseVisualStyleBackColor = false;
            this.m_BoardSizeButton.Click += new System.EventHandler(this.m_BoardSizeButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 237);
            this.Controls.Add(this.m_BoardSizeButton);
            this.Controls.Add(this.m_StartButton);
            this.Controls.Add(this.m_AgaintsButton);
            this.Controls.Add(this.m_Player2NameTextBox);
            this.Controls.Add(this.m_Player1NameTextBox);
            this.Controls.Add(this.m_BoardSizeLabel);
            this.Controls.Add(this.m_Player2NameLabel);
            this.Controls.Add(this.m_Player1NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_Player1NameLabel;
        private System.Windows.Forms.Label m_Player2NameLabel;
        private System.Windows.Forms.Label m_BoardSizeLabel;
        private System.Windows.Forms.TextBox m_Player1NameTextBox;
        private System.Windows.Forms.TextBox m_Player2NameTextBox;
        private System.Windows.Forms.Button m_AgaintsButton;
        private System.Windows.Forms.Button m_StartButton;
        private System.Windows.Forms.Button m_BoardSizeButton;
    }
}