namespace WindowsFormsApplication5
{
    partial class Form5
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textMessages = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.textMessage);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.textMessages);
            this.panel4.Controls.Add(this.buttonClear);
            this.panel4.Controls.Add(this.buttonSend);
            this.panel4.Location = new System.Drawing.Point(8, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(523, 415);
            this.panel4.TabIndex = 25;
            // 
            // textMessage
            // 
            this.textMessage.Location = new System.Drawing.Point(10, 29);
            this.textMessage.Multiline = true;
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(502, 85);
            this.textMessage.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.YellowGreen;
            this.label2.Location = new System.Drawing.Point(10, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Сообщение";
            // 
            // textMessages
            // 
            this.textMessages.Location = new System.Drawing.Point(10, 162);
            this.textMessages.Multiline = true;
            this.textMessages.Name = "textMessages";
            this.textMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textMessages.Size = new System.Drawing.Size(502, 243);
            this.textMessages.TabIndex = 20;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(301, 120);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(120, 23);
            this.buttonClear.TabIndex = 21;
            this.buttonClear.Text = "Очистить чат";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(437, 120);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 17;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Blue;
            this.button11.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.ForeColor = System.Drawing.Color.Black;
            this.button11.Location = new System.Drawing.Point(367, 429);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(164, 36);
            this.button11.TabIndex = 26;
            this.button11.Text = "Назад";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication5.Properties.Resources._123123213;
            this.ClientSize = new System.Drawing.Size(543, 477);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.panel4);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Общий чат";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textMessages;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button button11;
    }
}