namespace ChatGUI
{
    partial class main
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.message = new System.Windows.Forms.TextBox();
            this.send_msg = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.server = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.AcceptsReturn = true;
            this.message.Location = new System.Drawing.Point(12, 308);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(266, 20);
            this.message.TabIndex = 0;
            this.message.Enter += new System.EventHandler(this.textBox1_Enter);
            this.message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.message_KeyDown);
            // 
            // send_msg
            // 
            this.send_msg.Location = new System.Drawing.Point(284, 306);
            this.send_msg.Name = "send_msg";
            this.send_msg.Size = new System.Drawing.Size(75, 23);
            this.send_msg.TabIndex = 2;
            this.send_msg.Text = "Wyślij";
            this.send_msg.UseVisualStyleBackColor = true;
            this.send_msg.Click += new System.EventHandler(this.button1_Click);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(12, 12);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(144, 23);
            this.connect.TabIndex = 3;
            this.connect.Text = "Dołącz do pokoju rozmów";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.button2_Click);
            // 
            // chat
            // 
            this.chat.Location = new System.Drawing.Point(12, 41);
            this.chat.Multiline = true;
            this.chat.Name = "chat";
            this.chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chat.Size = new System.Drawing.Size(347, 259);
            this.chat.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // server
            // 
            this.server.Location = new System.Drawing.Point(162, 12);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(116, 23);
            this.server.TabIndex = 5;
            this.server.Text = "Utwórz pokój rozmów";
            this.server.UseVisualStyleBackColor = true;
            this.server.Click += new System.EventHandler(this.server_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(284, 12);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 6;
            this.close.Text = "Wyloguj";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 342);
            this.Controls.Add(this.close);
            this.Controls.Add(this.server);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.send_msg);
            this.Controls.Add(this.message);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "Czat po TCP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Button send_msg;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.TextBox chat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button server;
        private System.Windows.Forms.Button close;
    }
}

