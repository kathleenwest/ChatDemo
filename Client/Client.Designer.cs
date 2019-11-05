namespace Client
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lstChatMessages = new System.Windows.Forms.ListBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.lblMyMessage = new System.Windows.Forms.Label();
            this.txtMyMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(217, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chat Client";
            // 
            // lstChatMessages
            // 
            this.lstChatMessages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstChatMessages.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstChatMessages.FormattingEnabled = true;
            this.lstChatMessages.ItemHeight = 20;
            this.lstChatMessages.Location = new System.Drawing.Point(27, 73);
            this.lstChatMessages.Name = "lstChatMessages";
            this.lstChatMessages.Size = new System.Drawing.Size(739, 284);
            this.lstChatMessages.TabIndex = 4;
            this.lstChatMessages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstChatMessages_DrawItem);
            this.lstChatMessages.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstChatMessages_MeasureItem);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(382, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(112, 37);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(500, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(266, 44);
            this.txtName.TabIndex = 3;
            // 
            // btnConnection
            // 
            this.btnConnection.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConnection.BackgroundImage")));
            this.btnConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConnection.Location = new System.Drawing.Point(235, 14);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(60, 46);
            this.btnConnection.TabIndex = 1;
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // lblMyMessage
            // 
            this.lblMyMessage.AutoSize = true;
            this.lblMyMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyMessage.Location = new System.Drawing.Point(25, 377);
            this.lblMyMessage.Name = "lblMyMessage";
            this.lblMyMessage.Size = new System.Drawing.Size(195, 37);
            this.lblMyMessage.TabIndex = 5;
            this.lblMyMessage.Text = "My Message";
            // 
            // txtMyMessage
            // 
            this.txtMyMessage.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMyMessage.Location = new System.Drawing.Point(32, 429);
            this.txtMyMessage.Multiline = true;
            this.txtMyMessage.Name = "txtMyMessage";
            this.txtMyMessage.Size = new System.Drawing.Size(734, 88);
            this.txtMyMessage.TabIndex = 6;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSendMessage.BackgroundImage")));
            this.btnSendMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendMessage.Location = new System.Drawing.Point(706, 377);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(60, 46);
            this.btnSendMessage.TabIndex = 7;
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMyMessage);
            this.Controls.Add(this.lblMyMessage);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lstChatMessages);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Client Chat Window";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstChatMessages;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Label lblMyMessage;
        private System.Windows.Forms.TextBox txtMyMessage;
        private System.Windows.Forms.Button btnSendMessage;
    }
}

