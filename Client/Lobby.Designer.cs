namespace Client
{
    partial class Lobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lobby));
            this.connectButton = new System.Windows.Forms.Button();
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.nicknameTextBox = new System.Windows.Forms.TextBox();
            this.readyButton = new System.Windows.Forms.Button();
            this.notReadyButton = new System.Windows.Forms.Button();
            this.connectedToLobbyPanel = new System.Windows.Forms.Panel();
            this.counter = new System.Windows.Forms.Label();
            this.player2Name = new System.Windows.Forms.Label();
            this.player2Desc = new System.Windows.Forms.Label();
            this.player1Name = new System.Windows.Forms.Label();
            this.player1Desc = new System.Windows.Forms.Label();
            this.connectPanel = new System.Windows.Forms.Panel();
            this.connectedToLobbyPanel.SuspendLayout();
            this.connectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            resources.ApplyResources(this.connectButton, "connectButton");
            this.connectButton.Name = "connectButton";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // nicknameLabel
            // 
            resources.ApplyResources(this.nicknameLabel, "nicknameLabel");
            this.nicknameLabel.Name = "nicknameLabel";
            // 
            // nicknameTextBox
            // 
            resources.ApplyResources(this.nicknameTextBox, "nicknameTextBox");
            this.nicknameTextBox.Name = "nicknameTextBox";
            // 
            // readyButton
            // 
            resources.ApplyResources(this.readyButton, "readyButton");
            this.readyButton.BackColor = System.Drawing.Color.LimeGreen;
            this.readyButton.Name = "readyButton";
            this.readyButton.UseVisualStyleBackColor = false;
            this.readyButton.Click += new System.EventHandler(this.readyButton_Click);
            // 
            // notReadyButton
            // 
            resources.ApplyResources(this.notReadyButton, "notReadyButton");
            this.notReadyButton.BackColor = System.Drawing.Color.Red;
            this.notReadyButton.Name = "notReadyButton";
            this.notReadyButton.UseVisualStyleBackColor = false;
            this.notReadyButton.Click += new System.EventHandler(this.notReadyButton_Click);
            // 
            // connectedToLobbyPanel
            // 
            resources.ApplyResources(this.connectedToLobbyPanel, "connectedToLobbyPanel");
            this.connectedToLobbyPanel.Controls.Add(this.counter);
            this.connectedToLobbyPanel.Controls.Add(this.player2Name);
            this.connectedToLobbyPanel.Controls.Add(this.player2Desc);
            this.connectedToLobbyPanel.Controls.Add(this.player1Name);
            this.connectedToLobbyPanel.Controls.Add(this.player1Desc);
            this.connectedToLobbyPanel.Controls.Add(this.readyButton);
            this.connectedToLobbyPanel.Controls.Add(this.notReadyButton);
            this.connectedToLobbyPanel.Name = "connectedToLobbyPanel";
            // 
            // counter
            // 
            resources.ApplyResources(this.counter, "counter");
            this.counter.Name = "counter";
            // 
            // player2Name
            // 
            resources.ApplyResources(this.player2Name, "player2Name");
            this.player2Name.Name = "player2Name";
            // 
            // player2Desc
            // 
            resources.ApplyResources(this.player2Desc, "player2Desc");
            this.player2Desc.Name = "player2Desc";
            // 
            // player1Name
            // 
            resources.ApplyResources(this.player1Name, "player1Name");
            this.player1Name.Name = "player1Name";
            // 
            // player1Desc
            // 
            resources.ApplyResources(this.player1Desc, "player1Desc");
            this.player1Desc.Name = "player1Desc";
            // 
            // connectPanel
            // 
            resources.ApplyResources(this.connectPanel, "connectPanel");
            this.connectPanel.Controls.Add(this.nicknameTextBox);
            this.connectPanel.Controls.Add(this.nicknameLabel);
            this.connectPanel.Controls.Add(this.connectButton);
            this.connectPanel.Name = "connectPanel";
            // 
            // Lobby
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.connectPanel);
            this.Controls.Add(this.connectedToLobbyPanel);
            this.Name = "Lobby";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.connectedToLobbyPanel.ResumeLayout(false);
            this.connectedToLobbyPanel.PerformLayout();
            this.connectPanel.ResumeLayout(false);
            this.connectPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button connectButton;
        private Label nicknameLabel;
        private TextBox nicknameTextBox;
        private Button readyButton;
        private Button notReadyButton;
        private Panel connectedToLobbyPanel;
        private Label player2Name;
        private Label player2Desc;
        private Label player1Name;
        private Label player1Desc;
        private Panel connectPanel;
        private Label counter;
    }
}